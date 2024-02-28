using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;

   public void PlayAgainFuntion()
    {

        if (GameManager.instance.lastLevel.Equals("Nivel 1"))
        {
            AudioManager.instance.StopLoopedAudio();
            AudioManager.instance.PlayAudioOnLoop(clip1, 1);

        } else if (GameManager.instance.lastLevel.Equals("Nivel 2"))
        {
            AudioManager.instance.StopLoopedAudio();
            AudioManager.instance.PlayAudioOnLoop(clip3, 1);
        }

        SceneManager.LoadScene(GameManager.instance.lastLevel);
    }

    public void BackMenu()
    {
        AudioManager.instance.StopLoopedAudio();
        AudioManager.instance.PlayAudioOnLoop(clip2, 1);

        SceneManager.LoadScene("StartMenu");
    }
}
