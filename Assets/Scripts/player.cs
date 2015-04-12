using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public float vel=10;
	bool suelo=true;
	Transform thisTransform;
	Rigidbody thisRigid;
	Animator thisAnimator;
	
	// Use this for initialization
	void Start () {
		thisAnimator = this.GetComponent<Animator> ();
		thisTransform = this.GetComponent<Transform>();
		thisRigid = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().estaMuerto()==false){
			thisTransform.Rotate (Input.GetAxis ("Horizontal") * 70 * Time.deltaTime* Vector3.up);
			thisTransform.Translate (Input.GetAxis ("Vertical") * vel * Time.deltaTime * Vector3.forward);

			if (Input.GetKey (KeyCode.DownArrow)|| Input.GetKey (KeyCode.UpArrow)) {
			
				thisAnimator.SetBool ("quieto", false);		
					}
			else {
				thisAnimator.SetBool("quieto",true);
					}
			if (Input.GetKeyDown (KeyCode.X)) {
				
				thisAnimator.SetBool ("recogiendo", true);		
			}
			else {
				thisAnimator.SetBool("recogiendo",false);
			}
			if(suelo) {
				if (Input.GetKey(KeyCode.Space)) {
					thisAnimator.SetBool("saltando",true);
					suelo= false;
					thisRigid.AddForce(370*Vector3.up);
				}
			}else{
				thisAnimator.SetBool("saltando",false);
			}
		}else{
			thisAnimator.SetBool("muriendo",true);
		}
	}
	void OnCollisionStay(Collision thisCollision){
		if (thisCollision.gameObject.tag == "suelo") {
			suelo = true;
		}
	}
}