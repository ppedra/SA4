using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	[HideInInspector]
	public static ScoreManager instance;

	public int score; 

	void Start () {
		if (instance == null){
			instance = this;
		}
	}

	public void AddPoints(Utils.ScoreIntensity scoreIntensity){
		//TODO: ifs for add points
		
	}

	public void RemovePoints(Utils.ScoreIntensity scoreIntensity){
		//TODO: ifs for remove points
	}
	
	
}
