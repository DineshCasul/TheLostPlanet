using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class PlutoKey : MonoBehaviour
{
    public Animator TransitionAnim;
    public GameObject KeyEffectPrefab;
   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(KeyEffectPrefab, transform.position, Quaternion.identity);
            FindObjectOfType<MissionComplete>().MissionCompleteUI();
            Destroy(gameObject);
           
        }
    }
    
}
