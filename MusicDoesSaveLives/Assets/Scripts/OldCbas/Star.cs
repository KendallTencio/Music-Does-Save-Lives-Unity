using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float speed; //Velocidad estrellas
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Sacar la posicion actual
	Vector2 position = transform.position;
	//Cambiar la posicion de la estrella
	position = new Vector2(position.x,position.y+speed*Time.deltaTime);
	//Actualizar la posicion
	transform.position=position;
	//Punto abajo a la izquierda de la pantalla
	Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
	//Punto arriba a la derecha
	Vector2 max= Camera.main.ViewportToWorldPoint(new Vector2(1,1));
	//If de condiciones
	if(transform.position.y<min.y){
		transform.position= new Vector2(Random.Range(min.x,max.x),max.y);
	}
    }
}
