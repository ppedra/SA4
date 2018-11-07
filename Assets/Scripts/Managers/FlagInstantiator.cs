using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class FlagInstantiator : MonoBehaviour {

	public static FlagInstantiator instance;

	[Header("Flags")]
	//flags prefabs
	public GameObject redFlagPrefab;
	public GameObject redFlagPrefabWrong;
	[Space(3f)]
	public GameObject yellowPlagPrefab;
	public GameObject yellowPlagPrefabWrong;
	[Space(3f)]
	public GameObject greenFlagPrefab;
	public GameObject greenFlagPrefabWrong;

	[Header("Areas")]
	public GameObject[] areasToPlaceFlag;
	public BoxCollider2D[] boundsOfAreasToPlaceFlag;

	void Awake() {
		if (instance == null){
			instance = this;
		} 	
	}
	private void Start() {
		if (areasToPlaceFlag == null){
			areasToPlaceFlag = GameObject.FindGameObjectsWithTag("SeaArea");
		}
		boundsOfAreasToPlaceFlag = new BoxCollider2D[areasToPlaceFlag.Length];
		for(int i=0; i< boundsOfAreasToPlaceFlag.Length; i++){
			boundsOfAreasToPlaceFlag[i] = areasToPlaceFlag[i].GetComponent<BoxCollider2D>();
		}
	}

	///<summary>
	/// Get clicked area's correct Utils.FlagColor for flag placement.
	///</summary>
	///<returns>
	/// Return Utils.FlagColor.none if clicked outside flag area
	///</returns>
	///<param name = "pos">world position to cast a raycast to </param>
	private Utils.FlagColor GetClickedAreaColor(Vector2 pos){
		Ray ray = new Ray(pos,Vector2.one);
		foreach (BoxCollider2D bound in boundsOfAreasToPlaceFlag){
			if (bound.bounds.IntersectRay(ray)){
				return bound.gameObject.GetComponent<FlagArea>().rightFlag;
			}
		}
		return Utils.FlagColor.None;
		
	}
	
	///<summary>
	/// instantiate a flag prefab in the position wanted by player, checks if it is the right position, instantiate
	/// correct prefab (right or wrong flag) and change score based of the level of 'rightfulness'
	///</summary>
	///<param name="color">players intention</param>
	///<param name="pos">world position</param>
	public void InstantiateFlag(FlagColor color,Vector2 pos){
		Utils.FlagColor correctColor = GetClickedAreaColor(pos);
		
		//TODO: create add or remove correct amount of points!
		if (color != correctColor){
			if (color == FlagColor.Red){
				InstantiateFlagAndAction(redFlagPrefabWrong,pos);
				// ScoreManager.instance.RemovePoints(Utils.ScoreIntensity.High);
			}else if (color == FlagColor.Green){
				InstantiateFlagAndAction(greenFlagPrefabWrong,pos);
				// if (correctColor == Utils.FlagColor.None){
				// 	//no big deal. 
				// 	ScoreManager.instance.RemovePoints(Utils.ScoreIntensity.Low);
				// }else{
				// 	//wrong position! people are in danger!
				// 	ScoreManager.instance.RemovePoints(Utils.ScoreIntensity.High);
				// }
			}else if (color == FlagColor.Yellow){
				InstantiateFlagAndAction(yellowPlagPrefabWrong,pos);
				// ScoreManager.instance.RemovePoints(Utils.ScoreIntensity.High);
			}
			return;
		}
		
		if (color == FlagColor.Red){
			InstantiateFlagAndAction(redFlagPrefab,pos);
		}else if (color == FlagColor.Green){
			InstantiateFlagAndAction(greenFlagPrefab,pos);
		}else if (color == FlagColor.Yellow){
			InstantiateFlagAndAction(yellowPlagPrefab,pos);
		}else{
			Debug.LogError("Should never be here. Where? " + this.name);
		}
	}

	public void InstantiateFlagAndAction (GameObject flagPrefab,Vector3 pos){
		GameObject.Instantiate(flagPrefab,pos,Quaternion.identity);
		//TODO: actions for redflag, for exemple. 
		// make all the peoples in the area go away
	}

}
