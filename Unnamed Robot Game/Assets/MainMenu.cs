using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("GamePlay");
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void Credits(){
        SceneManager.LoadScene("Credits");
    }

    public void Menu(){
        SceneManager.LoadScene("Menu");
    }
    
    public void Win(){
        SceneManager.LoadScene("Win");
    }
    
    public void GameOver(){
        SceneManager.LoadScene("GameOver");
    }
}
