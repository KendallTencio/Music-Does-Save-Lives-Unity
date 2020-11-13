using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolderBehavior : MonoBehaviour
{
    public List<int> unlockedPinList = new List<int>();
    public Pin lastPin;
    public int lastPinNumber;

    private static DataHolderBehavior _instance;
    public static DataHolderBehavior instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<DataHolderBehavior>();
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

    // Start is called before the first frame update
    void Start()
    {
        unlockedPinList.Add(1);
    }

    public void UpdateUnlockedPin(int numPin)
    {
        unlockedPinList.Add(numPin);
    }

    public bool isPinUnlocked(int numPin)
    {
        return unlockedPinList.Contains(numPin);
    }
}
