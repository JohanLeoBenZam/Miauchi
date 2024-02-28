using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public AudioClip clip1;
    public AudioClip clip2;

   public void PlayAgainFuntion()
    {
        AudioManager.instance.StopLoopedAudio();
        AudioManager.instance.PlayAudioOnLoop(clip1, 1);

        SceneManager.LoadScene(GameManager.instance.lastLevel);
    }

    public void BackMenu()
    {
        AudioManager.instance.StopLoopedAudio();
        AudioManager.instance.PlayAudioOnLoop(clip2, 1);

        SceneManager.LoadScene("StartMenu");
    }
}
