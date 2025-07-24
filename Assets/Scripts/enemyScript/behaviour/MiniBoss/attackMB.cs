using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class attackMB : StateMachineBehaviour
{ 
    Transform player;
    public float distanceChase;
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
        Vector3 playerPosition = new Vector3(player.position.x, animator.transform.position.y, player.position.z);
        animator.transform.LookAt(playerPosition);
        
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > distanceChase)
            animator.SetBool("isAttacking",false);
        
        if (timer <= 0)
        {
            animator.SetBool("isAttacking",false);
        }
        else 
        {
            timer -= Time.deltaTime;
        }
    }
}
