using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public GameObject gameCanvas;
    public Vector2 lastCheckPointPos;
    public float time = 0;
    public int memories = 0;
    public Text textTime;
    public Text textMemories;
    public bool flagAlert = false;
    public GameObject alertPoints;
    public GameObject alertWindow;
    public Canvas alertEndFast;
    public Canvas alertEndSlow;
    public Canvas alertBetween;
    public bool timerEnable = true;
    public AudioSource PerelomKostey;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(instance);
            DontDestroyOnLoad(gameCanvas);
            DontDestroyOnLoad(alertWindow);

            DontDestroyOnLoad(alertPoints);

        }
        else
        {
            Destroy(gameObject);
            Destroy(gameCanvas);

            Destroy(alertPoints);

        }


    }

    void Update()
    {
        if (timerEnable && !flagAlert)
        {
            time += Time.deltaTime;
            System.TimeSpan timer = System.TimeSpan.FromSeconds(time);
            textTime.text = timer.ToString("mm':'ss");
            textMemories.text = $"{memories} / 4";
        }
        if (memories == 4)
        {
            timerEnable = false;
            if (!flagAlert)
            {
                Time.timeScale = 0f;
                if (time <= 300)
                {
                    EndFast();
                }
                else if (time > 420)
                {
                    EndSlow();
                }
                else if (time > 300 && time <= 420)
                {
                    alertBetween.enabled = true;
                }
            }
        }
        else
        {
            alertBetween.enabled = false;
            alertEndFast.enabled = false;
            alertEndSlow.enabled = false;
        }
    }
    public void SetNull()
    {

    }
    public void EndFast()
    {
        alertEndFast.enabled = true;
    }
    public void EndSlow()
    {
        alertEndSlow.enabled = true;
    }
    public void RestartGame()
    {
        time = 0;
        memories = 0;
        timerEnable = true;
        Destroy(instance);
    }
    public void PerelomKosteySound()
    {
        PerelomKostey.Play();
    }
}
