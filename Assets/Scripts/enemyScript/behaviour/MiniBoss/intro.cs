using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro : StateMachineBehaviour
{
    Transform player;
    public float chaseRange;
    private float timer;
    public float minTime;
    public float maxTime;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timer = Random.Range(minTime, maxTime);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            animator.SetBool("isChasing", true);

            float distance = Vector3.Distance(animator.transform.position, player.position);
            if (distance < chaseRange)
            animator.SetBool("isChasing", true);
        }
        else {
            timer -= Time.deltaTime;
        }
    }
}