using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Transform PlayerShip;
    public float StarRadius;
    public float speed;
    public GameObject starBurst;
    public float stoppingDistance;
   

    // Start is called before the first frame update
    void Start()
    {
        PlayerShip = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, PlayerShip.position) < StarRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerShip.position, speed * Time.deltaTime);
            

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            Destroy(gameObject);
           
            Instantiate(starBurst, PlayerShip.position, Quaternion.identity);
           


        }
    }
}
