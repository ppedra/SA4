using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoviment : MonoBehaviour {

	private IEnumerator coroutine;
	public float liveGuardSpeed;

	private Rigidbody2D rigidbody;
	
	void Start () {
		rigidbody = this.GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		if (Input.GetMouseButton(0)){
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			// this.transform.position = worldPoint;
			// RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
			// Debug.Log(worldPoint);

			if (coroutine != null){
				StopCoroutine(coroutine);
			}
			coroutine = MoveToPosition(worldPoint);
			StartCoroutine(coroutine);
		}
		
	}

	private IEnumerator MoveToPosition (Vector3 target){
		float t = 0;
		Vector3 start = transform.localPosition;
		float dist = Vector2.Distance(start,target);

		while (t <= 1){
			t += (Time.fixedDeltaTime * liveGuardSpeed) / dist;
			// transform.localPosition = Vector3.Lerp (start, target, t);
			rigidbody.MovePosition (Vector3.Lerp (start, target, t));

			yield return null;
		}
	}

}
