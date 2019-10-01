using System.Collections;
using UnityEngine; 
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerJoystickMove : MonoBehaviour
{

    public float MoveSpeed = 2, BoostMultiplier = 10;
    public float offset;
    public Rigidbody2D ShipRB;
    float rotationX = 15f;
    float rotationY = 15f;
   

    void Start()
    {
        ShipRB = this.GetComponent<Rigidbody2D>();
        
    }

    void FixedUpdate()
    {
        Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * MoveSpeed;
        
        //transform.LookAt(transform.position.toVector2() + moveVec);
        bool isBoosting = CrossPlatformInputManager.GetButton("Boost");
        ShipRB.AddForce(moveVec * (isBoosting ? BoostMultiplier : 1));
        

    }
    private void Update()
    {
        rotationX = CrossPlatformInputManager.GetAxis("Horizontal");
        rotationY = CrossPlatformInputManager.GetAxis("Vertical");
        Vector3 diff = new Vector3(rotationX, rotationY);
        float rotz = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);


    }
}
