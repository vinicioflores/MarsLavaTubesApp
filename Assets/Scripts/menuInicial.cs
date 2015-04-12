using UnityEngine;
using System.Collections;

public class menuInicial : MonoBehaviour {
	// Use this for initialization
	bool configuracion=false;
	bool informacion=false;
	bool jugar=false;
	static bool sonido2=true;
	static int nivel=1;
	int presentacion=0;
	int largo,altura,x,y,yMas;
	string textoInfo;
	public Texture2D[] niveles;
	public Texture2D[] presentaciones;
	void Start () {
	}
	void Update () {
	}
	public int getNivel(){
		return nivel;
	}
	void OnGUI(){
		if(jugar==false){
			yMas = 0;
			largo=(((Screen.width/100)+2)*10)+10;
			altura =(((Screen.height/100)+2)*10);
			x=10;
			y=10;
			print (y);
			if (Screen.height/100 > 3) {
				yMas=50;
			}
			if (Screen.height/100 > 6) {
				yMas=100;
			}
			if(informacion==false){
				textoInfo="Seleccione la informacion que desea consultar";
				if(configuracion==false){
					if (GUI.Button (new Rect (x, y,largo,altura),"Jugar")) {
						jugar=true;
						this.GetComponent<AudioSource>().Stop();
					}
					if (GUI.Button (new Rect (x, y+50+(yMas*1), largo,altura),"Configuracion")) {
						configuracion=true;
					}
					if(GUI.Button(new Rect(x, y+100+(yMas*2),largo,altura),"Informacion")){
						informacion=true;
					}
					if(GUI.Button(new Rect(x,Screen.height-50,largo,altura),"Salir")){
						Application.Quit();
					}
				}else{
					if(sonido2){
						if(GUI.Button(new Rect(x, y+(yMas*1),largo,altura),"Musica: SI!")){
							sonido2=false;
							recursosCamara.sonido="NO";
							this.GetComponent<AudioSource>().Stop();
						}
					}else{
						if(GUI.Button(new Rect(x, y+(yMas*1),largo,altura),"Musica: NO!")){
							sonido2=true;
							recursosCamara.sonido="SI";
							this.GetComponent<AudioSource>().Play();
						}
					}
					if(GUI.Button(new Rect(x, y+50+(yMas*1),largo,altura),"Nivel: "+nivel)){
						nivel++;
						if(nivel>5){
							nivel=1;
						}
					}
					GUI.Label(new Rect(x+largo+20,10,Screen.width/2,(Screen.height/4)*3),niveles[nivel-1]);
					if(GUI.Button(new Rect(x,Screen.height-50,largo,altura),"Volver")){
						configuracion=false;
					}
				}
			}else{
				if(GUI.Button(new Rect(x,y,largo+10,altura),"Sobre Marte")){
					textoInfo="Es el tercer planeta en el sistema solar. Tiene un color rojo llamativo y no ha mostrado señales de vida.";
					textoInfo+="\n\nPor las bajas temperaturas que tiene, cuenta con yacimientos de hielo en distintas partes. Ademas tiene recursos.";
					textoInfo+="\n\nEn el planeta se presentan constantes tormentas que pueden lastimar a los astronautas que visiten el planeta.";
				}
				if(GUI.Button(new Rect(x,y+50+(yMas*1),largo+10,altura),"Tubos de lava")){
					textoInfo="Cuando un volcán emite lava fluída incandescente que transita una superficie con poca pendiente, la capa externa de dicha colada se solidifica al bajar de temperatura en contacto con el aire, y aísla el resto de la lava, que mantiene su temperatura y que continúa fluyendo por dentro del tubo.";
					textoInfo+="\n\nSu estructura puede ser de simples tubos lineales o en forma de redes complejas de tubos interconectados;";
					textoInfo+="\n\nInformacion obtenida de:\nhttp://geografia.laguia2000.com/general/tubo-de-lava";
				}
				if(GUI.Button(new Rect(x,y+100+(yMas*2),largo+10,altura),"Recursos de marte")){
					textoInfo="Se han descubierto recursos que podrian ser de ayuda para los astronautas que visiten el planeta. Por ejemplo:";
					textoInfo+="\n1-Hierro.\n2-Mercurio.\n1-Calcio.\nAdemas de algunos compuestos de estos elementos";
					textoInfo+="\n\nOtro recurso y posiblemente el mas importante para los visitantes es que los tubos de lava pueden contener aun lava en partes profundas,";
					textoInfo+=" la cual puede derretir agua que este cerca y asi proporcionar fuentes de agua que podrian salvar vidas.";
				}
				GUI.TextArea(new Rect(x+largo+20,10,Screen.width/2,(Screen.height/4)*3),textoInfo);
				if(GUI.Button(new Rect(x,Screen.height-50,largo+10,altura),"Volver")){
					informacion=false;
				}
			}
		}else{
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),presentaciones[presentacion]);
			if(GUI.Button(new Rect(10,10,largo,altura),"Siguiente")){
				presentacion++;
			}
			if(presentacion>4){
				if(nivel==1){
					recursosCamara.nivel="curiosityHoleScene";
				}else if(nivel==2){
					recursosCamara.nivel="northPoleScene";
				}else if(nivel==3){
					recursosCamara.nivel="terreno2";
				}else if(nivel==4){
					recursosCamara.nivel="terreno3";
				}else if(nivel==5){
					recursosCamara.nivel="terreno4";
				}else if(nivel==6){
					recursosCamara.nivel="victoriaCraterScene";
				}
				Application.LoadLevel("perdidaInicial");
			}
		}
	}
}


/*Music used: End Game by Per Kiilstofte
https://machinimasound.com/music/end-game
Licensed under Creative Commons Attribution 4.0 International
(http://creativecommons.org/licenses/by/4.0/)}*/