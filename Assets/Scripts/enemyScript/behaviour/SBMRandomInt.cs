using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using Unity.VisualScripting;

public class SBMRandomInt : StateMachineBehaviour
{
    //----------MonoBehaviour--------
    private MonoBehaviour monoBehaviour = null;
    public void StateMachineBehaviour(MonoBehaviour monoBehaviour)
    {
        this.monoBehaviour = monoBehaviour;
    }

    //----------Player Move----------
    Transform player;
    public float distanceCHASE;

    //----------Attack----------
    private int playCount=0;
    private bool isCooldown=false;

    //----------Random Attack----------
    [Tooltip("Attackindex")]
    public string parameterName = "Attackindex";

    [Tooltip("Attackindex")]
    public int minValue = 0; 

    [Tooltip("Attackindex")]
    public int maxValue = 1; 

    [Tooltip("Attackindex")]
    public float attackCooldown;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash) 
    {
        if (!isCooldown)
        {
            int value = Random.Range(minValue,maxValue+1);
            animator.SetInteger(parameterName,value);

            playCount++;
            if(playCount>=2)
            {
                isCooldown=true;
                playCount=0;
                
                StateMachineBehaviour(animator.GetComponent<MonoBehaviour>());
                this.monoBehaviour.StartCoroutine(PerformRandomAttack(animator));
            }
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 playerPosition = new Vector3(player.position.x, animator.transform.position.y, player.position.z);
        animator.transform.LookAt(playerPosition);

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > distanceCHASE)
            animator.SetBool("isAttacking",false);
    }

    private IEnumerator PerformRandomAttack(Animator animator)
    {
        //Debug.Log("isCooldown");
                
        yield return new WaitForSeconds(attackCooldown);
        animator.SetBool("isCooldown", true);
        isCooldown=false;
    }
}