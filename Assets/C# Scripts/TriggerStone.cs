using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStone : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] stones;
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {

            foreach (GameObject stone in stones)
            {
                stone.GetComponent<Rigidbody2D>().isKinematic = false;
            }
            print("Stone is coming");
        }
    }
}
