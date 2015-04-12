using UnityEngine;
using System.Collections;

public class iniciarCuevaMain : MonoBehaviour {
	public int xVivero=-10,yVivero=24,zVivero=-31;
	// Use this for initialization
	//VIVERO, IMPRESORA, ALMACEN, PANEL
	void Start () {
		for (int i = 0; i <10; i++) {
			Instantiate(GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().crear[0], new Vector3(xVivero,yVivero,zVivero), Quaternion.identity);
			xVivero += GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().getAnchoVivero();
		}
		if (GameObject.FindWithTag ("MainCamera").GetComponent<recursosCamara> ().getImpresora()) {
			Instantiate(GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().crear[1], new Vector3(-19,22,-32), Quaternion.identity);
			
		}
		Instantiate(GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().crear[2], new Vector3(-22,22,-36), Quaternion.identity);	
		if (GameObject.FindWithTag ("MainCamera").GetComponent<recursosCamara> ().getPanel()) {
			Instantiate(GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().crear[3], new Vector3(-27,19,-36), Quaternion.identity);	
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}





