using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused =  false;
    public GameObject PauseMenuGUI;

    void Start()
    {
        PauseMenuGUI.SetActive(false);   
    }
    void Update()
    {
        TimeFreeze();
    }

    public void Resume()
    {
        PauseMenuGUI.SetActive(false);
       
        GameIsPaused = false ;
    }

   public void Pause()
    {
        PauseMenuGUI.SetActive(true);
       
        GameIsPaused = true;
    }

    void TimeFreeze()
    {
        if (GameIsPaused)
        {
            Time.timeScale = 0.2f;
        }
        else
        if(!GameIsPaused)
        {
            if(Time.timeScale <1)
            Time.timeScale += Time.deltaTime;
        }
        
    }
}
