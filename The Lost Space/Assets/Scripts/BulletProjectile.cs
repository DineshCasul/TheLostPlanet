using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BulletProjectile : MonoBehaviour

{

    public float speed;
    public GameObject CircleBurstHit;
    private Animator CharonHit;
    public float TimeToLive = 1f;




    void Start()
    {
        Destroy(gameObject, TimeToLive);
        CharonHit = GameObject.FindGameObjectWithTag("Charon").GetComponent<Animator>();
    }
    private void Update()
    {

        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            var CircleBurst =  Instantiate(CircleBurstHit, transform.position, Quaternion.identity);
            GameObject.Destroy(CircleBurst, 1f);
        }
       

        if (collision.CompareTag("Charon"))
        {
            CharonHit.SetTrigger("HitTaken");
            Destroy(gameObject);
            var CircleBurst2 = Instantiate(CircleBurstHit, transform.position, Quaternion.identity);
            GameObject.Destroy(CircleBurst2, 1f);
            
        }
        else if (collision.CompareTag("BoundaryCollider"))
        {
            DestroyAfterScreen();
        }
    }
    void DestroyAfterScreen()
    {
        Destroy(this.gameObject);
    }




}


