using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public GameObject audioObject1;
   
    public void DropAudio()
    {
        Instantiate(audioObject1, transform.position, transform.rotation);
    }
}
