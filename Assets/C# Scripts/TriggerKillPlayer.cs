using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerKillPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerPos player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.Respawn();
        }
    }
}
