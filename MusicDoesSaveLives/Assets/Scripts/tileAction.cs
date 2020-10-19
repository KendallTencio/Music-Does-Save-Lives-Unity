using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileAction : MonoBehaviour
{
    public GameObject colorCube;
    GameObject cTile;
    GameObject dTile;
    GameObject eTile;
    GameObject fTile;
    GameObject gTile;
    GameObject aTile;
    GameObject bTile;

    void Start()
    {
        cTile = this.gameObject.transform.GetChild(0).gameObject;
        dTile = this.gameObject.transform.GetChild(1).gameObject;
        eTile = this.gameObject.transform.GetChild(2).gameObject;
        fTile = this.gameObject.transform.GetChild(3).gameObject;
        gTile = this.gameObject.transform.GetChild(4).gameObject;
        aTile = this.gameObject.transform.GetChild(5).gameObject;
        bTile = this.gameObject.transform.GetChild(6).gameObject;

        putWhiteColorTiles();
    }

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
        putWhiteColorTiles();
    }

    void putWhiteColorTiles()
    {
        cTile.GetComponent<Renderer>().material.color = Color.white;
        dTile.GetComponent<Renderer>().material.color = Color.white;
        eTile.GetComponent<Renderer>().material.color = Color.white;
        fTile.GetComponent<Renderer>().material.color = Color.white;
        gTile.GetComponent<Renderer>().material.color = Color.white;
        aTile.GetComponent<Renderer>().material.color = Color.white;
        bTile.GetComponent<Renderer>().material.color = Color.white;
    }
}
