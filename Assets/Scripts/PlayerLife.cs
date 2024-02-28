using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    public AudioClip clip;
    public AudioClip clip2;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }else if (collision.gameObject.CompareTag("meta"))
        {
            ToMenu();
        }
    }

    private void Die()
    {

        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }


    private void ToGameOver()
    {
        
        GameManager.instance.lastLevel = "Nivel 1";
        AudioManager.instance.StopLoopedAudio();
        AudioManager.instance.PlayAudioOnLoop(clip, 1);

        SceneManager.LoadScene("GameOver");
    }
    private void ToMenu()
    {

        AudioManager.instance.StopLoopedAudio();
        AudioManager.instance.PlayAudioOnLoop(clip2, 1);

        LevelController.instance.MoreLevels();
        SceneManager.LoadScene("MapaNiveles");
    }
}
