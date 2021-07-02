using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forestSound : MonoBehaviour
{
    public GameObject audioTrigger;
    public AudioClip music;
    private AudioSource musicAudio;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")|| other.CompareTag("Main Camera"))
        {
            musicAudio.PlayOneShot(music);
        }
    }


    /*void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider>().CompareTag("Player"))
        {
            GetComponent<AudioSource>().clip = music;
            GetComponent<AudioSource>().Play();
            
        }
    }*/
}
