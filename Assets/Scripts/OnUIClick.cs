using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUIClick : MonoBehaviour {

	// public bool hasBeenClicked;
	
	private ClickManager clickManager;

	void Start() {
		clickManager = ClickManager.instance;
	}

	public void RedFlagButtonClick() {
		// clickManager.RedFlagButtonClick();
		clickManager.FlagButtonClick(Utils.FlagColor.red);

	}
	
	public void GreenFlagButtonClick() {
		// clickManager.GreenFlagButtonClick();
		clickManager.FlagButtonClick(Utils.FlagColor.green);
	}
	
	public void YellowFlagButtonClick() {
		// clickManager.YellowFlagButtonClick();
		clickManager.FlagButtonClick(Utils.FlagColor.yellow);
	}

	public void WhistleButtonClick() {
		// clickManager.GreenFlagButtonClick();
		clickManager.WhistleButtonClick();
	}


}
