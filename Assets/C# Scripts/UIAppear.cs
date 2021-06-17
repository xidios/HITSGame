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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            print("Working");
            canvas.enabled = true;
            text.text = textField;
            text.color = Color.white;
            
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.enabled = false;
        }
    }
}
