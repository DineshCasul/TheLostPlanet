using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class WaveNumber : MonoBehaviour
{
    public int wavenumber = 1;
    Text wave;

    void Start()
    {
        wave = GetComponent<Text>();

    }
    void Update()
    {
        wave.text = "WAVE " + wavenumber.ToString();
    }

}
