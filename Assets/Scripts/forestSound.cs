using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forestSound : MonoBehaviour
{
    public GameObject audioTrigger;
    public AudioSource musicAudio;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("MainCamera"))
        {
            print("Sound");
            musicAudio.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("MainCamera"))
        {
            print("Sound");
            musicAudio.Stop();
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
