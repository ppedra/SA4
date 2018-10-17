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
		clickManager.RedFlagButtonClick();
	}
	
	public void GreenFlagButtonClick() {
		clickManager.GreenFlagButtonClick();
	}
	
	public void YellowFlagButtonClick() {
		clickManager.YellowFlagButtonClick();
	}


}
