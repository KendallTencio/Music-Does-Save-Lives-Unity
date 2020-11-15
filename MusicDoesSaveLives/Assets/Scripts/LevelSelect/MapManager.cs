using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public Ship Ship;
    public GameObject ShipGO;
    public Pin StartPin;
    public Text SelectedLevelText;

    public SpriteRenderer SRPin1;
    public SpriteRenderer SRPin2;
    public SpriteRenderer SRPin3;

    public Pin Pin1;
    public Pin Pin2;
    public Pin Pin3;

    public Sprite unlocked;

    public DataHolderBehavior dhb;

    void Start()
    {
        setLastPin();
        Ship.Initialise(this, DataHolderBehavior.instance.lastPin);
    }

    void Update()
    {
        // Only check for input when ship is stopped
        if (!Ship.IsMoving)
        {
            CheckForInput();
        }
        manageUnlockedLevels();
    }

    void manageUnlockedLevels()
    {
        foreach (int pin in DataHolderBehavior.instance.unlockedPinList)
        {
            unlockLevel(pin);
        }
    }

    void CheckForInput()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Ship.TrySetDirection(Direction.Up);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Ship.TrySetDirection(Direction.Down);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Ship.TrySetDirection(Direction.Left);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Ship.TrySetDirection(Direction.Right);
        }
    }

    // Update the Text
    public void UpdateGui()
    {
        SelectedLevelText.text = "Current Level: "+ Ship.CurrentPin.pinName;
    }

    public void unlockLevel(int lvl)
    {
        switch (lvl)
        {
            case 2:
                SRPin2.sprite = unlocked;
                break;
            case 3:
                SRPin3.sprite = unlocked;
                break;
            default:
                break;
        }
    }

    void setLastPin()
    {
        switch (DataHolderBehavior.instance.lastPinNumber)
        {
            case 1:
                DataHolderBehavior.instance.lastPin = Pin1;
                break;
            case 2:
                DataHolderBehavior.instance.lastPin = Pin2;
                break;
            case 3:
                DataHolderBehavior.instance.lastPin = Pin3;
                break;
            default:
                break;
        }
    }
}