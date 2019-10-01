using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowBound : MonoBehaviour
{
    public Transform target;

    Vector3 Velocity = Vector3.zero;

    public float smoothTime = .15f;

    public bool yMinEnabled = false;
    public float yMinValue = 0;

    public bool yMaxEnabled = false;
    public float yMaxValue = 0;

    public bool xMinEnabled = false;
    public float xMinValue = 0;

    public bool xMaxEnabled = false;
    public float xMaxValue = 0;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void FixedUpdate()
    {



        Vector3 targetPos = target.position;
        if (yMinEnabled && yMaxEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, yMinValue, yMaxValue);
        }
        else if (yMinEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, yMinValue, transform.position.y);
        }
        else if (yMaxEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, target.position.y, yMaxValue);
        }



        if (xMinEnabled && xMaxEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, xMinValue, xMaxValue);
        }
        else if (xMinEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, xMinValue, transform.position.x);
        }
        else if (yMaxEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, target.position.x, xMaxValue);
        }

        targetPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref Velocity, smoothTime);
    }







}
        