using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheildPrefab : MonoBehaviour
{
    private Transform ShipPosition;
    public GameObject ShieldDest;
    
    // Start is called before the first frame update
    void Start()
    {
        ShipPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ShipPosition.position;
        ShieldDestroy();
        
    }
    void ShieldDestroy()
    {
        Destroy(gameObject, 10f);
        var ShieldDes = Instantiate(ShieldDest, transform.position, Quaternion.identity);
        GameObject.Destroy(ShieldDes, 1);
    }

    
}
