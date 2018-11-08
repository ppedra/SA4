using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour {

	public Utils.FlagColor flagColor;
	
	[Header("Flag Sprites")]
	public Sprite greenFlagSriteCorrect;
	public Sprite greenFlagSriteWrong;
	public Sprite redFlagSriteCorrect;
	public Sprite redFlagSriteWrong;
	public SpriteRenderer spriteRenderer;
	
	[Header("Act Collider")]
	public BoxCollider2D actArea;
	
	public LayerMask mask;

	private void Start() {
		// actArea = this.GetComponentInChildren<BoxCollider2D>();
		// spriteRenderer = this.Get	ComponentInChildren<SpriteRenderer>();
		
	}

	///<summary>
	/// Set initial information for flag. Something like a constructor (Monobehaviour script forbids constructor) 
	///</summary>
	///<param name='color'>color to set sprite and action</param>
	///<param name='correctFlag'>bool for decide sprite (correct or wrong)</param>
	public void Init(Utils.FlagColor color, bool isCorrectFlag){
		flagColor = color;
		this.SetSprite(color,isCorrectFlag);
		this.FlagAction(flagColor);
	}

	void SetSprite(Utils.FlagColor color, bool isCorrectFlag){
		if (color == Utils.FlagColor.Red){
			if (isCorrectFlag){
				spriteRenderer.sprite = this.redFlagSriteCorrect;
			}else{
				spriteRenderer.sprite = this.redFlagSriteWrong;
			}
		}else if(color == Utils.FlagColor.Green){
			if (isCorrectFlag){
				spriteRenderer.sprite = this.greenFlagSriteCorrect;
			}else{
				spriteRenderer.sprite = this.greenFlagSriteWrong;
			}
		}
	}

	///<summary>
	/// checks color and do action of the right color
	///</summary>
	///<param name='Color'> color of the flag</param>
	private void FlagAction(Utils.FlagColor color){
		if (color == Utils.FlagColor.Red){
			FlagRedAction();
		}else if (color == Utils.FlagColor.Green){
			FlagGreenAction();
		}
	}

	///<summary>
	/// Find all persons in the collider2D and 'hit' (animation trigger) on them, so them leave that area
	///</summary>
	private void FlagRedAction(){
		Collider2D[] personsInArea = Physics2D.OverlapAreaAll(actArea.bounds.max, actArea.bounds.min, mask);
		Debug.Log(personsInArea.Length);
		foreach(Collider2D personCollider in personsInArea){
			personCollider.gameObject.GetComponent<BPStateMachineHandler>().InRedFlagArea();
		}
	}

	///<summary>
	/// instantiate people outside map and call them to flag area 
	///</summary>
	private void FlagGreenAction(){
		AreaScript areaScript = actArea.gameObject.GetComponent<AreaScript>();
		PersonInstantiator.instance.InstantiateBPToComeToArea(areaScript);
	}


}
