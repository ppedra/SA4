using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonInstantiator : MonoBehaviour {

	[Space(10)]
	//generic person walking arround
	public GameObject gpPrefab;
	//bathing person. start in the sea
	public GameObject bpPrefab;
	//parent object for persons
	public GameObject gpParent; 

	// [Space(10)]
	[Header("Areas to instantiate")]
	public AreaScript AreaLeft;
	public AreaScript AreaRight;
	public AreaScript AreaInsideSand;
	public AreaScript AreaInsideSea;

	public static PersonInstantiator instance;

	[Header("Person #")]
	public int peopleOnSand;
	public int peopleOffMap;
	public int peopleInSea;

	void Start () {
		if (instance == null){
			instance = this;
		}
		
		gpParent = GameObject.Find("Humanity");
		
		this.InstantiateGP(peopleOnSand,peopleOffMap,gpParent);
		this.InstantiateBP(peopleInSea,gpParent);
	}

	///<summary>
	/// intantiate generic person on and off map and set parent
	///</summary>
	///<param name="onSand"> num of people instantiate on sand area</param>
	///<param name="offMap"> num of people instantiate on outside the map</param>
	///<param name="newParent"> new parent in project hierarchy</param>
	private void InstantiateGP(int onSand, int offMap,GameObject newParent){
		GameObject obj;
		for (int i = 0; i<onSand; i++){
			obj = Instantiate(gpPrefab,Vector3.zero,Quaternion.identity);
			obj.GetComponent<GPStateMachineHandler>().InstantiatePerson(this.GetStartAndEndPosition(true));
			if (newParent != null){
				obj.transform.SetParent(newParent.transform);
			}			
			obj.SetActive(true);
		}
		for (int i = 0; i<offMap; i++){
			obj = Instantiate(gpPrefab,Vector3.zero,Quaternion.identity);
			obj.GetComponent<GPStateMachineHandler>().InstantiatePerson(this.GetStartAndEndPosition(false));
			if (newParent != null){
				obj.transform.SetParent(newParent.transform);
			}			
			obj.SetActive(true);
		}
	}

	///<summary>
	/// intantiate bathing person on water.
	///</summary>
	///<param name="onWater"> num of people instantiate on sand area</param>
	///<param name="newParent"> new parent in project hierarchy</param>
	private void InstantiateBP(int onWater,GameObject newParent){
		for (int i = 0;i<onWater;i++){
			GameObject obj = Instantiate(bpPrefab,Vector3.zero,Quaternion.identity);
			obj.GetComponent<BPStateMachineHandler>().InstantiatePerson(this.GetStartPositionAtSea());
			if (newParent != null){
				obj.transform.SetParent(newParent.transform);
			}
			obj.SetActive(true);
		}
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
	public Vector3[] GetStartAndEndPosition(){
		return GetStartAndEndPosition(false);
	}
	
	///<summary>
	/// return 2 vec3 with start and end position for the generic person
	/// to move.
	///</summary>
	///<param name="InstantiateInMiddle"> should instantiate in middle of map </param>
	public Vector3[] GetStartAndEndPosition(bool InstantiateInMiddle){
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
	
	///<summary>
	/// instantiate # num of personPrefabs in area given by AreaScript and set new parent to newParent
	///</summary>
	///<param name='personPrefab'>prefab to be instantiate</param>
	///<param name='area'>area given by script</param>
	///<param name='num'>numebers of person</param>
	///<param name='newParent'>game object to be the new parent</param>
	private void InstantiatePersonToComeToArea(GameObject personPrefab, AreaScript area, int num, GameObject newParent){
		for (int i = 0;i<num;i++){
			GameObject obj = Instantiate(personPrefab,Vector3.zero,Quaternion.identity);
			
			Vector3[] positions = GetStartAndEndPosition(false);
			positions[1] = area.GetRandomPositionInsideArea();

			obj.GetComponent<BPStateMachineHandler>().InstantiatePerson(positions);
			if (newParent != null){
				obj.transform.SetParent(newParent.transform);
			}
			obj.SetActive(true);
		}
	}

	///<summary>
	/// Instantiate # bpPerson in area given by script
	///</summary>
	///<param name='area'>AreaScript with info</param>
	///<param name='num'>num of persons been instantiated in area</param>
	public void InstantiateBPToComeToArea(AreaScript area,int num){
		InstantiatePersonToComeToArea(bpPrefab,area,num,gpParent);
	}

	///<summary>
	/// Instantiate random(2,5) bpPerson in area given by script
	///</summary>
	///<param name='area'>AreaScript with info</param>
	public void InstantiateBPToComeToArea(AreaScript area){
		// InstantiatePersonToComeToArea(bpPrefab,area,Random.Range(2,5),gpParent);
	}

}
