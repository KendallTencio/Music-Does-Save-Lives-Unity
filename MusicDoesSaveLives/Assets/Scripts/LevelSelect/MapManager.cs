using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public Ship Ship;
    public Pin StartPin;
    public Text SelectedLevelText;

    private void Start()
    {
        // Pass a ref and default the player Starting Pin
        Ship.Initialise(this, StartPin);
    }

    private void Update()
    {
        // Only check input when character is stopped
        if (Ship.IsMoving)
        {
            return;
        }

        // First thing to do is try get the player input
        CheckForInput();
    }

    // Check if the player has pressed a button
    private void CheckForInput()
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
        SelectedLevelText.text = string.Format("Current Level: {0}", Ship.CurrentPin);
    }
}