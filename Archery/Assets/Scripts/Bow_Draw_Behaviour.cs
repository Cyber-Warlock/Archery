using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow_Draw_Behaviour : StateMachineBehaviour
{
    [SerializeField]
    GameObject arrowPrefab = default;

    GameObject arrow;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        arrow = Instantiate(arrowPrefab, animator.transform.position, animator.transform.rotation, animator.transform);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Rotate player around Z-axis to look at the inverse mouse position
        Vector2 mousePosInv = Camera.main.ScreenToWorldPoint(Input.mousePosition) * -1;
        Vector2 direction = (mousePosInv - (Vector2)animator.transform.position).normalized;
        animator.transform.up = direction;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        arrow.transform.parent = null;

        // Create a multiplier for the force of the arrow based on how far the bow is "drawn"
        float drawStrength = Mathf.Clamp(Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), animator.transform.position), 3, 9) * 10;

        arrow.GetComponent<Rigidbody2D>().velocity = (Camera.main.ScreenToWorldPoint(Input.mousePosition) * -1 - animator.transform.position).normalized * drawStrength;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
