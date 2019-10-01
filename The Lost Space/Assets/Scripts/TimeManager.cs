using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale < 1)
        {
            Time.timeScale += 4 * Time.deltaTime;
        }
    }
    public void DoFreeze()
    {
        Time.timeScale = 0f;
    }
    public void DofreezeLess()
    {
        Time.timeScale = 0.5f;
    }
}
