using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPersonInstantiator : MonoBehaviour {

	AreaScript[] areas;
	[Space(10)]
	public GameObject gpPrefab;
	public GameObject gpParent; //not god

	// [Space(10)]
	[Header("Areas to instantiate")]
	private GameObject[] placesToInstantiate;
	// public GameObject leftAreaToInstantiate;
	// public GameObject rightAreaToInstantiate;
	// public GameObject middleAreaToInstantiate;

	void Start () {
		GameObject[] objs = GameObject.FindGameObjectsWithTag("AreasToInstantiate");	
		areas = new AreaScript[objs.Length];
		for (int i = 0; i < objs.Length; i++){
			areas[i] = objs[i].GetComponent<AreaScript>();
		}
		
		Debug.Log("AreaScript.lenght= " + areas.Length);
		for (int i = 0; i < areas.Length; i++){
			Debug.Log(areas[i].gameObject.name);
			Debug.Log(areas[i].GetRandomPositionInsideArea());
		}
		
		gpParent = GameObject.Find("Humanity");
		
		for (int i = 0;i<20;i++){
			GameObject obj = Instantiate(gpPrefab,Vector3.zero,Quaternion.identity);
			obj.GetComponent<GenericPersonMov>().InstantiateGenericPerson(this.GetStartAndEndPosition(true));
			obj.transform.SetParent(gpParent.transform);
		}
		for (int i = 0;i<20;i++){
			GameObject obj = Instantiate(gpPrefab,Vector3.zero,Quaternion.identity);
			obj.GetComponent<GenericPersonMov>().InstantiateGenericPerson(this.GetStartAndEndPosition(false));
			obj.transform.SetParent(gpParent.transform);
		}
	}

	///<summary>
	/// return 2 vec3 with start and end position, inside lateral areas, 
	/// for the generic person to move.
	///</summary>
	private Vector3[] GetStartAndEndPosition(){
		return GetStartAndEndPosition(false);
	}
	
	///<summary>
	/// return 2 vec3 with start and end position for the generic person
	/// to move.
	///</summary>
	///<param name="InstantiateInMiddle"> should instantiate in middle of map </param>
	private Vector3[] GetStartAndEndPosition(bool InstantiateInMiddle){
		Vector3 startPos;
		Vector3 endPos;

		int option = Random.Range(0,2);
		
		if (option==0){
			startPos = areas[0].GetRandomPositionInsideArea();
			endPos = areas[1].GetRandomPositionInsideArea();
		}else{
			startPos = areas[1].GetRandomPositionInsideArea();
			endPos = areas[0].GetRandomPositionInsideArea();
		}
		// get point inside map area
		if (InstantiateInMiddle){
			startPos = areas[2].GetRandomPositionInsideArea();
		}

		return new Vector3[] {startPos,endPos};
	}
}
