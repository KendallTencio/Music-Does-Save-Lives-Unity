using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehavoir : MonoBehaviour
{
    public float lifeTime = 3.0f;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start(){
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update(){
        //s = v * t        
        this.transform.Translate(Vector3.up * speed * Time.deltaTime); //vector3.up es hacia el frente del objeto

    }
   
}
