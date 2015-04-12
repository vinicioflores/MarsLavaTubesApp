using System.Collections;
using UnityEngine;

public class astronauta : MonoBehaviour {
	
	public bool impresora=false;
	public int semillas=0;
	public bool panel=false;	
	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerStay(Collider myCollider){
		if (myCollider.gameObject.tag == "astronauta") {
			//GUI.Box (new Rect (Screen.width / 2, Screen.height / 2, 220, 30), "No esta en la zona de construccion!");
			GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().setMensaje("X para ayudar");
			if(Input.GetKeyDown(KeyCode.X)){
				Destroy(this.gameObject);
				//GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().aumentaHierro(Random.Range(1,10));
				GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().setMensaje("");
				GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().aumentarSemillas(semillas);
				GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().aumentarAstronautas();
				if(impresora){
					GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().setMensaje("");
					GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().setMensaje("Ha obtenido impresora");
					
					GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().setImpresora(true);
				}
				if(panel){
					GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().setMensaje("");
					GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().setMensaje("Ha obtenido panel");
					
					GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().setImpresora(true);
				}
			}
			
		}
	}
	
	
	// Update is called once per frame
	void Update () {
		
		//GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().setMensaje("X para ayudar");
		
	}
}
