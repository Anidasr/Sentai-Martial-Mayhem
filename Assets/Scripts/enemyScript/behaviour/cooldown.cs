using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cooldown : StateMachineBehaviour
{
    Transform player;
    float timer;
    public float timeIdle;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timer=0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 playerPosition = new Vector3(player.position.x, animator.transform.position.y, player.position.z);
        animator.transform.LookAt(playerPosition);

        timer+=Time.deltaTime;
        if (timer > timeIdle)
            animator.SetBool("isCooldown", false);    
    }
}
