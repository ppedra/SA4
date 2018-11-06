using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPersonInstantiator : MonoBehaviour {

	// AreaScript[] areas;

	[Space(10)]
	//generic person walking arround
	public GameObject gpPrefab;
	//bathing person. start in the sea
	public GameObject bpPrefab;
	public GameObject gpParent; //not god

	// [Space(10)]
	[Header("Areas to instantiate")]
	// public GameObject[] placesToInstantiate;
	// public Dictionary<string,AreaScript> areaToInstantiate;
	public AreaScript AreaLeft;
	public AreaScript AreaRight;
	public AreaScript AreaInsideSand;
	public AreaScript AreaInsideSea;



	void Start () {
		// GameObject[] placesToInstantiate = GameObject.FindGameObjectsWithTag("AreasToInstantiate");	
		// areas = new AreaScript[placesToInstantiate.Length];

		// // areaToInstantiate = new Dictionary<string, AreaScript>();
		// for (int i = 0; i < placesToInstantiate.Length; i++){
		// 	// areas[i] = placesToInstantiate[i].GetComponent<AreaScript>();
		// 	areaToInstantiate.Add(placesToInstantiate[i].name,placesToInstantiate[i].GetComponent<AreaScript>());
		// }
		
		// Debug.Log("AreaScript.lenght= " + areas.Length);
		// for (int i = 0; i < areas.Length; i++){
		// 	// Debug.Log(areaToInstantiate[i].gameObject.name);
		// 	// Debug.Log(areas[i].GetRandomPositionInsideArea());
		// }
		
		gpParent = GameObject.Find("Humanity");

		GameObject obj = Instantiate(gpPrefab,Vector3.zero,Quaternion.identity);
		obj.GetComponent<GPStateMachineHandler>().InstantiatePerson(this.GetStartAndEndPosition(false));
		obj.transform.SetParent(gpParent.transform);
		obj.SetActive(true);
		for (int i = 0;i<20;i++){
			obj = Instantiate(gpPrefab,Vector3.zero,Quaternion.identity);
			obj.GetComponent<GPStateMachineHandler>().InstantiatePerson(this.GetStartAndEndPosition(true));
			obj.transform.SetParent(gpParent.transform);
			obj.SetActive(true);
		}
		for (int i = 0;i<20;i++){
			obj = Instantiate(gpPrefab,Vector3.zero,Quaternion.identity);
			obj.GetComponent<GPStateMachineHandler>().InstantiatePerson(this.GetStartAndEndPosition(false));
			obj.transform.SetParent(gpParent.transform);
			obj.SetActive(true);
		}
		for (int i = 0;i<20;i++){
			obj = Instantiate(bpPrefab,Vector3.zero,Quaternion.identity);
			obj.GetComponent<BPStateMachineHandler>().InstantiatePerson(this.GetStartPositionAtSea());
			obj.transform.SetParent(gpParent.transform);
			obj.SetActive(true);
		}
	}

	///<summary>
	/// intantiate generic person
	/// for the generic person to move.
	///</summary>
	public void InstantiateGP(){

	}

	///<summary>
	/// return position inside sea area
	///</summary>
	public Vector3[] GetStartPositionAtSea(){
		Vector3[] positions = this.GetStartAndEndPosition(true);
		//change start position for inside the sea
		positions[0] = AreaInsideSea.GetRandomPositionInsideArea();
		Debug.Log(positions[0]);
		return positions;
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
			startPos = AreaRight.GetRandomPositionInsideArea();
			endPos = AreaLeft.GetRandomPositionInsideArea();
		}else{
			startPos = AreaLeft.GetRandomPositionInsideArea();
			endPos = AreaRight.GetRandomPositionInsideArea();
		}
		// get point inside map area
		if (InstantiateInMiddle){
			startPos = AreaInsideSand.GetRandomPositionInsideArea();
		}
		return new Vector3[] {startPos,endPos};
	}
	
}
