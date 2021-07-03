using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandApperTigger : MonoBehaviour
{
    public string nameTrigger;
    public GameObject hand;

    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            print("Hand appear");
            hand.GetComponent<Animator>().SetTrigger(nameTrigger);
        }
    }
}
