using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public AudioClip clip;
    public AudioClip clip2;


    public void SelectLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void ChangeMusic()
    {
        AudioManager.instance.StopLoopedAudio();
        AudioManager.instance.PlayAudioOnLoop(clip, 1);
    }

    public void ChangeMusic2()
    {
        AudioManager.instance.StopLoopedAudio();
        AudioManager.instance.PlayAudioOnLoop(clip2, 1);
    }
}
