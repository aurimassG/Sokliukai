using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public AudioSource audio1;
    public void StartGame()
    {
        audio1.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        audio1.Play();
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
