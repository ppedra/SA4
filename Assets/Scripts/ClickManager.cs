using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Utils;

public class ClickManager : MonoBehaviour {

	public static ClickManager instance;
	// public ManageFlagInstantiation flagManager;
	public FlagInstantiator flagManager;
	
	// Player
	public GameObject playerGameObject;
	private BasicMoviment playerMoviment;

	//bool for ui
	[Header("Flags bool")]
	public bool redFlagClicked;
	public bool yellowFlagClicked;
	public bool greenFlagClicked;

	IEnumerator movimentControlCoroutine;

	void Awake() {
		if (instance == null){
			instance = this;
		}
	}


	void Start () {
		flagManager = this.GetComponent<FlagInstantiator>();

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
				Debug.Log("Move Player to place the flag!");
				MovePlayerToPlaceFlag(FlagColor.red,worldPoint);

			} else if (!EventSystem.current.IsPointerOverGameObject()){
				//lifeguard walk if mouse/click is not over the ui
				Debug.Log("Move Player!");
				playerMoviment.PlayerMoveTo(worldPoint);
			}
		}
	}

	void MovePlayerToPlaceFlag(FlagColor color,Vector2 worldPoint){
		/*
		 * move player (if needed, this is checked in player moviment coroutine)
		 * to click position and place a flag there
		 */
		movimentControlCoroutine = MovePlayerToPlaceFlagCoroutine(color,worldPoint);
		StartCoroutine(movimentControlCoroutine);
	}

	IEnumerator MovePlayerToPlaceFlagCoroutine(FlagColor color,Vector2 worldPoint){
		//wait for move player to position
		yield return playerMoviment.PlayerMoveTo(worldPoint);
		//skip a frame
		yield return null;
		
		flagManager.InstantiateFlag(color,worldPoint);

		yield return null;
		this.RedFlagButtonClick();
	}

	#region FlagBoolSetters
	public void RedFlagButtonClick(){
		redFlagClicked = !redFlagClicked;
		Debug.Log("redFlagClicked:" + redFlagClicked);
	}
	public void GreenFlagButtonClick() {
		greenFlagClicked = !greenFlagClicked;
		Debug.Log("greenFlagClicked:" + greenFlagClicked);

	}
	
	public void YellowFlagButtonClick() {
		yellowFlagClicked = !yellowFlagClicked;
		Debug.Log("yellowFlagClicked:" + yellowFlagClicked);

	}
	#endregion

}
