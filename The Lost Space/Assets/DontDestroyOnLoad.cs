using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class DontDestroyOnLoad : MonoBehaviour
    
{
    public GameObject sceneName;
    public static DontDestroyOnLoad instance;
   
    // Start is called before the first frame update
    private void Awake()
    {
       if(instance == null)
        {
            instance = this;
        }
       else
        {
            Destroy(gameObject);
        }
        
            DontDestroyOnLoad(gameObject);
        
        
    }

    private void Update()
    {
        if (SceneManager.sceneCount == 3)
        {
            Destroy(gameObject);
        }
    }
}
