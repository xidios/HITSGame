using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    private GameMaster gm;
    public Text text;
    // Start is called before the first frame update
    public void Start()
    {        
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        text = GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        gm.time += Time.deltaTime;
        text.text = Mathf.Round(gm.time).ToString();
    }
}
