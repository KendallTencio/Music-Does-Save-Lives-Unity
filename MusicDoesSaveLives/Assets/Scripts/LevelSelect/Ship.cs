using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float ShipSpeed = 5f;
    public bool IsMoving { get; private set; }
    public Pin CurrentPin { get; private set; }
    public SpriteRenderer ShipSR;
    private Pin _targetPin;
    private MapManager _mapManager;

    public void Initialise(MapManager mapManager, Pin startPin)
    {
        _mapManager = mapManager;
        SetCurrentPin(startPin);
    }

    void Start()
    {
        ShipSR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (_targetPin != null)
        {
            var currentPosition = transform.position;
            var targetPosition = _targetPin.transform.position;

            // If the character isn't that close to the target move closer
            if (Vector3.Distance(currentPosition, targetPosition) > .02f)
            {
                transform.position = Vector3.MoveTowards(currentPosition, targetPosition, Time.deltaTime * ShipSpeed);
            }
            else
            {
                if (_targetPin.IsAutomatic)
                {
                    // Get a direction to keep moving in
                    var pin = _targetPin.GetNextPin(CurrentPin);
                    MoveToPin(pin);
                }
                else
                {
                    SetCurrentPin(_targetPin);
                }
            }
        }
    }

    // Check the if the current pin has a reference to another in a direction
    // If it does the move there
    public void TrySetDirection(Direction direction)
    {
        var pin = CurrentPin.GetPinInDirection(direction);

        // If there is a pin then move to it
        if (pin != null)
        {
            MoveToPin(pin);
        }
    }

    void MoveToPin(Pin pin)
    {
        if(CurrentPin.pinNumber > pin.pinNumber)
        {
            ShipSR.flipX = true;
        }
        else
        {
            ShipSR.flipX = false;
        }
        _targetPin = pin;
        IsMoving = true;
    }

    public void SetCurrentPin(Pin pin)
    {
        CurrentPin = pin;
        _targetPin = null;
        transform.position = pin.transform.position;
        IsMoving = false;

        // Tell the map manager that the current pin has changed
        _mapManager.UpdateGui();
    }
}
