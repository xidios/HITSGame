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
    private void Awake()
    {
        if (instance == null)
        {            
            instance = this;
            
            DontDestroyOnLoad(instance);
            DontDestroyOnLoad(gameCanvas);
        }
        else
        {
            Destroy(gameObject);
            Destroy(gameCanvas);
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
