using UnityEngine;
using System.Collections;

public class jugadorScript : MonoBehaviour {
	Transform thisTransform;
	float posY;
	// Use this for initialization
	void Start () {
		thisTransform = this.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		thisTransform.Rotate(100*Vector3.up*Input.GetAxis("Horizontal")*Time.deltaTime);
	}
}