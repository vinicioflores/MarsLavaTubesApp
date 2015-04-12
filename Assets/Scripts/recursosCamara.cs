using UnityEngine;
using System.Collections;

public class recursosCamara : MonoBehaviour 
{
	public GameObject[] crear;
	int[] muestra=new int[7];
	static int vida=100;
	static int agua=100;
	static int maxBotellas=1;
	static int botellas=1;
	static int aguaEnBotella=100;
	static int hierro=0;
	static int magnesio=0;
	static int calcio=0;
	static int comida=100;
	string mensaje="";
	bool segundo=true;
	bool segundo2=true;
	bool pausa=false;
	bool muerto=false;
	static public string sonido="SI";
	static public string nivel;

	static int cantidadSemillas=0;
	static int cantidadAstronautas=0;
	static bool panel=false;
	static bool muestraEspecial=false;
	static int cantidadFuentesVisitadas=0;
	
	
	/************************************************/
	
	bool menuCrear = false;
	
	const int COSTO_VIVERO = 100;
	const int GASTO_POR_ASTRONAUTA = 1000;
	const int PRODUCCION_POR_VIVERO = 125;
	const int ANCHO_VIVERO = 2;
	
	static int capacidadAlmacenamiento = 0;		// Capacidad total de almacenamiento de comida, es proporcional al aumento del numero de almacenes
	static int almacenes = 0;        			// Cantidad de almacenes de comida construidos
	static int comidaAlmacenada = 0; 		    // Total de la comida almacenada hasta el momento.
	static int produccionViveros = 0; 			// La produccion total de comida de todos los viveros.
	static int viveros = 0;           			// Cantidad de viveros construidos
	static int gastoComida = 0;       			// Nivel al que asciende el gasto total de comida de todos los astronautas.
	static int astronautas = 1;       			// Numero de astronautas
	static bool generador = false;    			// Falso si aun no hay generador de energia construido, de lo contrario True
	static bool impresora = false;

	private int xVivero = 573, yVivero = 924, zVivero = -692; 
	
	static bool enCueva = false;
	private bool clickedViveros = false;
	
	static Vector3 posJugador = new Vector3(0,1,0);
	
	/****************************************************/
	public void recogeMaterial(int lugar){
		muestra [lugar]++;
	}
	public bool getImpresora(){
		return impresora;
	}
	public void setPosicionJugador(){
		GameObject.FindWithTag ("jugadorDor").GetComponent<Transform>().position = posJugador;
	}
	public bool estaMuerto(){
		return muerto;
	}
	public void setVector(Vector3 vector){
		posJugador = vector;
	}
	
	public void setVector(int x,int y, int z){
		posJugador = new Vector3 (x,y,z);
	}
	
	public bool getPausa(){
		return pausa;
	}
	public void aumentaVida(int cantidad){
		if(vida<=100 && 0<=vida){
			vida += cantidad;
			if(vida>100){
				vida=100;
			}
			if(vida<0){
				vida=0;
			}
		}
	}
	public void aumentarAgua(int cantidad){
		for (int i=0; i<cantidad; i++) {
			if(agua<100){
				agua++;
			}else if(aguaEnBotella<100){
				aguaEnBotella++;
			}else{
				if(botellas<maxBotellas){
					aguaEnBotella=0;
					botellas++;
				}
			}
		}
	}
	public void aumentaMagnesio(int cantida){
		magnesio += cantida;
	}
	public void aumentaCalcio(int cantidad){
		calcio += cantidad;
	}
	public void aumentaHierro(int cantidad){
		hierro += cantidad;
	}
	public void aumentaMaxBotellas(){
		maxBotellas++;
	}
	public void aumentarComida(int cantidad){
		if (comida < 100) {
			comida += cantidad;
		}
	}
	void Start () {
		for (int i=0; i<muestra.Length; i++) {
			muestra[i]=0;
		}
		GameObject.FindWithTag ("posicion").GetComponent<posicionesJugador> ().setPosicion ();
	}
	void Update () {
			if(muerto==false){
				this.GetComponent<Transform> ().Rotate (Input.GetAxis("rotarY")*100*Time.deltaTime*Vector3.left);
				if(Input.GetKeyDown(KeyCode.P)){
					if(pausa){
						pausa=false;
						menuCrear=false;
						clickedViveros=false;
						Time.timeScale=1;
					}
					else{
						pausa=true;
						Time.timeScale=0;
					}
				}
				//Cuando el segundo este en true, verificaremos si el tiempo es 0
				if(segundo){
					if ((int)(Time.time%3)==0) {  //%3 para cada 3 segundos (cambiar a los segundos que queremos que dure)
						segundo=false;  //Si el tiempo es 0, como el update se hace muchas veces por segundo, cambiamos la variable segundo y asi no entrara al ciclo
						if(agua>0){
							agua--;
						}else if(aguaEnBotella>0){
							aguaEnBotella--;
						}else if(vida>0){
							vida-=2;
						}
						if(comida>0 && agua>0){
							if(vida<100){
								vida++;
							}
						}
						mensaje="";
						enCueva = false;
					}
				}
				if ((int)(Time.time % 3) == 1) { //Cuando el tiempo este en 1, cambiara segundo y podra entrar a la funcion anterior, pero se actualizara hasta que este en 0
					segundo=true;
				}
				if (segundo2) {
					if((int)(Time.time % 10)==0){
						comida--;
						segundo2=false;
					}
				}
				if ((int)(Time.time % 10) == 1) {
					segundo2=true;
				}
			if (vida < 1) {
				muerto=true;
			}
		}else{
			pausa=true;
		}
	}
	public void setMensaje(string pMensaje){
		mensaje = pMensaje;
	}
	
	
	private void crearMenuPrincipal(){
		if(menuCrear == false){
			if(muerto){
				GUI.Label(new Rect(310,90,300,40),"Has muerto, debes reiniciar la partida");
			}
			if (GUI.Button (new Rect (200, 90, 100, 30), "Reanudar")) {
				if(muerto==false){
					clickedViveros =false;
					pausa = false;
					Time.timeScale = 1;
				}
			}
			
			
			if (GUI.Button (new Rect (200, 130, 100, 30), "Viveros")) {
				if(muerto==false){
					clickedViveros = true;
					if(enCueva){
						menuCrear = true;
					}
				}
			}
			if(enCueva == false && clickedViveros){
				GUI.Box (new Rect (Screen.width / 2, Screen.height / 2, 220, 30), "No esta en la zona de construccion!");
			}
			
			
			if (GUI.Button (new Rect (200, 190, 100, 30), "Sonido: " + sonido)) {
				if (sonido.Equals ("SI")) {
					sonido = "NO";
					this.GetComponent<AudioSource> ().Stop ();
				} else {
					sonido = "SI";
					this.GetComponent<AudioSource> ().Play ();
				}
			}
			
			if (GUI.Button (new Rect (200, 230, 100, 30), "Salir")) {
				Application.LoadLevel ("menuPrincipal");
			}
		} else {
			crearVentanaViveros();
		}
	}
	
	void OnGUI()
	{
		GUI.Box (new Rect (5, 5, Screen.width - 50, 30), "");
		GUI.Label (new Rect (10, 10, 100, 20), "Agua: " + agua + "%");
		GUI.Label (new Rect (120, 10, 100, 20), "Bottelas: " + botellas);
		GUI.Label (new Rect (230, 10, 100, 20), "Comida: " + comida + "%");
		GUI.Label (new Rect (340, 10, 100, 20), "Vida: " + vida);
		GUI.Label (new Rect (450, 10, 100, 20), "Hierro: " + hierro);
		GUI.Label (new Rect (560, 10, 100, 20), "Calcio: " + calcio);
		GUI.Label (new Rect (670, 10, 100, 20), "Magnesio: " + magnesio);
		
		if (pausa) {
			GUI.Box ( new Rect(100,50,Screen.width-200,Screen.height-100),"Menu Principal");
			crearMenuPrincipal();
		}
		if (mensaje.Equals ("") == false) {
			GUI.Box (new Rect (Screen.width / 2, Screen.height / 2, 100, 30), mensaje);
		}
	}
	
	public int getVida(){
		return vida; }
	
	private void crearVentanaViveros(){
		GUI.Window (102, new Rect(100,100,800,250),crearContenidoViveros,new GUIContent("Informacion de viveros"));
	}
	
	private void crearContenidoViveros(int a){
		
		GUI.Label (new Rect(10,20,200,30), "Cantidad de viveros: "+viveros);
		GUI.Label (new Rect(10,40,200,30), "Produccion total: "+produccionViveros);
		GUI.Label (new Rect(10,60,200,30), "Alimento almacenado "+comidaAlmacenada);
		
		if(GUI.Button (new Rect(10, 160, 200, 30), "Agregar nuevo vivero")){
			//hackCreacionVivero();
			crearVivero();
		}
		
		/* argumentos de rect: left, top, width, height */
		if (GUI.Button (new Rect (10, 200, 200, 30), "Volver al menu principal")) {
			menuCrear = false;
			clickedViveros=false;
		}
		
		//GUI.Label (new Rect(300, 10, 400, 250), new Label(new Rect(0,0,400,250), ));
	}
	
	/******************** Vinicio Flores, 2015 *********************************/
	public void aumentarAstronauta() {
		astronautas++;
		int lastGasto = gastoComida;
		gastoComida = GASTO_POR_ASTRONAUTA * astronautas;
		comidaAlmacenada -= (gastoComida - lastGasto);
	}
	
	
	// PARA PRUEBAS SOLAMENTE!!!!
	private void hackCreacionVivero(){
		generador = true;
		crearImpresora ();
		hierro = 1000000;
	}
	public int getAnchoVivero(){
		return ANCHO_VIVERO;
	}
	public void crearImpresora(){
		impresora = true;
	}

	public int getViveros(){
		return viveros;
	}
	
	public void crearVivero(){
		if (generador == false || ( (hierro - COSTO_VIVERO) < 0) || impresora == false){
			return;
		} else {
			viveros++;
			produccionViveros += PRODUCCION_POR_VIVERO*viveros;
			// OBSOLETE!
			//Instantiate(crear[4], new Vector3(xVivero,yVivero,zVivero), Quaternion.identity);
			xVivero += ANCHO_VIVERO;
			hierro -= COSTO_VIVERO;		
		}
	}
	
	public void crearAlmacen(){
		almacenes++;
	}
	
	public void almacenar(int n){
		if (n > produccionViveros)
			return;  // Porque no puedo almacenar mas comida del tope de produccion.
		else {
			produccionViveros -= n;
			if( (comidaAlmacenada + n) > capacidadAlmacenamiento )
				return;  		// Porque no puedo almacenar mas de lo que me permiten los almacenes.
			else {
				comidaAlmacenada += n;
			}
		}
	}
	
	
	public void setEnCueva(){
		enCueva = true;
	}

	public void setImpresora(bool variable){
		impresora = variable;
	}
	public void aumentarSemillas(int cantidad){
		cantidadSemillas = cantidadSemillas + cantidad;
	}
	public void aumentarAstronautas(){
		cantidadAstronautas++;
		if (cantidadAstronautas == 5) {
			setMensaje("Objetivo completado: Encuentra 5 astronautas");
		}
	}
	public bool getPanel(){
		return panel;
	}
	public void aumentarPaneles(){
		panel=true;
		if (panel) {
			setMensaje("Objetivo completado: Obtener un panel solar");
		}
	}
	public void recogerMuestraEspecial(){
		muestraEspecial=true;
		if (muestraEspecial) {
			setMensaje("Objetivo completado: Encuentra muestra especial");
		}
	}
	public void maximoAgua(){
		agua = 100;
		botellas = maxBotellas;
	}
	public void aumentarFuentesVisitadas(){
		cantidadFuentesVisitadas++;
		if (cantidadFuentesVisitadas == 10) {
			setMensaje("Objetivo completado: Visitar 10 fuentes");
			
		}
	}
	public string getNivel(){
		return nivel;
	}
	
}