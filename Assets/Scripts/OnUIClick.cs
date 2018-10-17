using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUIClick : MonoBehaviour {

	// public bool hasBeenClicked;
	
	private ManageFlagInstantiation flagManager;
	private ClickManager clickManager;

	void Start() {
		flagManager = ManageFlagInstantiation.instance;

	}

	public void RedFlagButtonClick() {
		clickManager.RedFlagButtonClick();
	}
	
	public void GreenFlagButtonClick() {
		clickManager.GreenFlagButtonClick();
	}
	
	public void YellowFlagButtonClick() {
		clickManager.YellowFlagButtonClick();
	}


}
