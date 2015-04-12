using UnityEngine;
using System.Collections;

public class lavaToca : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider myCollider){
		if (myCollider.gameObject.tag == "jugador") {
			GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().aumentaVida(-1);
		}
	}
}
