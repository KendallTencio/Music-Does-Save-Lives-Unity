using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileAction : MonoBehaviour
{
    public GameObject colorCube;
    public GameObject cTile;
    public GameObject dTile;
    public GameObject eTile;
    public GameObject fTile;
    public GameObject gTile;
    public GameObject aTile;
    public GameObject bTile;
    // Use this for initialization
    void Start()
    {
        cTile.GetComponent<Renderer>().material.color = Color.white;
        dTile.GetComponent<Renderer>().material.color = Color.white;
        eTile.GetComponent<Renderer>().material.color = Color.white;
        fTile.GetComponent<Renderer>().material.color = Color.white;
        gTile.GetComponent<Renderer>().material.color = Color.white;
        aTile.GetComponent<Renderer>().material.color = Color.white;
        bTile.GetComponent<Renderer>().material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            cTile.GetComponent<Renderer>().material.color = Color.gray;
            StartCoroutine(cleanTile());
            colorCube.GetComponent<Renderer>().material.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            dTile.GetComponent<Renderer>().material.color = Color.gray;
            StartCoroutine(cleanTile());
            colorCube.GetComponent<Renderer>().material.color = Color.blue;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            eTile.GetComponent<Renderer>().material.color = Color.gray;
            StartCoroutine(cleanTile());
            colorCube.GetComponent<Renderer>().material.color = Color.green;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            fTile.GetComponent<Renderer>().material.color = Color.gray;
            StartCoroutine(cleanTile());
            colorCube.GetComponent<Renderer>().material.color = Color.magenta;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            gTile.GetComponent<Renderer>().material.color = Color.gray;
            StartCoroutine(cleanTile());
            colorCube.GetComponent<Renderer>().material.color = Color.yellow;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            aTile.GetComponent<Renderer>().material.color = Color.gray;
            StartCoroutine(cleanTile());
            colorCube.GetComponent<Renderer>().material.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            bTile.GetComponent<Renderer>().material.color = Color.gray;
            StartCoroutine(cleanTile());
            colorCube.GetComponent<Renderer>().material.color = Color.cyan;
        }
    }

    


    private IEnumerator cleanTile()
    {
        yield return new WaitForSeconds(0.5f);
        cTile.GetComponent<Renderer>().material.color = Color.white;
        dTile.GetComponent<Renderer>().material.color = Color.white;
        eTile.GetComponent<Renderer>().material.color = Color.white;
        fTile.GetComponent<Renderer>().material.color = Color.white;
        gTile.GetComponent<Renderer>().material.color = Color.white;
        aTile.GetComponent<Renderer>().material.color = Color.white;
        bTile.GetComponent<Renderer>().material.color = Color.white;
    }
}
