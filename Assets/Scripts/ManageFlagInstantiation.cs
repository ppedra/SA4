using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageFlagInstantiation : MonoBehaviour {

	public static ManageFlagInstantiation instance;

	//flags prefabs
	public GameObject redFlagPrefabToInstantiate;


	void Awake() {
		if (instance == null){
			instance = this;
		} 	
	}
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
