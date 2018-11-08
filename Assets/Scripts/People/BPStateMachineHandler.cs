using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPStateMachineHandler : GPStateMachineHandler {


	///<summary>
	/// return a position inside sand area for the bathing person to go,
	/// based on the current position, leaving the sand
	///</summary>
	///<returns> position to go leaving the sea </returns>
	public Vector3 GetPositionInBeachToExit(){
		//random amount to create variation
		Vector2 rand = Random.insideUnitSphere*Random.Range(0f,2f);
		// float rx = 0f;
		// float ry = 0f;

		Vector3 pos = new Vector3(this.initialPosition.x + rand.x, this.finalPosition.y + rand.y);
		
		return pos;
	}

	public void InRedFlagArea(){
		this.GetComponent<Animator>().SetTrigger("Hit");
	}


}
