using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplodingEnemy : MonoBehaviour
{
    public float speed;
    public float SlowSpeedDistance;
    public float ExplodingDistance;
    public float FastRateDistance;
    public float enemyMovementDistance;
    public float health;
    private float timeBtwShots;
    public float startBtwShots;
    public GameObject HitEffect;
    public GameObject DeathEffect;
    public GameObject ExplosionPrefab;
    public GameObject InitialExplosionPrefab;
    private Animator TextAnim;
    private Transform RightFirePoint;
    private Transform Player;
    private bool facingRight = true;
    public float offset;
    public Animator EnemyFastBoomEffectAnim;
    public GameObject FloatingTextPrefab;
    private CameraShake cameraShake;
    private Vector2 ScorePos;
    private float ScorePosOffset;


    // Start is called before the first frame update
    void Start()
    {
        ScorePosOffset = Random.Range(1, 5);
        ScorePos = new Vector2(transform.position.x, transform.position.y + offset);
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        TextAnim = GameObject.FindGameObjectWithTag("Score").GetComponent<Animator>();
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
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
           
                Destroy(gameObject);
                Instantiate(DeathEffect, transform.position, Quaternion.identity);
                ScoreUIOnScreen.scoreValue += 15;
                ScoreUI.scoreValue += 15;
                //TextAnim.SetTrigger("ScoreHit");
                var go = Instantiate(FloatingTextPrefab, ScorePos, Quaternion.identity);
                go.GetComponent<TextMesh>().text = ScoreUI.scoreValue.ToString();
            GameObject.Destroy(go, 1);
            StartCoroutine(cameraShake.Shake(0.1f, 0.3f));
                Handheld.Vibrate();
            

        }
        if (collision.CompareTag("Player"))

        {
            Destroy(this.gameObject);
            ScoreUIOnScreen.scoreValue += 15;
            ScoreUI.scoreValue += 15;
            var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity);
            go.GetComponent<TextMesh>().text = ScoreUI.scoreValue.ToString();
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            StartCoroutine(cameraShake.Shake(0.1f, 0.2f));
            GameObject.Destroy(go, 1);
            Handheld.Vibrate();
           
        }

        if (collision.CompareTag("Shield"))

        {
            Destroy(this.gameObject);
            ScoreUIOnScreen.scoreValue += 15;
            ScoreUI.scoreValue += 15;
            var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity);
            go.GetComponent<TextMesh>().text = ScoreUI.scoreValue.ToString();
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            GameObject.Destroy(go, 1);


        }
    }
    void InitiatingBullet()
    {
        if (timeBtwShots <= 0)
        {

           // Instantiate(Rightprojectile, RightFirePoint.position, Quaternion.identity);
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

            if (Vector2.Distance(transform.position, Player.position) > SlowSpeedDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
            }
           /* else if (Vector2.Distance(transform.position, Player.position) < SlowSpeedDistance && Vector2.Distance(transform.position, Player.position) > ExplodingDistance)
            {

                transform.position = this.transform.position;
            }*/
            else if (Vector2.Distance(transform.position, Player.position) < FastRateDistance)
            {
                EnemyFastBoomEffectAnim.SetTrigger("Boom!");
                transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime* 7f);
                FindObjectOfType<AudioManager>().Play("TikTokExplosion");
                FindObjectOfType<AudioManagerBoss>().Play("TikTokExplosion");


            }
            if (Vector2.Distance(transform.position, Player.position) < ExplodingDistance)
            {


                Destroy(this.gameObject);
                Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
                
                Rigidbody2D rb = ExplosionPrefab.GetComponent<Rigidbody2D>();
                rb.AddForce(transform.forward *2f);

                Instantiate(InitialExplosionPrefab, transform.position, Quaternion.identity);
                Object.Destroy(InitialExplosionPrefab);

                
            }

            InitiatingBullet();

        }
        
    }

}


