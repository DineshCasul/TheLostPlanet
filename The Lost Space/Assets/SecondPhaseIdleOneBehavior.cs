using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPhaseIdleOneBehavior : StateMachineBehaviour
{
    private float timer;
    public float MaxTime;
    public float MinTime;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(MinTime, MaxTime);
    }
 
       override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(timer < 0)
        {
            animator.SetTrigger("SecondPhaseIdle2");
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
       
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
