using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public static bool playerIsDead = false;
    public GameObject GameOverMenuGUI;

    void Start()
    {
        GameOverMenuGUI.SetActive(false);
    }
    void Update()
    {
        TimeFreeze();
    }

    public void GameOver()
    {
        GameOverMenuGUI.SetActive(true);

        playerIsDead = true;
    }
    public void Restart()
    {
       
        GameOverMenuGUI.SetActive(false);
        Destroy(FindObjectOfType<AudioManagerBoss>());
        SceneManager.LoadScene("TrainingIntro");
        
        playerIsDead = false;

    }

    void TimeFreeze()
    {
        if (playerIsDead == true)
        {
            Time.timeScale = 0.2f;
        }
        
        if (playerIsDead == false)
        {
            if (Time.timeScale < 1)
                Time.timeScale += Time.deltaTime;
        }

    }
    public void Leave()
    {
        GameOverMenuGUI.SetActive(false);
        Destroy(FindObjectOfType<AudioManagerBoss>());
        SceneManager.LoadScene("MainMenu");
    }

    
}
