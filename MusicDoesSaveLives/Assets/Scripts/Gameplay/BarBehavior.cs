using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarBehavior : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode[] keyPressed;
    public AudioSource damageSound;

    //CollissionPlatformBehavior for Damage
    public CollissionPlatformBehavior colPlatf;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < keyPressed.Length; i++)
        {
            if (Input.GetKeyDown(keyPressed[i]))
            {
                if (canBePressed)
                {
                    StartCoroutine(canBePressedOff()); 
                }
                else
                {
                    Debug.Log("Damage with: " + this);
                    damageSound.Play();
                    colPlatf.realDamage--;
                }
            }
        }

    }

    private IEnumerator canBePressedOff()
    {
        yield return new WaitForSeconds(0.35f);
        canBePressed = false;
    }

        private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FObject")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "FObject")
        {
            canBePressed = false;
        }
    }
}
