using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarBehavior : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode[] keyPressed;
    public AudioSource damageSound;
    public int objectsEntered = 0;

    //CollissionPlatformBehavior for Damage
    public CollissionPlatformBehavior colPlatf;

    void Update()
    {   
        for (int i = 0; i < keyPressed.Length; i++)
        {
            if (Input.GetKeyDown(keyPressed[i]))
            {
                if (canBePressed)
                {
                    if (objectsEntered == 1)
                    {
                        canBePressed = false;
                    }
                    objectsEntered--;
                }
                else
                {
                    damageSound.Play();
                    colPlatf.realDamage--;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FObject"))
        {
            objectsEntered++;
            canBePressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("FObject"))
        {
            canBePressed = false;
        }
    }
}
