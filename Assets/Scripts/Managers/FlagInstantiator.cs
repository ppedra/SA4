using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class FlagInstantiator : MonoBehaviour {

	public static FlagInstantiator instance;

	[Header("Flags")]
	//flags prefabs
	public GameObject genericFlag;

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
		
		GameObject flag = Instantiate(genericFlag,pos,Quaternion.identity);
		flag.GetComponent<Flag>().Init(color, color == correctColor);
	}

}
