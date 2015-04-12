using UnityEngine;
using System.Collections;

public class moverCuriosity : MonoBehaviour {
	int[] muestra=new int[7];	
	Transform thisTransform;
	
	int salto=2;
	int x=8;
	bool segundo;
	int contador;
	int angulo=0;
	
	
	void Start(){
		int contador = 0;
		thisTransform = this.transform;
		segundo = true;
		for (int i=0; i<muestra.Length; i++) {
			muestra[i]=0;
			
		}
		muestra [6] = 1;
	}
	
	// Update is called once per frame
	void Update (){
		if (segundo) {
			if ((int)(Time.time % 2) == 0) {  //%3 para cada 3 segundos (cambiar a los segundos que queremos que dure)
				segundo = false;
				thisTransform.Translate (x * Time.deltaTime * Vector3.forward);
				thisTransform.Translate (x * Time.deltaTime * Vector3.right);
				for(int i=0;i<2;i++){
					thisTransform.Rotate(Vector3.up*1);
				}
			}
		}
		if ((int)(Time.time % 2) == 1) { //Cuando el tiempo este en 1, cambiara segundo y podra entrar a la funcion anterior, pero se actualizara hasta que este en 0
			segundo=true;
		}
	}
	
	public void recogeMaterial(int lugar){
		muestra [lugar]++;
	}
	void OnTriggerStay(Collider myCollider){
		if(myCollider.gameObject.tag=="muro"){
			for(int i=0;i<50;i++){
				thisTransform.Rotate(Vector3.up*1);
			}
			for(int i=0;i<10;i++){
				thisTransform.Translate (x * Time.deltaTime * Vector3.forward);
			}
		}
		if(myCollider.gameObject.tag=="jugador"){
			GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().setMensaje("X para cargar elementos");
			if(Input.GetKeyDown(KeyCode.X)){
				for(int i =0;i<muestra.Length-1;i++){
					for(int e=0;e<muestra[i];e++){
						GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().recogeMaterial(i);
					}
					for (int u =0; u<(this.muestra.Length)&&this.muestra[u]!=0; u++) {
						if(i>3){
							GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().setMensaje("Objetivo completado: Obtener 4 muestras geologicas");
						}
					}
				}
				if(muestra[6]>0){
					muestra[6]=0;
					
					
					GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().recogerMuestraEspecial();
					
					
					
				}
			}
			
			
			
		}
	}
}


