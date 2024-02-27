using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static public AudioManager instance;
    private GameObject currentAudioOnLoop;

    private AudioSource loopedAudioSource;

    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // volume: [0, 1]

    public AudioSource PlayAudio(AudioClip clip, float volume = 1)
    {
        GameObject sourceObj = new GameObject(clip.name);
        sourceObj.transform.SetParent(this.transform);
        AudioSource source = sourceObj.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.Play();
        StartCoroutine(PlayAudio(source));
        return source;
    }

    public AudioSource PlayAudio3D(AudioClip clip, Vector3 position, float volume = 1)
    {
        AudioSource source = PlayAudio(clip, volume);
        source.spatialBlend = 1;
        source.gameObject.transform.position = position;
        return source;
    }

    public AudioSource PlayAudioOnLoop(AudioClip clip, float volume = 1)
    {
        if (currentAudioOnLoop)
        {
            Destroy(currentAudioOnLoop);
        }
        GameObject sourceObj = new GameObject(clip.name);
        sourceObj.transform.SetParent(this.transform);
        loopedAudioSource = sourceObj.AddComponent<AudioSource>();
        loopedAudioSource.clip = clip;
        loopedAudioSource.volume = volume;
        loopedAudioSource.loop = true;
        loopedAudioSource.Play();
        currentAudioOnLoop = sourceObj;
        return loopedAudioSource;
    }

    public void StopLoopedAudio()
    {
        if (loopedAudioSource != null)
        {
            loopedAudioSource.Stop();
            Destroy(loopedAudioSource.gameObject);
            loopedAudioSource = null;
        }
    }

    IEnumerator PlayAudio(AudioSource source)
    {
        while (source && source.isPlaying)
        {
            yield return null;
        }

        if (source)
        {
            Destroy(source.gameObject);
        }
    }
}