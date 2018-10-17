using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class FlagInstantiator : MonoBehaviour {

	public static FlagInstantiator instance;

	[Header("Flags")]
	//flags prefabs
	public GameObject redFlagPrefabToInstantiate;
	public GameObject yellowPlagPrefabToInstantiate;
	public GameObject greenFlagPrefabToInstantiate;


	void Awake() {
		if (instance == null){
			instance = this;
		} 	
	}

	public void InstantiateFlag(FlagColor color,Vector2 pos){
		if (color == FlagColor.red){
			Instantiate(redFlagPrefabToInstantiate,pos,Quaternion.identity);
		}else{
			//TODO: another flags!
			Debug.LogError("Should never me here. Where? " + this.name);
		}
	}

}
