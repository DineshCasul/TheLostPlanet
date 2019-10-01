using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPhaseIntroBehaviour : StateMachineBehaviour
{
    private float rand;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0, 5);
        if (rand > 0)
        {
            animator.SetTrigger("SecondPhaseIdle1");
        }
        else
            animator.SetTrigger("SecondPhaseIdle2");
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}