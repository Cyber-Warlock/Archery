using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow_Draw_Behaviour : StateMachineBehaviour
{
    Quaternion baseRot;

    [SerializeField]
    GameObject arrowPrefab;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 playerVector = animator.transform.position + animator.transform.up;
        Vector3 mouseInvVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) * -1;

        //animator.transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition) * -1, Vector3.up);
        animator.transform.RotateAround(animator.transform.position, Vector3.forward, Vector3.Angle(playerVector, mouseInvVector));

        baseRot = animator.transform.localRotation;

        Instantiate(arrowPrefab, animator.transform.position, baseRot, animator.transform);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
