using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBlueEnemyProjectile : MonoBehaviour
{

    public float speed;

    private Transform player;
    private Vector2 target;
    public GameObject deathEffect;
    public GameObject PlayerdeathEffect;
    public GameObject ShieldHit;
    private Animator ShieldHitAnim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left* speed * Time.deltaTime);
        Destroy(gameObject, 2f);
    
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           // Destroy(player.gameObject);
            DestroyProjectile();
            Instantiate(PlayerdeathEffect, transform.position, Quaternion.identity);
        }
        if (other.CompareTag("Shield"))
        {
            // Destroy(player.gameObject);
            DestroyProjectile();
            Instantiate(ShieldHit, transform.position, Quaternion.identity);
            
        }

        else  if (other.CompareTag("BoundaryCollider"))
        {
            DestroyAfterScreen();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
        Instantiate(deathEffect, transform.position, Quaternion.identity);

    }
    void DestroyAfterScreen()
    {
        Destroy(this.gameObject);  
    }
    
}