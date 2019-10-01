using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    // Start is called before the first frame update
  public void SettingsOption()
    {
        SceneManager.LoadScene("Settings");
    }

    public void SettingsBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
