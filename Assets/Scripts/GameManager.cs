using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public string lastLevel;

    public void PlayNow(string game)
    {
        SceneManager.LoadScene(game);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayAgain(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void BackMenu(string menu)
    {
        SceneManager.LoadScene(menu);
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
}
