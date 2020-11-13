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
            PressedTile();   
            break;  
            }    
        }
        timeUntilNextFire -= Time.deltaTime;
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
        yield return new WaitForSeconds(0.5f);
        SRObject.sprite = defaultImage;
        lightning.SetActive(false);
    }
}
