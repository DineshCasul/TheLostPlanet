using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharonShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject DownBulletPink;
    public float timeBtwShots;
    public float StartTimeBtwShots = 18f;
    void Start()
    {
        timeBtwShots = StartTimeBtwShots;
        timeBtwShots -= Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {
        StartTimeBtwShots = .5f;
        if (timeBtwShots < 0)
        {
            Instantiate(DownBulletPink, firePoint.position, Quaternion.identity);
            timeBtwShots = StartTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

}
