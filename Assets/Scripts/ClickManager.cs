using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour {

	public ClickManager instance;
	public ManageFlagInstantiation flagManager;
	
	// Player
	public GameObject playerGameObject;
	private BasicMoviment playerMoviment;

	bool redFlagClicked;
	bool yellowFlagClicked;
	bool greenFlagClicked;

	void Awake() {
		if (instance == null){
			instance = this;
		}
	}


	void Start () {
		flagManager = this.GetComponent<ManageFlagInstantiation>();

		if (playerGameObject == null){
			playerGameObject = GameObject.Find("Player");
		}
		playerMoviment = playerGameObject.GetComponent<BasicMoviment>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if (redFlagClicked){
				//place flag

			} else {
				//lifeguard walk
				playerMoviment.PlayerMoveTo(worldPoint);
			}
		}
	}

	#region FlagBoolSetters
	public void RedFlagButtonClick(){
		redFlagClicked = !redFlagClicked;
	}
	public void GreenFlagButtonClick() {
		greenFlagClicked = !greenFlagClicked;
	}
	
	public void YellowFlagButtonClick() {
		yellowFlagClicked = !yellowFlagClicked;
	}
	#endregion

}
