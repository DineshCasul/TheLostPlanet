using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class AstroidAlert : MonoBehaviour
{
    
    Text wave;
    string[] TextString;
    void Start()
    {
        wave = GetComponent<Text>();
        string[] TextString = new string[]
        {
            "WATCH OUT!",
            "CAREFUL!",
            "DEATH APPROCHING!"
        };
    }
    void Update()
    {
        wave.text = TextString[Random.Range(0, TextString.Length)];
    }

}
