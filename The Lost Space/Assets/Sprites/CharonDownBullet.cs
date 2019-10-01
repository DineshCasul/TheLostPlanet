using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharonDownBullet : MonoBehaviour
{
    private float speed = 7f;
    public GameObject charonBulletDownBurstEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(charonBulletDownBurstEffect, transform.position, Quaternion.identity);
        }
    }
}
