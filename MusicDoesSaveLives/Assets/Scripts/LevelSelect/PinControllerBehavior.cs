using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinControllerBehavior : MonoBehaviour
{/*
    public MapManager mm;

    public GameObject Pin1;
    public GameObject Pin2;
    public GameObject Pin3;

    public Pin PinScript1;
    public Pin PinScript2;
    public Pin PinScript3;

    private static PinControllerBehavior _instance;
    public static PinControllerBehavior instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PinControllerBehavior>();
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            //If I am the first instance, make me the Singleton
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (mm.InGameplay)
        {
            Pin1.SetActive(false);
            Pin2.SetActive(false);
            Pin3.SetActive(false);
        }
        else
        {
            Pin1.SetActive(true);
            Pin2.SetActive(true);
            Pin3.SetActive(true);
        }

        pinEnterLevel();
    }

    void pinEnterLevel()
    {
        if (PinScript1.enterLevel || PinScript2.enterLevel || PinScript3.enterLevel)
        {
            mm.InGameplay = true;
            PinScript1.enterLevel = false;
            PinScript2.enterLevel = false;
            PinScript3.enterLevel = false;
        }
    }*/
}
