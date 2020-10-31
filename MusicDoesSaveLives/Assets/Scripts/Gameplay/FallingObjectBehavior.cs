using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectBehavior : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyPressed;

    void Update()
    {
        if (Input.GetKeyDown(keyPressed))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);
                GameManager.instance.NoteHit();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Detector")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.tag == "Detector")
        {
            canBePressed = false;
            GameManager.instance.NoteMissed();
        }
    }
}
