using UnityEngine;
using System.Collections;

public class salirCueva : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider myCollision){
		if (myCollision.gameObject.tag == "jugador") {
			Application.LoadLevel(GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().getNivel());
		}
	}
}
