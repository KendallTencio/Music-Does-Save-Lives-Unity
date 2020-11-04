using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public GameObject StarGO; //Estrella 
    public int MaxStars; //Maximo estrellas
    //Array de colores a usar
    Color[] starColors ={
	new Color (0.5f,0.5f,1f),
	new Color(0,1f,1f),
	new Color(1f,1f,0),
	new Color(1f,0,0),
	new Color(0,1f,0),
	new Color(1f, 0.92f, 0.016f),
	new Color(0.5f,0.5f,0.5f),
	new Color(1f,0,1f)
    };
 
    // Start is called before the first frame update
    void Start()
    {
	//Esquina abajo izquierda
        Vector2 min= Camera.main.ViewportToWorldPoint(new Vector2(0,0));
	//Esquina arriba derecha
	Vector2 max= Camera.main.ViewportToWorldPoint(new Vector2(1,1));
	//Ciclo para crear las estrellas
	for(int i=0; i<MaxStars; ++i){
		GameObject star= (GameObject)Instantiate(StarGO);
		//Fijarle color
		star.GetComponent<SpriteRenderer>().color=starColors[i % starColors.Length];
		//Fijar la posicion de la estrella
		star.transform.position= new Vector2(Random.Range(min.x,max.x),Random.Range(min.y,max.y));
		//Fijar una velocidad random
		star.GetComponent<Star>().speed=-(1f*Random.value+0.09f);
		//Hacer la estrella hija del StarGeneratorGO
		star.transform.parent=transform;
	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
