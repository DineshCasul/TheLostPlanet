using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class ScoreUI : MonoBehaviour
{
    public static int scoreValue = 0;
    TextMesh Score;


    void Start()
    {
         Score = GameObject.FindGameObjectWithTag("Ui").GetComponent<TextMesh>();
    }
        void Update()
    {
        Score.text = scoreValue.ToString();
    }

}
