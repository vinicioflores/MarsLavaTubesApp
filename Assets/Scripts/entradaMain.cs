using UnityEngine;
using System.Collections;

public class entradaMain : MonoBehaviour {

	public string cueva = "";
	public int x=0,y=0,z=0;
	public int xVivero=-43,yVivero=15,zVivero=-45;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().getViveros(); i++) {
			Instantiate(GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().crear[4], new Vector3(xVivero,yVivero,zVivero), Quaternion.identity);
			zVivero += 4;
			}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider myCollision){
		if (myCollision.gameObject.tag == "jugador") {
			print ("Entro");
			GameObject.FindWithTag ("posicion").GetComponent<posicionesJugador> ().setCoord(x,y,z);
			Application.LoadLevel(cueva);
		}
	}
}
