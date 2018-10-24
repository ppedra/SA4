﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPersonMov : MonoBehaviour {
	[Header("Speed Info")]
	public float speed = 3;
	[Range(0f,2f)]
	public float randomRange;

	private Rigidbody2D _rigidbody2D;

	IEnumerator coroutine;

	public Vector3 initialPosition;
	public Vector3 finalPosition;

	private void Awake() {
		//on start is one frame too late
		_rigidbody2D = this.GetComponent<Rigidbody2D>();
	}

	void Start() {
		speed = speed + Random.Range(-randomRange,randomRange);
	}

	///<summary>
	/// recive initial and final position and start moviment coroutine
	///</summary>
	///<param name="positions">{initial position,final position}</param>
	public void InstantiateGenericPerson(Vector3[] positions){
		initialPosition = positions[0];
		finalPosition = positions[1];

		this.transform.position = positions[0];
		MoveToPosition(positions[1]);

	}
	///<summary>
	/// manage MoveToPositionCoroutine coroutine. 
	///</summary>
	///<param name="WorldPoint">position to walk to</param>
	public Coroutine MoveToPosition(Vector3 worldPoint){
		if (coroutine != null){
			StopCoroutine(coroutine);
		}
		coroutine = MoveToPositionCoroutine(worldPoint);
		return StartCoroutine(coroutine);
		
	}


	///<summary>
	/// Coroutine to move GameObject to target
	///</summary>
	private IEnumerator MoveToPositionCoroutine (Vector3 target){
		float t = 0;
		Vector3 start = transform.localPosition;
		float dist = Vector2.Distance(start,target);
		while (t <= 1){
			t += (Time.fixedDeltaTime * speed) / dist;
			_rigidbody2D.MovePosition(Vector3.Lerp (start, target, t));
			
			yield return null; //skip a frame
		}
	}

	public void StopCoroutinesHere(){
		StopAllCoroutines();
	}
}
