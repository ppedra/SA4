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
		clickManager.FlagButtonClick(Utils.FlagColor.Red);

	}
	
	public void GreenFlagButtonClick() {
		// clickManager.GreenFlagButtonClick();
		clickManager.FlagButtonClick(Utils.FlagColor.Green);
	}
	
	public void YellowFlagButtonClick() {
		// clickManager.YellowFlagButtonClick();
		clickManager.FlagButtonClick(Utils.FlagColor.Yellow);
	}

	public void WhistleButtonClick() {
		// clickManager.GreenFlagButtonClick();
		clickManager.WhistleButtonClick();
	}


}
