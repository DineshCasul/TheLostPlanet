using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedNonMovableEnemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float enemyMovementDistance;
    public float health;
    private float timeBtwShots;
    private float startBtwShots = .3f;
    public GameObject HitEffect;
    public GameObject DeathEffect;
    public GameObject Leftprojectile;
    public GameObject Rightprojectile;
    private Vector2 ScorePos;
    private float ScorePosOffset;
    public Transform LeftFirePoint;
    public Transform RightFirePoint;
    private GameObject PlayerRedBullet;
    
    private Animator scoreUIScreen;
    private Transform Player;
    public GameObject FloatingTextPrefab;

    private bool facingRight = true;
    public float offset;


    // Start is called before the first frame update
    void Start()
    {
        ScorePosOffset = Random.Range(1, 5);
        ScorePos = new Vector2(transform.position.x, transform.position.y + offset);
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerRedBullet = GameObject.FindGameObjectWithTag("PlayerRedBullet");
        scoreUIScreen = GameObject.FindGameObjectWithTag("Score").GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        {
            Vector3 difference = Player.transform.position - transform.position;

            float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);

        }
       // if (Vector2.Distance(transform.position, Player.position) < enemyMovementDistance)
        {

            if (Vector2.Distance(transform.position, Player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, Player.position) < stoppingDistance && Vector2.Distance(transform.position, Player.position) > retreatDistance)
            {

                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, Player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.position, -speed * Time.deltaTime);
            }

            if (timeBtwShots <= 0)
            {

                InstantiatingBullets();
            }
            else
            {
                timeBtwShots -= Time.deltaTime;

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
                ScoreUI.scoreValue+= 15;
                var go = Instantiate(FloatingTextPrefab, ScorePos, Quaternion.identity);
                go.GetComponent<TextMesh>().text = ScoreUI.scoreValue.ToString();
                GameObject.Destroy(go, 2);

            }

        }
        
    }
    void InstantiatingBullets()
    {
        Instantiate(Leftprojectile, LeftFirePoint.position, Quaternion.identity);
        Instantiate(Rightprojectile, RightFirePoint.position, Quaternion.identity);
        timeBtwShots = startBtwShots;
    }
}


