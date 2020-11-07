using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{
    SpriteRenderer rend;
    // Start is called before the first frame update
    void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    IEnumerator FadeInMethod()
    {
        for(float t = 0.05f; t <= 1; t += 0.03f)
        {
            Color c = rend.material.color;
            c.a = t;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
    {
        startFading();
    }

    public void startFading()
    {
        StartCoroutine("FadeInMethod");
    }
}
