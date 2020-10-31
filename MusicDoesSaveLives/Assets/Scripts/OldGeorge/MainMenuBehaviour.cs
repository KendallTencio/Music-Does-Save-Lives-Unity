using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //transiciones de nivel
public class MainMenuBehaviour : MonoBehaviour
{
    GameObject ship;
    
    
    public void LoadLevel(string levelName){
        //PauseMenuBehaviour.isPaused = false;
        SceneManager.LoadScene(levelName); //le decimos al manejador que cargue la escena 
       
    }
    public void EndGame(){
    #if (UNITY_EDITOR)
            UnityEditor.EditorApplication.isPlaying = false;           
    #else
        Application.Quit();
    #endif
        
    }
}
