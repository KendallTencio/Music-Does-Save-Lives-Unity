using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform Target;

    void Start()
    {
        Target = GameObject.FindWithTag("PlayerShip").transform;
    }

    void Update()
    {
        transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y, transform.position.z);
    }
}