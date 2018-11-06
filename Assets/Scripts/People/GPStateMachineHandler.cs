using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof<Animator>)]
public class GPStateMachineHandler : MonoBehaviour {

	[Header("Speed Info")]
	public float speed = 3;
	[Range(0f,2f)]
	public float randomRange;

	public Vector3 initialPosition;
	public Vector3 finalPosition;

	private void Awake() {
	
	}

	void Start() {
		speed = speed + Random.Range(-randomRange,randomRange);
	}
	
	///<summary>
	/// recive initial and final position and start moviment from GenericPersonInstantiator
	///</summary>
	///<param name="positions">{initial position,final position}</param>
	public void InstantiatePerson(Vector3[] positions){
		initialPosition = positions[0];
		finalPosition = positions[1];

		this.transform.position = positions[0];
	}

	public Vector3 GetDestination(){
		return finalPosition;
	}

	public float GetSpeed(){
		return speed;
	}


}
