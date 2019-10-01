using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourWayEnemyShooting : MonoBehaviour
{
    public GameObject[] FourWayBullets;
    public Transform[] firePoints;
    private float timeBtwBullets = 1f;
    private float speed;
    private float health = 5;
    public GameObject HitEffect;
    public GameObject DeathEffect;
    private Animator scoreUIScreen;
    public GameObject FloatingTextPrefab;

    

    void Start()
    {
        scoreUIScreen = GameObject.FindGameObjectWithTag("Score").GetComponent<Animator>();
    }


    void Update()
    {
        timeBtwBullets -= Time.deltaTime;
        InstantiateBullets();
    }

    void InstantiateBullets()
    {
        if (timeBtwBullets < 0f)
        {
            for (int i = 0; i < firePoints.Length; i++)
            {
                Instantiate(FourWayBullets[i], firePoints[i].position, Quaternion.identity);
                timeBtwBullets = 1.5f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerRedBullet"))

        {
            if (health > 0)
            {
                health = health - 10;

                Instantiate(HitEffect, transform.position, Quaternion.identity);

            }
            else
            {

                Destroy(gameObject);
                Instantiate(DeathEffect, transform.position, Quaternion.identity);
                ScoreUIOnScreen.scoreValue += 15;

                //scoreUIScreen.SetTrigger("ScoreHit");

                ScoreUI.scoreValue += 15;
                var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity);
                go.GetComponent<TextMesh>().text = ScoreUI.scoreValue.ToString();
                GameObject.Destroy(go, 1);







            }

        }


    }

}