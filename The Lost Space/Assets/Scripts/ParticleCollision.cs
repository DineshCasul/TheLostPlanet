using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision: MonoBehaviour
{
    GameObject[] Enemy;
    public GameObject ParticleCollisionDeath;
    public GameObject FloatingTextPrefab;
    void Start()
    {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }
    private void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Enemy"))
        {

            for (int i = 0; i < Enemy.Length; i++)
            {
                Destroy(Enemy[i].gameObject);
                Instantiate(ParticleCollisionDeath, Enemy[i].transform.position, Quaternion.identity);
                ScoreUIOnScreen.scoreValue += 5;
                ScoreUI.scoreValue +=5;
                var go = Instantiate(FloatingTextPrefab, Enemy[i].transform.position, Quaternion.identity);
                go.GetComponent<TextMesh>().text = ScoreUI.scoreValue.ToString();
                GameObject.Destroy(go, 1);
                Handheld.Vibrate();
            }
            
        }
    }

}