using UnityEngine;
using System.Collections;

public class cuevaPrincipal : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerStay(Collider myCollider){
		if(myCollider.gameObject.tag == "jugador"){
			GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().setEnCueva();
		}
	}
}