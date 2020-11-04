using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPowerBehavior : MonoBehaviour
{
    //SpecialPowerList 


    //DamageManagement
    private GameObject repairingRobot;
    public CollissionPlatformBehavior colPlatf;

    void Start()
    {
        repairingRobot = GameObject.FindWithTag("RRobot");
        repairingRobot.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            repairFrontGlass();
        }
    }

    void repairFrontGlass()
    {
        repairingRobot.SetActive(true);
        StartCoroutine(repairForSeconds());
    }

    private IEnumerator repairForSeconds()
    {
        yield return new WaitForSeconds(2.9f);
        repairingRobot.SetActive(false);
        colPlatf.realDamage = colPlatf.maxDamage;
    }
}
