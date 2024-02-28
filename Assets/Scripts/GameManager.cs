using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string lastLevel;

    private void Awake ()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }

        //Time.timeScale = 1f;
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
        Time.timeScale = 1f;
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
}
