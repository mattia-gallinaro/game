using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gamepaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()//se l'utente preme il tasto Esc 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamepaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()//toglie il panel del menù di pausa e ripristina il tempo in modo che gli oggetti attivi possano tornare a muoversi
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamepaused = false;
    }
    public void Pause()//carica il panel del menù di pausa e imposta il tempo in modo che gli oggetti attivi siano fermi 
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamepaused = true;
    }
    public void LoadMenu()//riporta alla selezione del livello
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SelectLevelMenu");
    }
    public void QuitGame()//chiude il gioco
    {
        Application.Quit();
    }
    
}
