using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public GameObject hitEffect;
    private float playerHealth = 100f;
    public bool isDead;
    public GameObject BlueEnemyProjectile;
    public GameObject RedEnemyProjectile;
    public GameObject RedEnemyProjectileTwo;
    public Animator HitRedAnim;
    public Slider healthbar;
    public Animator HitCanvasAnim;
    public GameObject PlayerDeathEffect;
    private float timefreeze = 1f;
    public TimeManager timeManager;
    public CameraShake cameraShake;
    public GameObject ShieldPrefab;
    public GameObject ShieldPrefabLoot;
    private float timeShieldOn = 10f;
    private bool isShielded = false;
    public GameObject ShieldupEffect;
    public Animator GameOverAnim;
    public GameObject KeyEffectPrefab;
    public Animator ShieldUpAnim;
    public Animator HealthPlusAnim;

    // Start is called before the first frame update
    void Start()
    {

        RedEnemyProjectile = GameObject.FindGameObjectWithTag("RedEnemyBullet");
        RedEnemyProjectileTwo = GameObject.FindGameObjectWithTag("RedEnemyBullet");
        BlueEnemyProjectile = GameObject.FindGameObjectWithTag("blueEnemybullet");
        healthbar.value = playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        timeShieldOn -= Time.deltaTime;
        healthbar.value = playerHealth;
        if (playerHealth <= 0)
        {
            isDead = true;
            Handheld.Vibrate();
        
            StartCoroutine(cameraShake.Zoom(1f, 1f));
            StartCoroutine(cameraShake.Shake(1f, 1f));
            StartCoroutine(GameOverScreen());
           
            
        }


    }

    IEnumerator GameOverScreen()
    {
       
        GameOverAnim.SetTrigger("End");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameOver");

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerHealth > 0f && isDead == false)
        {
            if (collision.CompareTag("blueEnemybullet"))
            {
                Instantiate(hitEffect, transform.position, Quaternion.identity);
                HitRedAnim.SetTrigger("hit");
                playerHealth = playerHealth - 10;
                HitCanvasAnim.SetTrigger("HealthBar");
                timeManager.DoFreeze();
                
                StartCoroutine(cameraShake.Shake(0.1f, 0.2f));
                Handheld.Vibrate();
                FindObjectOfType<AudioManager>().Play("playerHit");

            }

            if (collision.CompareTag("RedEnemyBullet"))
            {
                Instantiate(hitEffect, transform.position, Quaternion.identity);
                HitRedAnim.SetTrigger("hit");
                HitCanvasAnim.SetTrigger("HealthBar");
                playerHealth = playerHealth - 8;
                timeManager.DofreezeLess();
               
                StartCoroutine(cameraShake.Shake(0.1f, 0.2f));
                Handheld.Vibrate();
                FindObjectOfType<AudioManager>().Play("playerHit");


            }
            if (collision.CompareTag("CircleExplodeCharon"))
            {
                Instantiate(hitEffect, transform.position, Quaternion.identity);
                HitRedAnim.SetTrigger("hit");
                HitCanvasAnim.SetTrigger("HealthBar");
                playerHealth = playerHealth -5;
                timeManager.DofreezeLess();
                
                StartCoroutine(cameraShake.Shake(0.1f, 0.2f));
                Handheld.Vibrate();
                FindObjectOfType<AudioManager>().Play("playerHit");
            }
            if (collision.CompareTag("Enemy"))
            {
                Instantiate(hitEffect, transform.position, Quaternion.identity);
                timeManager.DoFreeze();
                HitRedAnim.SetTrigger("hit");
                playerHealth = playerHealth - 5;
                HitCanvasAnim.SetTrigger("HealthBar");
                
                StartCoroutine(cameraShake.Shake(0.1f, 0.2f));
                Handheld.Vibrate();
                FindObjectOfType<AudioManager>().Play("playerHit");
            }
            if (collision.CompareTag("SpikesCharon"))
            {
                Instantiate(hitEffect, transform.position, Quaternion.identity);
                HitRedAnim.SetTrigger("hit");
                playerHealth = playerHealth - 10;
              
                StartCoroutine(cameraShake.Shake(0.1f, 0.2f));
                HitCanvasAnim.SetTrigger("HealthBar");
                timeManager.DoFreeze();
                Handheld.Vibrate();
                FindObjectOfType<AudioManager>().Play("playerHit");
            }
            if (collision.CompareTag("PickUp"))
            {
                
                HitRedAnim.SetTrigger("hit");
                if (healthbar.value < 100)
                {
                    
                    playerHealth = playerHealth + 25;
                }
                HitCanvasAnim.SetTrigger("heathHit");
                timeManager.DoFreeze();
                HealthPlusAnim.SetTrigger("HealthPlus");
                StartCoroutine(cameraShake.Zoom(.2f, .4f));
                FindObjectOfType<AudioManager>().Play("PickUp");
                
              


            }
            if (collision.CompareTag("ShieldLoot"))
            {

                StartCoroutine(cameraShake.Shake(0.1f, 0.2f));
                HitRedAnim.SetTrigger("hit");
                Instantiate(ShieldupEffect, transform.position, Quaternion.identity);
                Instantiate(ShieldPrefab, transform.position, Quaternion.identity);
                isShielded = true;
                ShieldUpAnim.SetTrigger("HighScore!");
                HitCanvasAnim.SetTrigger("heathHit");
                timeManager.DoFreeze();
                StartCoroutine(cameraShake.Zoom(.1f, .4f));
            }
            if (collision.CompareTag("Charonbullets"))
            {
                Instantiate(hitEffect, transform.position, Quaternion.identity);
                HitRedAnim.SetTrigger("hit");
                playerHealth = playerHealth - 8;
               
                StartCoroutine(cameraShake.Shake(0.1f, 0.2f));
                HitCanvasAnim.SetTrigger("HealthBar");
                timeManager.DoFreeze();
                Handheld.Vibrate();
                FindObjectOfType<AudioManager>().Play("playerHit");
            }

            if (collision.CompareTag("Key"))
            {
                Instantiate(hitEffect, transform.position, Quaternion.identity);
                HitRedAnim.SetTrigger("hit");
                
                StartCoroutine(cameraShake.Shake(0.1f, 0.1f));
                
                timeManager.DoFreeze();
                Handheld.Vibrate();
            }



        }
        if (isDead)
        {
            FindObjectOfType<GameOverMenu>().GameOver();
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            Destroy(gameObject);
            Instantiate(PlayerDeathEffect, transform.position, Quaternion.identity);
            StartCoroutine(GameOverScreen());
            PlayerPrefs.DeleteAll();
            


        }
        
    }


}