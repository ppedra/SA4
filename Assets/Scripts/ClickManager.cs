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
	[Header("Whistle bool")]
	public bool whistleClicked;

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
	
	void Update () {
		if (Input.GetMouseButtonDown(0)){
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			bool isTouchOverUi = EventSystem.current.IsPointerOverGameObject(0);
			//for the mouse:
			// isTouchOverUi = isTouchOverUi && EventSystem.current.IsPointerOverGameObject();

			if (redFlagClicked && !isTouchOverUi){
				//place flag
				Debug.Log("Move Player to place the flag!");
				MovePlayerToPlaceFlag(FlagColor.red,worldPoint);
				
			} else if (greenFlagClicked && !isTouchOverUi){
				//place flag
				Debug.Log("Move Player to place the flag!");
				MovePlayerToPlaceFlag(FlagColor.green,worldPoint);
			
			} else if (whistleClicked && !isTouchOverUi){
				//raycast to get generic person
				RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero,100);
				if (hit){
					if (hit.collider.gameObject.tag == "GenericPerson"){
						Debug.Log("inside if statement: " + hit.collider.gameObject.name);
						MovePlayerToWhistle(worldPoint,hit.collider.gameObject);
					}					
				}
			} else if (!isTouchOverUi) {
				//lifeguard walk if mouse/click is not over the ui
				Debug.Log("Move Player!");
				playerMoviment.MoveToPosition(worldPoint);
			}
		}
	}

	#region Flag coroutine
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
		yield return playerMoviment.MoveToPosition(worldPoint);
		//skip a frame
		yield return null;
		
		flagManager.InstantiateFlag(color,worldPoint);

		yield return null;
		// this.RedFlagButtonClick();
		ResetAllFlagClickedButThis(color);
	}
	#endregion
	
	#region Whistle coroutine
	void MovePlayerToWhistle(Vector2 worldPoint,GameObject objectToWhistleAt){
		/*
		 * move player (if needed, this is checked in player moviment coroutine)
		 * to click position and place a flag there
		 */
		movimentControlCoroutine = MovePlayerToWhistleCoroutine(worldPoint,objectToWhistleAt);
		StartCoroutine(movimentControlCoroutine);
	}
	

	IEnumerator MovePlayerToWhistleCoroutine(Vector2 worldPoint,GameObject objectToWhistleAt){
		//wait for move player to position
		yield return playerMoviment.MoveToPositionNORAYCAST(worldPoint,Utils.Values.distanceToWhistle);
		// yield return playerMoviment.MoveToPosition(worldPoint,Utils.Values.distanceToWhistle);
		
		//skip a frame
		yield return null;
	
		objectToWhistleAt.GetComponent<Animator>().SetTrigger("whistleHitTrigger");

		yield return null;

		WhistleButtonClick();
	}
	#endregion

	private void ReclickRespectiveFlag(FlagColor color){
		if (color == FlagColor.red){
			RedFlagButtonClick();
		}else if (color == FlagColor.green){
			GreenFlagButtonClick();
		}else if (color == FlagColor.yellow){
			YellowFlagButtonClick();
		}
	}

	private void ResetAllFlagClickedButThis(FlagColor color){
		if (color == FlagColor.red){
			redFlagClicked = !redFlagClicked;
			yellowFlagClicked = false;
			greenFlagClicked = false;
		}else if (color == FlagColor.green){
			redFlagClicked = false;
			yellowFlagClicked = false;
			greenFlagClicked = !greenFlagClicked;
		}else if (color == FlagColor.yellow){
			redFlagClicked = false;
			yellowFlagClicked = !yellowFlagClicked;
			greenFlagClicked = false;
		}
	}

	#region FlagBoolSetters
	public void RedFlagButtonClick(){
		redFlagClicked = !redFlagClicked;
		// ResetAllFlagClickedButThis(FlagColor.red);
		// Debug.Log("redFlagClicked:" + redFlagClicked);
	}
	public void GreenFlagButtonClick() {
		greenFlagClicked = !greenFlagClicked;
		// Debug.Log("greenFlagClicked:" + greenFlagClicked);
	}
	public void YellowFlagButtonClick() {
		yellowFlagClicked = !yellowFlagClicked;
		// Debug.Log("yellowFlagClicked:" + yellowFlagClicked);
	}
	public void WhistleButtonClick() {
		whistleClicked = !whistleClicked;
		// Debug.Log("whistleClicked:" + whistleClicked);
	}
	public void FlagButtonClick(FlagColor color){
		ResetAllFlagClickedButThis(color);
	}
	#endregion

}
