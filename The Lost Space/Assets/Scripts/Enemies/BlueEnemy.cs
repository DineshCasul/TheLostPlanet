using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueEnemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float enemyMovementDistance;
    public float health;
    private float timeBtwShots;
    public float startBtwShots;
    public GameObject HitEffect;
    public GameObject DeathEffect;
    public GameObject Leftprojectile;
    public GameObject Rightprojectile;
    private ScoreUIOnScreen TextAnim;
    public Animator CameraRedHitAnim;
    public GameObject FloatingTextPrefab;

    private Animator scoreUIScreen;
    public Transform RightFirePoint;
    
    public Transform Player;
    private bool facingRight = true;
    public float offset;


    // Start is called before the first frame update
    void Start()
    {


        Player = GameObject.FindGameObjectWithTag("Player").transform;
        scoreUIScreen = GameObject.FindGameObjectWithTag("Score").GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {

        {
            Vector3 difference = Player.transform.position - transform.position;

            float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);

            MovingEnemytoTarget();

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
                
                scoreUIScreen.SetTrigger("ScoreHit");

                ScoreUI.scoreValue += 15;
                var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity);
                go.GetComponent<TextMesh>().text = ScoreUI.scoreValue.ToString();
              
                CameraRedHitAnim.SetTrigger("PlayerHitEnemy");
                Handheld.Vibrate();
                GameObject.Destroy(go, 1);




            }

        }
        /*if (collision.CompareTag("PlayerBlueBullet"))

        {
            if (health > 0)
            {
                health = health + 10;

                Instantiate(HitEffect, transform.position, Quaternion.identity);

            }
        }*/
    }
    void InitiatingBullet()
    {
        if (timeBtwShots <= 0)
        {


            Instantiate(Rightprojectile, RightFirePoint.position, Quaternion.identity);
            timeBtwShots = startBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;

        }
    }
    void MovingEnemytoTarget()
    {
        if (Vector2.Distance(transform.position, Player.position) < enemyMovementDistance)
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



            InitiatingBullet();

        }
    }
        
}


    