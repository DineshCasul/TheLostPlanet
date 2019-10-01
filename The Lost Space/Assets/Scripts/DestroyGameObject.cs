using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        Destroy(GameObject.Find("IntroAudioManager"));
       
    }
}
