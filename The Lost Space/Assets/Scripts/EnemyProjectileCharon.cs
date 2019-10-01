using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileCharon : MonoBehaviour
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
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
      
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           
            DestroyProjectile();
            Instantiate(PlayerdeathEffect, transform.position, Quaternion.identity);
        }

        if (other.CompareTag("PlayerRedBullet"))
        {

            DestroyProjectile();
            Instantiate(PlayerdeathEffect, transform.position, Quaternion.identity);
        }
        if (other.CompareTag("Shield"))
        {
            // Destroy(player.gameObject);
            DestroyProjectile();
            Instantiate(ShieldHit, transform.position, Quaternion.identity);
           
        }

    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
        Instantiate(deathEffect, transform.position, Quaternion.identity);

    }

}