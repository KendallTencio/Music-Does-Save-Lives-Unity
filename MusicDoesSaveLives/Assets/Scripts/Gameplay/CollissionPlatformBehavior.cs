using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollissionPlatformBehavior : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "FObject")
        {
            other.gameObject.SetActive(false);
            Debug.Log("Explosion");
        }
    }
}
