using UnityEngine;
using System.Collections;

public class obtenerHierro : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerStay(Collider myCollider){
		if (myCollider.gameObject.tag == "jugador") {
			GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().setMensaje("X para recoger");
			if(Input.GetKeyDown(KeyCode.X)){
				Destroy(this.gameObject);
				GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().aumentaHierro(Random.Range(1,10));
				GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().setMensaje("");
			}
		}
	}
}
