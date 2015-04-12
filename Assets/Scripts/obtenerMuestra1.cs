using UnityEngine;
using System.Collections;

public class obtenerMuestra1 : MonoBehaviour {
	public int numero;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider myCollision){
		if (myCollision.gameObject.tag == "jugador") {
			GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().setMensaje("X para recoger");
			if(Input.GetKeyDown(KeyCode.X)){
				Destroy(this.gameObject);
				GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().recogeMaterial(numero);
				GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().setMensaje("");
			}
		}
		if (myCollision.gameObject.tag == "curiosity") {
			Destroy(this.gameObject);
			GameObject.FindWithTag("MainCamera").GetComponent<moverCuriosity>().recogeMaterial(numero);
		}
	}
}
