using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public AudioClip clip;


    public void SelectLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void ChangeMusic()
    {
        AudioManager.instance.StopLoopedAudio();
        AudioManager.instance.PlayAudioOnLoop(clip, 1);
    }
}
