using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MissionComplete : MonoBehaviour
{
    public static bool keyIsObtained = false;
    public GameObject MissionCompletedUI;
    public Animator TransitionAnim;
    void Start()
    {
        MissionCompletedUI.SetActive(false);
    }
    void Update()
    {
        TimeFreeze();
    }

    public void MissionCompleteUI()
    {
        MissionCompletedUI.SetActive(true);

        keyIsObtained = true;
    }
    public void ContinueToOutro3()
    {

        MissionCompletedUI.SetActive(false);
        Destroy(FindObjectOfType<AudioManagerBoss>());
        keyIsObtained = false;
        StartCoroutine(NextLevel());
       

    }

    void TimeFreeze()
    {
        if (keyIsObtained == true)
        {
            Time.timeScale = 0.2f;
        }

        if (keyIsObtained == false)
        {
            if (Time.timeScale < 1)
                Time.timeScale += Time.deltaTime;
        }

    }
    IEnumerator NextLevel()
    {
      
        TransitionAnim.SetTrigger("ChangeScene");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Outro2");
       
    }



}
