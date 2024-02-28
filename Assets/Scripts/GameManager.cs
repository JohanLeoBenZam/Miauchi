using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public void Awake ()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
            //Time.timeScale = 1.0f;
        }
    }   

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
        SceneManager.LoadScene(GameManager.instance.lastLevel);
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
