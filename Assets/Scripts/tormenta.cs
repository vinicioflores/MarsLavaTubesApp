using UnityEngine;
using System.Collections;

public class tormenta : MonoBehaviour {
	bool segundo=true;
	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
		if(segundo){
			if ((int)(Time.time%2)==0) {  //%3 para cada 3 segundos (cambiar a los segundos que queremos que dure)
				segundo=false;  //Si el tiempo es 0, como el update se hace muchas veces por segundo, cambiamos la variable segundo y asi no entrara al ciclo
				GameObject.FindWithTag("MainCamera").GetComponent<recursosCamara>().aumentaVida(-10);
			}
		}
		if ((int)(Time.time % 2) == 1) { //Cuando el tiempo este en 1, cambiara segundo y podra entrar a la funcion anterior, pero se actualizara hasta que este en 0
			segundo=true;
		}
	}
}
