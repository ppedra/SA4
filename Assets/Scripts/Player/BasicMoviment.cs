﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasicMoviment : MonoBehaviour {

	public float WalkingSpeed = 3f;
	private IEnumerator coroutine;
	private Rigidbody2D rigidBody2D;
	
	void Start () {
		rigidBody2D = this.GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		
	}

	public Coroutine MoveToPosition(Vector2 worldPoint){
		return MoveToPosition(worldPoint,0f);
	}

	public Coroutine MoveToPosition(Vector2 worldPoint,float dist){
		RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero,100,5);
		if (hit){
			Debug.Log(hit.collider.gameObject.name);
			if (hit.collider.gameObject.tag == "Ground"){
				if (coroutine != null){
					//stop any current moviment
					StopCoroutine(coroutine);
				}
				//then move
				coroutine = MoveToPositionCoroutine(worldPoint,dist);
				return StartCoroutine(coroutine);
			}
		}


		Debug.LogError("raycast missed/didn't hit the ground. ops...");
		return null;
	}

	public Coroutine MoveToPositionNORAYCAST(Vector2 worldPoint,float dist){
		if (coroutine != null){
			//stop any current moviment
			StopCoroutine(coroutine);
		}
		//then move
		coroutine = MoveToPositionCoroutine(worldPoint,dist);
		return StartCoroutine(coroutine);
	}

	public IEnumerator MoveToPositionCoroutine (Vector3 target,float dist){
		Vector3 start = transform.localPosition;
		float m_dist = Vector2.Distance(start,target);
		float t = 0;
		float lim = 1 - (dist/m_dist);
		while (t <= lim){
			t += (Time.fixedDeltaTime * WalkingSpeed) / m_dist;
			rigidBody2D.MovePosition (Vector3.Lerp (start, target, t));
			// Debug.Log("t: " + t + " - lim: " + lim);
			yield return null; //skip a frame
		}
	}

	public void StopCoroutinesHere(){
		StopAllCoroutines();
	}

}
