using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    private bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameMaster gm;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void BackToMenu()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        gm.RestartGame();
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);        
    }
    public void QuitGame()
    {
        print("See you space cowboy");
        Application.Quit();
    }
}
