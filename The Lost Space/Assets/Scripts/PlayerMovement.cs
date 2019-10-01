using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public float MoveSpeed = 6f;
    public float offset;
    Rigidbody2D ShipRB;
    void Start()
    {
        ShipRB = this.GetComponent<Rigidbody2D>();
        
    }

   void FixedUpdate()
    {
        Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical") *MoveSpeed);
        ShipRB.AddForce(moveVec);
    }
}
