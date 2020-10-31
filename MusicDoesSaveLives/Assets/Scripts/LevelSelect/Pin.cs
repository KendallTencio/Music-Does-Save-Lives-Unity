using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class Pin : MonoBehaviour
{
    public bool IsAutomatic;
    public string SceneName;

    public Pin UpPin;
    public Pin DownPin;
    public Pin LeftPin;
    public Pin RightPin;

    private Dictionary<Direction, Pin> _pinDirections;

    void Start()
    {
        // Load the directions into a dictionary for easy access
        _pinDirections = new Dictionary<Direction, Pin>
        {
            { Direction.Up, UpPin },
            { Direction.Down, DownPin },
            { Direction.Left, LeftPin },
            { Direction.Right, RightPin }
        };
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            EnterLevel();
        }
    }

    // Get the pin in a selected direction
     // Using a switch statement rather than linq so this can run in the editor
    public Pin GetPinInDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return UpPin;
            case Direction.Down:
                return DownPin;
            case Direction.Left:
                return LeftPin;
            case Direction.Right:
                return RightPin;
            default:
                throw new ArgumentOutOfRangeException("direction", direction, null);
        }
    }

    // This gets the first pin thats not the one passed 
    public Pin GetNextPin(Pin pin)
    {
        return _pinDirections.FirstOrDefault(x => x.Value != null && x.Value != pin).Value;
    }


    // Draw lines between connected pins
    void OnDrawGizmos()
    {
        if (UpPin != null) DrawLine(UpPin);
        if (RightPin != null) DrawLine(RightPin);
        if (DownPin != null) DrawLine(DownPin);
        if (LeftPin != null) DrawLine(LeftPin);
    }

    // Draw one pin line
    protected void DrawLine(Pin pin)
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, pin.transform.position);
    }

    void EnterLevel()
    {
        SceneManager.LoadScene(SceneName);
    }
}