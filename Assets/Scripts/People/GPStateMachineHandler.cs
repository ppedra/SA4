using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof<Animator>)]
public class GPStateMachineHandler : MonoBehaviour {

	[Header("Speed Info")]
	public float speed = 3;
	[Range(0f,2f)]
	public float randomRange;
	// public bool shouldBeMoving;

	// private Rigidbody2D _rigidbody2D;

	public Vector3 initialPosition;
	public Vector3 finalPosition;

	// [Header("Animator")]
	// public bool hasBeenWhistle;
	// public Animator animator;


	private void Awake() {
		//on start is one frame too late
		// _rigidbody2D = this.GetComponent<Rigidbody2D>();
	}

	void Start() {
		speed = speed + Random.Range(-randomRange,randomRange);
	}

	///<summary>
	/// recive initial and final position and start moviment from GenericPersonInstantiator
	///</summary>
	///<param name="positions">{initial position,final position}</param>
	public void InstantiateGenericPerson(Vector3[] positions){
		initialPosition = positions[0];
		finalPosition = positions[1];

		this.transform.position = positions[0];
		// shouldBeMoving = true;
	}

	public Vector3 GetDestination(){
		return finalPosition;
		// return new Vector3(3f,3f,0f);
	}
	public float GetSpeed(){
		return speed;
	}


}
