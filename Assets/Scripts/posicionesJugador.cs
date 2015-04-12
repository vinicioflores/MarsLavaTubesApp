using UnityEngine;
using System.Collections;

public class posicionesJugador : MonoBehaviour {
	static int x=1178,y=20,z=1123;
	static Vector3 jugadorPosition = new Vector3(x,y,z);
	static int cueva=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void setCoord(int cx,int cy, int cz){
		x = cx;
		y = cy;
		z = cz;
	}
	public void setVector(Vector3 posVector){
		jugadorPosition = posVector;
	}

	public void setPosicion()
	{
		setVector (new Vector3(x,y,z));
		GameObject.FindWithTag ("jugadorDor").GetComponent<Transform>().position = jugadorPosition;
	}

	public void setCueva(int c){
		cueva = c;
		}
}
