using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidCollision : MonoBehaviour
{

   public GameObject AstroidDustPrefab;
   private Transform Player;
    public GameObject ShieldHit;



    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
       

    {
       if(collision.CompareTag("BoundaryCollider"))

            {
            Destroy(gameObject);
            }

        else if(collision.CompareTag("Player"))
        {
            Instantiate(AstroidDustPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Shield"))
        {
            // Destroy(player.gameObject);
            Destroy(gameObject);
            Instantiate(AstroidDustPrefab, transform.position, Quaternion.identity);
            Instantiate(ShieldHit, transform.position, Quaternion.identity);
            
        }
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Player.position) < 2.4f)
        {
            Time.timeScale = .3f;
            if (Time.timeScale < 1)
            {
                Time.timeScale += Time.deltaTime;

            }
        }
    }

    void FreezeAstroids()
    {
        
      
    }
}
