using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
   public void PlayAgainFuntion()
    {
        SceneManager.LoadScene(GameManager.instance.lastLevel);
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
