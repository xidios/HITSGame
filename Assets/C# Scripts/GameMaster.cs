using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public  GameObject gameCanvas;
    public Vector2 lastCheckPointPos;
    public float time = 0;
    public int memories = 0;
    public Text textTime;
    public Text textMemories;

    public GameObject[] alertPoints;
    public GameObject alertWindow;
    private void Awake()
    {
        if (instance == null)
        {            
            instance = this;
            
            DontDestroyOnLoad(instance);
            DontDestroyOnLoad(gameCanvas);
            DontDestroyOnLoad(alertWindow);
            foreach (var al in alertPoints)
            {
                DontDestroyOnLoad(al);
            }
        }
        else
        {
            Destroy(gameObject);
            Destroy(gameCanvas);
            foreach (var al in alertPoints)
            {
                Destroy(al);
            }
        }

                
    }

    void Update()
    {
        time += Time.deltaTime;
        System.TimeSpan timer = System.TimeSpan.FromSeconds(time);
        textTime.text = timer.ToString("mm':'ss");
        textMemories.text = $"{memories} / 5";
    }
}
