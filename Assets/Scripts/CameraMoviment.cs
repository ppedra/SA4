using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoviment : MonoBehaviour {

	public GameObject player;
	public GameObject pointToFollow;

	[Header("Values for moving")]
	public float amount;
	public float whereItStarts;
	public float maxNegY;

	void Start () {
		if (player == null || pointToFollow == null){
			Debug.LogError("missing ref in CameraMoviment!");
		}
		whereItStarts = -1f;
		amount = 2f;
	}
	
	void Update () {
		MovePointToFollow();
	}

	///<summary>
	///if player.position.y reaches a point (whereItStarts), pointToFollow will move lower, so the
	///camera can look at the ocean
	///</summary>
	private void MovePointToFollow(){
		if (player.transform.position.y < whereItStarts){
			float tempy = Mathf.Clamp((player.transform.position.y - whereItStarts)* amount, maxNegY,0f);
			Vector3 tempPos = new Vector3(0f, tempy, 0f);
			pointToFollow.transform.localPosition = tempPos;
		}else{
			pointToFollow.transform.localPosition = Vector3.zero;
		}
	}
}
