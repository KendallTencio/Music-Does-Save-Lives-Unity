using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class TileBehavoir : MonoBehaviour
{
    // Start is called before the first frame update
    //public Rigidbody bullet;
    //Disparo
    public Transform bullet;
    public float laserDistance = 0.2f;
    public float timeBetweenFires = 0.3f;
    public float timeUntilNextFire = 0.0f;
    private AudioSource audioSource;
    //public List<KeyCode> shootButton;
    public List<KeyCode> shootButton;
    //Funcionas básicas de Unity    
    void  Start()
    {
        audioSource= GetComponent<AudioSource>();
    }
    void Update()
    {
        Fire(); 
    }
    //Funciones propias
    void Fire(){      
        foreach(KeyCode key in shootButton){
            if(Input.GetKey(key) && timeUntilNextFire < 0) {
            //disparo
            timeUntilNextFire = timeBetweenFires;
            ShootLaser();   
            break;  
            }    
        }
        timeUntilNextFire -= Time.deltaTime;
    }
    void ShootLaser(){        
        audioSource.Play();
        Vector3 laserPos = this.transform.position; //la pos de la tale        
        float rotationAngle = this.transform.localEulerAngles.z - 90;        
        laserPos.x += Mathf.Cos(rotationAngle * Mathf.Deg2Rad) * laserDistance;
        laserPos.y += Mathf.Sin(rotationAngle * Mathf.Deg2Rad) * laserDistance;
        Instantiate(bullet,laserPos,this.transform.rotation);

    }    
}
