using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class ScoreUIOnScreen : MonoBehaviour
{
    public static int scoreValue = 0;
     Text Score;
    public Text highScore;
    public Animator highScoreAnim;
    public Animator ScoreAnim;
    private float animDisplayTime = 4f;
    private int highScoreReached = 1;


    void Start()
    {
        Score = GetComponent<Text>();
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        highScoreAnim.enabled = false;
    }

    void Update()
    {
        Score.text = scoreValue.ToString();
        animDisplayTime -= Time.deltaTime;
        if (scoreValue > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", scoreValue);
            highScore.text = scoreValue.ToString();
            highScoreReached = highScoreReached - 1;
            if (highScoreReached == 0)
            {

                highScoreAnim.SetTrigger("HighScore!");
                FindObjectOfType<AudioManager>().Play("HighScore");
            }

            if (animDisplayTime < 0)
            {
                highScoreAnim.enabled = true;
            }
            else
            {
                highScoreAnim.enabled = false;
            }
            
        }
    }
    public void ScoreTextAnimation()
    {
        ScoreAnim.SetTrigger("ScoreHit");
    }
}
