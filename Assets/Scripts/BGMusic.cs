using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    public AudioClip bgMusics;

    private AudioSource bgMusicSource;

    void Start()
    {
        bgMusicSource = AudioManager.instance.PlayAudioOnLoop(bgMusics);
    }

    // Example function to stop the current audio and play a different one
    public void PlayGameOverAudio(AudioClip gameOverClip)
    {
        AudioManager.instance.StopLoopedAudio();
        bgMusicSource = AudioManager.instance.PlayAudioOnLoop(gameOverClip);
    }
}