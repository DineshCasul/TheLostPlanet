using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharonBullets : MonoBehaviour
{
    public GameObject[] BulletPrefab; 
    public Transform[] DefaultfirePoints;
    public GameObject[] SpikesPrefab;
    public Transform[] SpikesfirePoints;
    private float timeBtwSpikes;
    private float timeBtwShots;
    public float ShootingTime = .31f;
    private float timeBtwCircleExplode;
    private float timeBtwFollowingBullet;
    public float ExplodingTime = 10f;
    public GameObject CircleExplodePrefab;
    public GameObject FollowingBulletPrefab;
    public Transform EyeFirepoint;
    private CharonHealth BossHealth;
    private float StartShootingAfter ;


    private void Start()
    {

        StartShootingAfter = 5f;
            timeBtwShots = ShootingTime;
            timeBtwCircleExplode = ExplodingTime;
            timeBtwSpikes = 2f;
            timeBtwFollowingBullet = 1f;
            BossHealth = GameObject.FindGameObjectWithTag("Charon").GetComponent<CharonHealth>();
        FindObjectOfType<AudioManagerBoss>().Play("CharonVoice");
    }
    void Update()
    {
        StartShootingAfter -= Time.deltaTime;
        if (StartShootingAfter < 0)
        {
           
            timeBtwSpikes -= Time.deltaTime;
            timeBtwCircleExplode -= Time.deltaTime;
            timeBtwShots -= Time.deltaTime;
            timeBtwFollowingBullet -= Time.deltaTime;
          
            InstantiateDefaultBullets();
            InstantiateExtraPowers();

            if (BossHealth.Healthbar.value < 100f)
            {
                FollowingBullet();
                InstantiateSpikes();
            }

        }       
    }

    void InstantiateDefaultBullets()
    {
        if (timeBtwShots < 0f)
        {
            for (int i = 0; i < DefaultfirePoints.Length; i++)
            {
                Instantiate(BulletPrefab[i], DefaultfirePoints[i].position, Quaternion.identity);
                timeBtwShots = ShootingTime;
            }
        }
    }
    void InstantiateExtraPowers()
    {
        if (timeBtwCircleExplode < 0f)
        {
            Instantiate(CircleExplodePrefab, transform.position, Quaternion.identity);
            timeBtwCircleExplode = ExplodingTime;

        }
    }

    void InstantiateSpikes()
    {
        if (timeBtwSpikes < 0f)
        {
            for (int i = 0; i < SpikesfirePoints.Length; i++)
            {
                Instantiate(SpikesPrefab[i], SpikesfirePoints[i].position, Quaternion.identity);
                timeBtwSpikes = 2f;
            }
        }
    }

    void FollowingBullet()
    {
        if (timeBtwFollowingBullet < 0f)
        {
            Instantiate(FollowingBulletPrefab, EyeFirepoint.position, Quaternion.identity);
            timeBtwFollowingBullet = 1f;
        }
    }
}
