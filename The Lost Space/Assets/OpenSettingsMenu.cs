using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenSettingsMenu : MonoBehaviour
{
    public static bool isSettingsOpen = false;
    public GameObject SettingsMenuGUI;

    void Start()
    {
        SettingsMenuGUI.SetActive(false);
    }
    void Update()
    {
        TimeFreeze();
    }

    public void Back()
    {
        SettingsMenuGUI.SetActive(false);

        isSettingsOpen = false;
    }

    public void Settings()
    {
        SettingsMenuGUI.SetActive(true);

        isSettingsOpen = true;
    }

  

    void TimeFreeze()
    {
        if (isSettingsOpen)
        {
            Time.timeScale = 0.2f;
        }
        else
        if (!isSettingsOpen)
        {
            if (Time.timeScale < 1)
                Time.timeScale += Time.deltaTime;
        }

    }
}
