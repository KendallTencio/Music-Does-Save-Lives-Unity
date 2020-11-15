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
                if(specialPowerCarried != 0)
                {
                    getSpecialPower();
                }
                gameObject.SetActive(false);
                GameManager.instance.NoteHit();

                if (isLastNote)
                {
                    GameManager.instance.endLevel();
                    spb.lightSpeedActivated();
                }
            }
        }
    }

    void getSpecialPower()
    {
        if (specialPowerCarried == 1)
        {
            GameManager.instance.powerActivationThunder(1);
            spb.lightUpSpecialPower(1);
        }
        else if (specialPowerCarried == 2)
        {
            GameManager.instance.powerActivationThunder(2);
            spb.lightUpSpecialPower(2);
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
            if (isLastNote)
            {
                GameManager.instance.endLevel();
                spb.lightSpeedActivated();
            }
        }
    }
}
