using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
	public enum FlagColor {Red,Yellow,Green,None};

	///<summary>
	/// something like low, medium or high infringement but also
	/// low, medium or high reward
	///</summary>
	public enum ScoreIntensity {Low,Medium,High}

	public class Values{
		public static float distanceToWhistle = 5f;
	}
}
