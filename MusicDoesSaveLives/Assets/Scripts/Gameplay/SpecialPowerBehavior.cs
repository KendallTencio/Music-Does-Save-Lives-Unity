using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPowerBehavior : MonoBehaviour
{
    //SpecialPowerList 
    public Sprite fixedWindow;
    public Sprite colorBarrier;
    public Sprite lightSpeed;
    public Sprite nonePower;

    public SpriteRenderer fwGO;
    public SpriteRenderer cbGO;
    public SpriteRenderer lsGO;

    private bool fixedWindowGained;
    private bool colorBarrierGained;
    private bool lightSpeedGained;

    //DamageManagement
    public GameObject repairingRobot;
    public CollissionPlatformBehavior colPlatf;

    //Shield
    public GameObject shield;

    //Light Speed
    public GameObject lightSpeedGO;
    public MoveGrid mgVaporwave;
    public PlanetBehavior pBehav;

    void Start()
    {
        //repairingRobot = GameObject.FindWithTag("RRobot");
        repairingRobot.SetActive(false);
        shield.SetActive(false);
        lightSpeedGO.SetActive(false);
        fixedWindowGained = false;
        colorBarrierGained = false;
        lightSpeedGained = false;
    }

    void Update()
    {
        
        if (Input.GetKeyDown("c") && fixedWindowGained)
        {
            repairFrontGlass();
        }
        if (Input.GetKeyDown("v") && colorBarrierGained)
        {
            barrierActivated();
        }
        if (Input.GetKeyDown("b") && lightSpeedGained)
        {
            lightSpeedActivated();
        }
    }

    void repairFrontGlass()
    {
        repairingRobot.SetActive(true);
        StartCoroutine(repairForSeconds());
        fixedWindowGained = false;
    }

    private IEnumerator repairForSeconds()
    {
        yield return new WaitForSeconds(2.9f);
        repairingRobot.SetActive(false);
        fwGO.sprite = nonePower;

        colPlatf.realDamage = colPlatf.maxDamage;
    }

    void barrierActivated()
    {
        shield.SetActive(true);
        StartCoroutine(activatedForSeconds());
        colorBarrierGained = false;
    }

    private IEnumerator activatedForSeconds()
    {
        yield return new WaitForSeconds(1f);
        shield.SetActive(false);
        cbGO.sprite = nonePower;
    }

    void lightSpeedActivated()
    {
        lightSpeedGO.SetActive(true);
        mgVaporwave.UpdateScrollSpeed(3f);
        pBehav.expansionRate = 1.01f;
        StartCoroutine(lightActivatedForSeconds());
        lightSpeedGained = false;
    }

    private IEnumerator lightActivatedForSeconds()
    {
        yield return new WaitForSeconds(1.3f);
        mgVaporwave.UpdateScrollSpeed(0.3f);
        lightSpeedGO.SetActive(false);
        lsGO.sprite = nonePower;
        pBehav.expansionRate = pBehav.expansionRateBackup;
    }

    public void lightUpSpecialPower(int numPower)
    {
        if(numPower == 1)
        {
            fwGO.sprite = fixedWindow;
            fixedWindowGained = true;
        }
        else if(numPower == 2)
        {
            cbGO.sprite = colorBarrier;
            colorBarrierGained = true;
        }
        else if (numPower == 3)
        {
            lsGO.sprite = lightSpeed;
            lightSpeedGained = true;
        }
    }
}
