using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasicMoviment : MonoBehaviour {

	private IEnumerator coroutine;
	public float liveGuardSpeed;

	private Rigidbody2D rigidBody2D;
	
	void Start () {
		rigidBody2D = this.GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		//wait for click and check if is over UI object
		// if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() ){
		// 	Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		// 	RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero,100,5);
		// 	if (hit){
		// 		Debug.Log(hit.collider.gameObject.name);
		// 		if (hit.collider.gameObject.tag == "Ground"){
		// 			if (coroutine != null){
		// 				//stop any current moviment
		// 				StopCoroutine(coroutine);
		// 			}
		// 			//then move
		// 			coroutine = MoveToPosition(worldPoint);
		// 			StartCoroutine(coroutine);
		// 		}
		// 	}
		// }
	}

	public void PlayerMoveTo(Vector2 worldPoint){
		RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero,100,5);
		if (hit){
			Debug.Log(hit.collider.gameObject.name);
			if (hit.collider.gameObject.tag == "Ground"){
				if (coroutine != null){
					//stop any current moviment
					StopCoroutine(coroutine);
				}
				//then move
				coroutine = MoveToPosition(worldPoint);
				StartCoroutine(coroutine);
			}
		}
	}

	private IEnumerator MoveToPosition (Vector3 target){
		float t = 0;
		Vector3 start = transform.localPosition;
		float dist = Vector2.Distance(start,target);

		while (t <= 1){
			t += (Time.fixedDeltaTime * liveGuardSpeed) / dist;
			rigidBody2D.MovePosition (Vector3.Lerp (start, target, t));

			yield return null; //skip a frame
		}
	}

}
