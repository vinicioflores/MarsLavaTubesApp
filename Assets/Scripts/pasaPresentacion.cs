using UnityEngine;
using System.Collections;

public class pasaPresentacion : MonoBehaviour {
	bool segundo=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(segundo){
			if ((int)(Time.time%6)==0) {  //%3 para cada 3 segundos (cambiar a los segundos que queremos que dure)
				segundo=false;  //Si el tiempo es 0, como el update se hace muchas veces por segundo, cambiamos la variable segundo y asi no entrara al ciclo
				Application.LoadLevel("menuPrincipal");
			}
		}
		if ((int)(Time.time % 6) == 1) { //Cuando el tiempo este en 1, cambiara segundo y podra entrar a la funcion anterior, pero se actualizara hasta que este en 0
			segundo=true;
		}
	}
}
