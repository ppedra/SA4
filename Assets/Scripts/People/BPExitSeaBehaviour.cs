using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPExitSeaBehaviour : StateMachineBehaviour {

	Vector3 finalDestination;
	float speed;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		speed = animator.GetComponent<BPStateMachineHandler>().GetSpeed();
		finalDestination = animator.GetComponent<BPStateMachineHandler>().GetPositionInBeachToExit();
		
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.transform.position = Vector3.MoveTowards(animator.transform.position, finalDestination, speed * Time.deltaTime);
		
		if (Vector3.Distance(animator.transform.position,finalDestination) < 0.3f) {
			animator.SetTrigger("ExitedBeach");
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
