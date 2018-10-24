using System.Collections;
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
		RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero,100,5);
		if (hit){
			Debug.Log(hit.collider.gameObject.name);
			if (hit.collider.gameObject.tag == "Ground"){
				if (coroutine != null){
					//stop any current moviment
					StopCoroutine(coroutine);
				}
				//then move
				coroutine = MoveToPositionCoroutine(worldPoint);
				return StartCoroutine(coroutine);
			}
		}

		Debug.LogError("raycast missed/didn't hit the ground. ops...");
		return null;
	}

	public IEnumerator MoveToPositionCoroutine (Vector3 target){
		float t = 0;
		Vector3 start = transform.localPosition;
		float dist = Vector2.Distance(start,target);
		while (t <= 1){
			t += (Time.fixedDeltaTime * WalkingSpeed) / dist;
			rigidBody2D.MovePosition (Vector3.Lerp (start, target, t));
			
			yield return null; //skip a frame
		}
	}

	public void StopCoroutinesHere(){
		StopAllCoroutines();
	}

}
