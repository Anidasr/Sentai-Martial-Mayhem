using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summon : StateMachineBehaviour
{
    public GameObject particle;
    protected GameObject effect;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        effect = Instantiate(particle, animator.rootPosition, Quaternion.identity) as GameObject;
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(effect,2f);
    }
}
