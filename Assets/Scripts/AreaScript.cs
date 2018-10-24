using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class AreaScript : MonoBehaviour {

	BoxCollider2D col;
	public float positiveYMargin = 0;
	public float negativeYMargin = 0;
	void Start () {
		col = this.GetComponent<BoxCollider2D>();
	}

	///<summary>
	/// return Vector2 with random position inside Collider2D area  
	///</summary>
	public Vector2 GetRandomPositionInsideArea(){
		Vector2 size = col.size/2;
		Vector3 position =  this.transform.position;

		float randomx = position.x + Random.Range(-size.x,size.x);
		float randomy = position.y + Random.Range(-size.y+negativeYMargin,size.y-positiveYMargin);
		
		return new Vector2(randomx, randomy);
	}
	
}
