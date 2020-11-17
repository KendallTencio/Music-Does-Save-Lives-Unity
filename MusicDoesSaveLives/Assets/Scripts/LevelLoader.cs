using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 2f;
    public Text shutDownText;
    public AudioSource spaceHit;
    public string nextScreen;
    public string nameOfScreen;

    void Start()
    {
        if(nameOfScreen.Equals("Credits") || nameOfScreen.Equals("First"))
        {
            bgMusicBehavior.instance.StopMusic();
        }
        else if (nameOfScreen.Equals("Main"))
        {
            bgMusicBehavior.instance.PlayMusic();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if(shutDownText != null)
            {
                shutDownText.gameObject.SetActive(false);
            }
            spaceHit.Play();
            LoadNextLevel();
        }
    }
    public void LoadNextLevel()
    {
        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator loadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(nextScreen);
    }


}
