using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPStateMachineHandler : MonoBehaviour {

	
	public Vector3 initialPosition;
	public Vector3 finalPosition;
	
	
	public void InstantiatePerson(Vector3[] positions){
		initialPosition = positions[0];
		finalPosition = positions[1];

		this.transform.position = positions[0];
		// this.transform.position = new Vector3(0f,0f,0f);
	}
}
