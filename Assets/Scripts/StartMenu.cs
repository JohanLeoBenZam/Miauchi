using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void PlayNow(string game)
    {
        SceneManager.LoadScene(game);
        Debug.Log("Lo que tu quieras bro");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}