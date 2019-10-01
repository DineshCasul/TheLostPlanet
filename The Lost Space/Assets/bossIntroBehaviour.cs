using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossIntroBehaviour : StateMachineBehaviour
{
    private float rand;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0, 5);
        if (rand > 0)
        {
            animator.SetTrigger("idle1");
        }
        else
            animator.SetTrigger("idle2");
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}