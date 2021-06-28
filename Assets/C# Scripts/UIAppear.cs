using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIAppear : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Canvas canvas;
    [SerializeField] string textField;
    [SerializeField] SpriteRenderer sp;
    private bool flag = true;
    private GameMaster gm;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && flag)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            print("Working");
            canvas.enabled = true;
            text.text = textField;
            text.color = Color.white;
            sp.enabled = false;
            flag = false;
            gm.memories++;
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
