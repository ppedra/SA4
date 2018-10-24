using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPersonInstantiator : MonoBehaviour {

	AreaScript[] areas;
	[Space(10)]
	public GameObject genericPersonPrefab;
	public GameObject genericPersonParent; //not god

	void Start () {
		GameObject[] objs = GameObject.FindGameObjectsWithTag("TriggersOutsideMap");
		areas = new AreaScript[objs.Length];
		for (int i = 0; i < objs.Length; i++){
			areas[i] = objs[i].GetComponent<AreaScript>();
		}
		Debug.Log("AreaScript.lenght= " + areas.Length);

		genericPersonParent = GameObject.Find("Humanity");
		
		
		for (int i = 0;i<20;i++){
			GameObject obj = Instantiate(genericPersonPrefab,Vector3.zero,Quaternion.identity);
			obj.GetComponent<GenericPersonMov>().InstantiateGenericPerson(this.GetStartAndEndPosition());
			obj.transform.SetParent(genericPersonParent.transform	);
		}
	}
	
	///<summary>
	/// return 2 vec3 with start and end position for the generic person
	/// to move
	///</summary>
	public Vector3[] GetStartAndEndPosition(){
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

		return new Vector3[] {startPos,endPos};
	}
}
