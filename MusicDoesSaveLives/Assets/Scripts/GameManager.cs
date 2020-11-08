using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioSource bgMusic;
    public bool startPlaying;
    public BeatScroller bs;

    //Text
    public Text scoreText;
    public Text multiText;

    //Score
    public int currentScore;
    public int scorePerNote = 100;

    //Multiplier 
    private int notesCounter = 0;
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    //DamageManagement
    public CollissionPlatformBehavior colPlatf;
    public GameObject brokenGlass1;
    public GameObject brokenGlass2;

    //SpecialPower
    public SpecialPowerBehavior spb;

    //GameOver Screen
    public GameObject gameOverScreen;
    private bool gameEnded;

    //Level Ended Screen
    public GameObject levelEndedScreen;

    void Start()
    {
        instance = this;

        scoreText.text = "Lives saved: 0";
        currentMultiplier = 1;

        gameOverScreen.SetActive(false);
        levelEndedScreen.SetActive(false);

        if(bgMusicBehavior.instance != null)
        {
            bgMusicBehavior.instance.StopMusic();
        }
        
    }

    void Update(){
        if (!startPlaying)
        {
            if (Input.GetKeyDown("space"))
            {
                startPlaying = true;
                bs.hasStarted = true;

                bgMusic.Play();
            }
        }
        checkShipDamageStatus();

        if (gameEnded)
        {
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene("GameplayScreen");
            }
            if (Input.GetKeyDown("return"))
            {
                SceneManager.LoadScene("TextScreen");
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit On Time");
        multiplierTracker++;
        notesCounter++;

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            if(multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        if(notesCounter == 2)
        {
            spb.lightUpSpecialPower(1);
        }
        else if (notesCounter == 5)
        {
            spb.lightUpSpecialPower(2);
        }
        else if (notesCounter == 8)
        {
            spb.lightUpSpecialPower(3);
        }

        multiText.text = "Multiplier: x" + currentMultiplier;

        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Lives saved: " + currentScore;
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");

        currentMultiplier = 1;
        multiplierTracker = 0;
        multiText.text = "Multiplier: x" + currentMultiplier;
    }

    public void endLevel()  //Hay que mejorarla, está provicional
    {
        levelEndedScreen.SetActive(true);
        gameEnded = true; 
    }

    void checkShipDamageStatus()
    {
        if (colPlatf.realDamage == colPlatf.maxDamage)
        {
            brokenGlass1.SetActive(false);
            brokenGlass2.SetActive(false);
        }
        else if (colPlatf.realDamage == 2)
        {
            brokenGlass1.SetActive(true);
        }
        else if (colPlatf.realDamage == 1)
        {
            brokenGlass1.SetActive(false);
            brokenGlass2.SetActive(true);
        }
        else if(colPlatf.realDamage == 0)
        {
            bs.hasStarted = false;
            bgMusic.Stop();
            gameOverScreen.SetActive(true);
            gameEnded = true;
            Debug.Log("So you have chosen death...");
        }
    }
}
