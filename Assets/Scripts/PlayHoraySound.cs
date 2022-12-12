using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHoraySound : MonoBehaviour
{
    // Start is called before the first frame update
    //public AudioClip HoraySound;
    AudioSource audio;

    void Start()
    {
    audio = GetComponent<AudioSource>();
    //Debug.Log("Area To Play Sound reached");
    }

    void onTriggerEnter()
    {
        Debug.Log("Area To Play Sound reached");
        audio.PlayOneShot(audio.clip,10f);
    }
}
