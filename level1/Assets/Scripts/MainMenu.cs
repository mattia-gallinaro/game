using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //in base al tasto che preme, carica la scena con il nome specifico

    public void GoToSelectablelevel()
    {
        SceneManager.LoadScene("SelectLevelMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
