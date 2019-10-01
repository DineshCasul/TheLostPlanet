
using UnityEngine;
using UnityEngine.UI;
public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject BulletInitiateEffect;
    public GameObject bulletPrefab;
    public float offset;
    private float timebtwShots;
    private float StartTimeBtwShots =30f;
    public GameObject BurstBlueButton;
    
    public GameObject RedBusrtEffect;
    public Animator RedButtonAnim;

    
    public GameObject CircleExplosion;
    public GameObject BlueButton;
    public Slider BlueButtonCountdown;
    public TimeManager timeManager;



    private void Start()
    {
        timebtwShots = StartTimeBtwShots;
        BlueButton.SetActive(false);
        BlueButtonCountdown.value = timebtwShots;
    }
    // Update is called once per frame
    void Update()
    {

        /* {
             Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

             float rotz = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
             transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset); 


         }
         */
        timebtwShots -= Time.deltaTime;
        BlueButtonCountdown.value = timebtwShots;
        if(timebtwShots < 0)
        {
           
            BlueButton.SetActive(true);
            FindObjectOfType<AudioManager>().Play("RechargeComplete");

        }
        else
        {
            BlueButton.SetActive(false);
        }
        /* if (timebtwShots <= 0)
         {


             if (Input.GetMouseButtonDown(0))
             {

                 Shoot();
                 timebtwShots = StartTimeBtwShots;
                 Instantiate(RedBusrtEffect, firePoint.position, firePoint.rotation);


             }
             if (Input.GetMouseButtonDown(1))
             {

                 ShootBlue();
                 timebtwShots = StartTimeBtwShots;
                 Instantiate(BlueBurstEffect, FirepointBlue.position, firePoint.rotation);
             }
         }
         else

         {
             timebtwShots -= Time.deltaTime;
         }
        */




    }

   
    public void Shoot()
    {
       
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(bulletPrefab, new Vector2(firePoint.position.x+.1f, firePoint.position.y+.1f), firePoint.rotation);
        Instantiate(bulletPrefab, new Vector2(firePoint.position.x - .1f, firePoint.position.y - .1f), firePoint.rotation);
        var BulletInitiate = Instantiate(BulletInitiateEffect, firePoint.position, Quaternion.identity);
        GameObject.Destroy(BulletInitiate, 2);
        
    }

    public void ShootBurst()
    {
        if (timebtwShots <= 0)
        {
            
            timeManager.DoFreeze();
            Instantiate(BurstBlueButton, transform.position, Quaternion.identity);
            Instantiate(CircleExplosion, transform.position, Quaternion.identity);
            timebtwShots = StartTimeBtwShots;
            
        }
        else
        {
            timebtwShots -= Time.deltaTime;
        }
    }

   

}


