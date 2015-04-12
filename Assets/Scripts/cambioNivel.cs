using UnityEngine;
using System.Collections;

public class cambioNivel : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider myCollision){
		if (myCollision.gameObject.tag == "jugador") {
			if(recursosCamara.nivel=="curiosityHoleScene"){
				GameObject.FindWithTag ("posicion").GetComponent<posicionesJugador> ().setCoord(350,70,1768);
				Application.LoadLevel(GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().getNivel());
			}else if(recursosCamara.nivel=="northPoleScene"){
				GameObject.FindWithTag ("posicion").GetComponent<posicionesJugador> ().setCoord(865,56,1410);
				Application.LoadLevel(GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().getNivel());
			}else if(recursosCamara.nivel=="terreno2"){
				GameObject.FindWithTag ("posicion").GetComponent<posicionesJugador> ().setCoord(1940,41,2288);
				Application.LoadLevel(GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().getNivel());
			}else if(recursosCamara.nivel=="terreno3"){
				//GameObject.FindWithTag ("posicion").GetComponent<posicionesJugador> ().setCoord(x,y,z);
				Application.LoadLevel(GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().getNivel());
			}else if(recursosCamara.nivel=="terreno4"){
				//GameObject.FindWithTag ("posicion").GetComponent<posicionesJugador> ().setCoord(x,y,z);
				Application.LoadLevel(GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().getNivel());
			}else if(recursosCamara.nivel=="victoriaCraterScene"){
				//GameObject.FindWithTag ("posicion").GetComponent<posicionesJugador> ().setCoord(x,y,z);
				Application.LoadLevel(GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().getNivel());
			}
		}
	}
}

