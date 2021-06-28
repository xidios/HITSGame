using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameMaster gm;
    public void PlayGame()
    {
        gm= GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        gm.SetNull();
        gm.timerEnable = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
