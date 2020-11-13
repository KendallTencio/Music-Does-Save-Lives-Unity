using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectBehavior : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyPressed;
    public bool isLastNote = false;

    //SpecialPower
    public SpecialPowerBehavior spb;
    public int specialPowerCarried = 0;

    //CollissionPlatformBehavior for Damage
    public CollissionPlatformBehavior colPlatf;

    void Update()
    {
        if (Input.GetKeyDown(keyPressed))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);
                GameManager.instance.NoteHit();

                if(specialPowerCarried != 0)
                {
                    getSpecialPower();
                }
                
                if (isLastNote)
                {
                    GameManager.instance.endLevel();
                    spb.lightSpeedActivated();
                }
            }
            else{
                //Debug.Log("Damage with: " + (colPlatf.realDamage - 1));
                //colPlatf.realDamage--;
            }
        }
    }

    void getSpecialPower()
    {
        if (specialPowerCarried == 1)
        {
            spb.lightUpSpecialPower(1);
        }
        else if (specialPowerCarried == 2)
        {
            spb.lightUpSpecialPower(2);
        }
        else if (specialPowerCarried == 3)
        {
            spb.lightUpSpecialPower(3);
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
