using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow_Draw_Behaviour : StateMachineBehaviour
{
    [Header("Arrow Config")]
    [SerializeField]
    GameObject arrowPrefab = default;

    [SerializeField]
    float arrowForceMultiplier = 7f;

    GameObject arrow;

    LineRenderer aimLine;

    [Header("Aim Assist")]

    [SerializeField]
    Color moreForce = Color.red;

    [SerializeField]
    Color goodForce = Color.blue;

    [SerializeField]
    float minForce = 5f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get a reference for easier access to the LineRenderer component
        aimLine = animator.GetComponent<LineRenderer>();

        // Instantiate ("nock") the arrow prefab
        arrow = Instantiate(arrowPrefab, animator.transform.position, animator.transform.rotation, animator.transform);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Rotate player around Z-axis to look at the inverse mouse position
        Vector2 mousePosInv = Camera.main.ScreenToWorldPoint(Input.mousePosition) * -1;
        Vector2 direction = (mousePosInv - (Vector2)animator.transform.position).normalized;
        animator.transform.up = direction;

        // We'll use this multiple times so we store it in a variable in the scope
        float cursorToPlayerDist = Vector3.Distance(mousePosInv, animator.transform.position);

        // Show if draw is long enough by line color
        aimLine.startColor = cursorToPlayerDist > minForce ? goodForce : moreForce;
        aimLine.endColor = cursorToPlayerDist > minForce ? goodForce : moreForce;

        // Position lines
        aimLine.SetPosition(0, animator.transform.position);
        Vector3 lineEnd = (animator.transform.up * 7) / Mathf.Clamp(Mathf.Pow(cursorToPlayerDist, 0.5f), 1, 5);
        aimLine.SetPosition(1, lineEnd);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Release arrow from player
        arrow.transform.parent = null;

        // Create a multiplier for the force of the arrow based on how far the bow is "drawn"
        float drawStrength = Mathf.Clamp(Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), animator.transform.position), 10, 13) * arrowForceMultiplier;

        Vector3 arrowVelocity = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) * -1 - (Vector2)animator.transform.position).normalized * drawStrength;

        // Fire the arrow if the minForce is exceeded, otherwise destroy it
        if (Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), animator.transform.position) > minForce)
            arrow.GetComponent<Rigidbody2D>().velocity = arrowVelocity;
        else
            Destroy(arrow);

        AudioManager.Instance.Release();
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
