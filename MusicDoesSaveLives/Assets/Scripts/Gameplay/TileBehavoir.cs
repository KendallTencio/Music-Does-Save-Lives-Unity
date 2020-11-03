using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class TileBehavoir : MonoBehaviour
{
    //Shooting
    public Transform bullet;
    public float laserDistance = 0.2f;
    public float timeBetweenFires = 0.3f;
    public float timeUntilNextFire = 0.0f;
    private AudioSource audioSource;
    public List<KeyCode> shootButton;

    //Color variables
    public GameObject colorIndicator;
    public Sprite colorIndicatorSprite;
    public SpriteRenderer SRObject;
    public Sprite defaultImage;
    public Sprite pressedImage;

    //Lightning variables
    public GameObject lightning;

    void  Start()
    {
        SRObject = GetComponent<SpriteRenderer>();
        lightning.SetActive(false);
    }
    void Update()
    {
        Fire(); 
    }

    void Fire(){      
        foreach(KeyCode key in shootButton){
            if(Input.GetKey(key) && timeUntilNextFire < 0) {
            
            // Shot
            timeUntilNextFire = timeBetweenFires;
            ShootLaser();   
            break;  
            }    
        }
        timeUntilNextFire -= Time.deltaTime;
    }
    void ShootLaser(){        
        PressedTile();

     //   Vector3 laserPos = this.transform.position; //la pos de la tale        
     //   float rotationAngle = this.transform.localEulerAngles.z - 90;        
     //   laserPos.x += Mathf.Cos(rotationAngle * Mathf.Deg2Rad) * laserDistance;
     //   laserPos.y += Mathf.Sin(rotationAngle * Mathf.Deg2Rad) * laserDistance;
     //   Instantiate(bullet,laserPos,this.transform.rotation);
    }    

    void PressedTile()
    {
        SRObject.sprite = pressedImage;
        colorIndicator.GetComponent<SpriteRenderer>().sprite = colorIndicatorSprite;
        lightning.SetActive(true);
        StartCoroutine(waitForTile());
    }

    private IEnumerator waitForTile()
    {
        yield return new WaitForSeconds(0.3f);
        SRObject.sprite = defaultImage;
        lightning.SetActive(false);
    }
}
