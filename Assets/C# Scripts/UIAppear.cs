using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIAppear : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] Canvas canvas;
    private bool flag = true;
    private GameMaster gm;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            if (flag)
            {
                gm.memories++;
            }
            print("Working");
            canvas.enabled = true;
            textMeshPro.color = Color.white;
            flag = false;        
            gm.flagAlert = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.enabled = false;
            gm.flagAlert = false;
        }
    }
}
