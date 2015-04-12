using UnityEngine;
using System.Collections;

public class aumentarAguaMaximo : MonoBehaviour {
	
	bool visitada=false;
	
	// Use this for initialization
	void Start () {
		
	}
	void setVisitada(){
		visitada = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider myCollider){
		if (myCollider.gameObject.tag == "jugador") {
			if(!visitada){
				GameObject.FindWithTag ("MainCamera").GetComponent<recursosCamara> ().aumentarFuentesVisitadas();
			}
			visitada=true;
			GameObject.FindWithTag ("MainCamera").GetComponent<recursosCamara> ().maximoAgua ();
			setVisitada();
		}
	}
}
