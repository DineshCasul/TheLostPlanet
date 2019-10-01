using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackNonMovableEnemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float enemyMovementDistance;
    public float health;
    private float timeBtwShots;
    private float startBtwShots = .7f;
    public GameObject HitEffect;
   
    public GameObject Leftprojectile;
    public GameObject Rightprojectile;
    public GameObject UpProjectile;
    public GameObject DownProjectile;

    public Transform LeftFirePoint;
    public Transform RightFirePoint;
    public Transform LeftFirePoint2;
    public Transform RightFirePoint2;
    
    private GameObject PlayerRedBullet;
    private Animator CameraRedHitAnim;
    private Animator scoreUIScreen;
    private Transform Player;
    public GameObject FloatingTextPrefab;
    public GameObject DeathEffect;

    private bool facingRight = true;
    public float offset;


    // Start is called before the first frame update
    void Start()
    {

        Player = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerRedBullet = GameObject.FindGameObjectWithTag("PlayerRedBullet");
        CameraRedHitAnim = GameObject.FindGameObjectWithTag("Background").GetComponent<Animator>();
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
                var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity);
                go.GetComponent<TextMesh>().text = ScoreUI.scoreValue.ToString();
                //wscoreUIScreen.SetTrigger("ScoreHit");
                CameraRedHitAnim.SetTrigger("PlayerHitEnemy");
                GameObject.Destroy(go, 1);
                Handheld.Vibrate();

            }

        }
        
    }
    void InstantiatingBullets()
    {
        Instantiate(Leftprojectile, LeftFirePoint.position, Quaternion.identity);
        Instantiate(Rightprojectile, RightFirePoint.position, Quaternion.identity);
        Instantiate(UpProjectile, LeftFirePoint2.position, Quaternion.identity);
        Instantiate(DownProjectile, RightFirePoint2.position, Quaternion.identity);
        timeBtwShots = startBtwShots;
    }
}


