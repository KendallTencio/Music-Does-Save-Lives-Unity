using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int currentLevel;

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
    public Text hudShipStateText;

    //SpecialPower
    public SpecialPowerBehavior spb;

    //GameOver Screen
    public GameObject gameOverScreen;
    private bool gameOver = false;

    //Level Ended Screen
    public GameObject levelEndedScreen;
    public GameObject endLevelMusic;
    public GameObject endingCanvas;
    public Text livesSavedTotalText;
    public AudioSource spaceHit;
    private bool gameEnded;

    //Screen Elements
    public GameObject HUD;
    public GameObject Detector;
    public GameObject distantObject;
    public GameObject glass;

    void Start()
    {
        instance = this;

        scoreText.text = "Lives saved: 0";
        currentMultiplier = 1;

        gameOverScreen.SetActive(false);
        levelEndedScreen.SetActive(false);
        endingCanvas.SetActive(false);

        if (bgMusicBehavior.instance != null)
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

        if (gameOver)
        {
            if (Input.GetKeyDown("space"))
            {
                spaceHit.Play();
                SceneManager.LoadScene("GameplayScreen");
            }
            if (Input.GetKeyDown("backspace"))
            {
                spaceHit.Play();
                SceneManager.LoadScene("TextScreen");
            }
        }

        if (gameEnded)
        {
            if (Input.GetKeyDown("space"))
            {
                spaceHit.Play();
                switch (currentLevel)
                {
                    case 1:
                        Debug.Log("Level 2 Unlocked");
                        DataHolderBehavior.instance.UpdateUnlockedPin(2);
                        break;
                    case 2:
                        Debug.Log("Level 3 Unlocked");
                        DataHolderBehavior.instance.UpdateUnlockedPin(3);
                        break;
                    case 3:
                        //Ending
                        break;
                    default:
                        break;
                }

                SceneManager.LoadScene("LevelSelectScreen");
            }

            if (Input.GetKeyDown("backspace"))
            {
                spaceHit.Play();
                SceneManager.LoadScene("GameplayScreen"); //Esto debe ser para repetir el respectivo nivel
            }

            //Se apaga toda la interfaz
            hudShipStateText.gameObject.SetActive(false);
            HUD.SetActive(false);
            Detector.SetActive(false);
            distantObject.SetActive(false);
            glass.SetActive(false);

            bgMusic.Stop();
            endLevelMusic.SetActive(true);
        }

        if (!gameOver)
        {
            checkShipDamageStatus();
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

    public void endLevel()  //Se puede mejorar, está provicional
    {
        gameEnded = true;
        StartCoroutine(canvaForSeconds());
    }

    private IEnumerator canvaForSeconds()
    {
        endingCanvas.SetActive(true); //Efecto hecho de forma "cutre" para resultados de nivel
        yield return new WaitForSeconds(0.3f);
        endingCanvas.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        endingCanvas.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        endingCanvas.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        endingCanvas.SetActive(true);
        livesSavedTotalText.text = "Lives saved: " + currentScore;
    }

    void checkShipDamageStatus()
    {
        hudShipStateText.text = colPlatf.realDamage + " hits left";
        if (colPlatf.realDamage == colPlatf.maxDamage)
        {
            brokenGlass1.SetActive(false);
            brokenGlass2.SetActive(false);
        }
        else if (colPlatf.realDamage == 4)
        {
            brokenGlass1.SetActive(true);
        }
        else if (colPlatf.realDamage == 2)
        {
            brokenGlass1.SetActive(false);
            brokenGlass2.SetActive(true);
        }
        else if (colPlatf.realDamage == 1)
        {
            brokenGlass1.SetActive(false);
            brokenGlass2.SetActive(true);
        }
        else if (colPlatf.realDamage <= 0)
        {
            bs.hasStarted = false;
            bgMusic.Stop();
            gameOverScreen.SetActive(true);
            gameOver = true;
            hudShipStateText.text = "";
            Debug.Log("Death!");
        }
    }
}
