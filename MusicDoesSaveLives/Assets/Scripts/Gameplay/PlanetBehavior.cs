using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehavior : MonoBehaviour
{
    public float expansionRate;
    public Transform planetTransform;

    public float expansionRateBackup;
    private Vector3 scaleChange;
    private float xPlanet;
    private float yPlanet;
    private float zPlanet;

    void Start()
    {
        expansionRateBackup = expansionRate;
        StartCoroutine(GrowthCoroutine());
    }

    IEnumerator GrowthCoroutine()
    {
        while (true)
        {
            xPlanet = planetTransform.localScale.x;
            yPlanet = planetTransform.localScale.y;
            zPlanet = planetTransform.localScale.z;
            scaleChange = new Vector3(xPlanet * expansionRate, yPlanet * expansionRate, zPlanet * expansionRate);

            planetTransform.localScale = scaleChange;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
