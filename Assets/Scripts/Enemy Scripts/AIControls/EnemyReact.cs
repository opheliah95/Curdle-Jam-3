using MyUtil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReact : StateMachineBehaviour
{
    private Transform player;
    public float speed;
    [SerializeField]
    bool flipLeft;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Vector3 dirToPlayer = animator.transform.position - player.position;
        Vector3 newPos = dirToPlayer.normalized + animator.transform.position;
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, newPos, speed * Time.deltaTime);

        // flip when facing same dir as player
        if ((dirToPlayer.x <= 0 && !flipLeft) || (dirToPlayer.x > 0 && flipLeft))
        {
            animator.GetComponent<Enemy>().flipLeft = !flipLeft;
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


}
