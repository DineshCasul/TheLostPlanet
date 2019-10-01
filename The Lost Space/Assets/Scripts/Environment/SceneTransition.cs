using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    public Animator TransitionAnim;
    public string SceneName;
    public void PlayGame()
    {

        StartCoroutine(LoadScene());

    }
    IEnumerator LoadScene()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        TransitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneName);
        
    }

    public void PlayArcade()
    {
        StartCoroutine(LoadSceneFinal());
    }
    IEnumerator LoadSceneFinal()
    {
        TransitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("TrainingIntro");
    }


}