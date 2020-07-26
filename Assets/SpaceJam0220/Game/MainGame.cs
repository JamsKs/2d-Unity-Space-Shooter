using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour
{
    public void PlayMenu ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame ()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    bool isPaused = false;

    public void pauseGame()
    {
        if (isPaused) {
            Time.timeScale = 1;
            isPaused = false;
        } else {
            Time.timeScale = 0;
            isPaused = true;
        }
    }
}