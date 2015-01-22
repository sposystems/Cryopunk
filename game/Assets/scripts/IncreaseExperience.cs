using UnityEngine;
using System.Collections;

public static class IncreaseExperience {
	private static int xpToGive;
	private static LevelUp levelUpScript = new LevelUp();
	public static void AddExperience(){
		xpToGive = GameInformation.PlayerLevel * 100;
		GameInformation.CurrentXP += xpToGive;
		CheckToSeeIfPlayerLevel ();
		Debug.Log (xpToGive);
	}
	public static void AddExperienceFromBattleLoss(){
		xpToGive = GameInformation.PlayerLevel * 10;
		GameInformation.CurrentXP += xpToGive;
		CheckToSeeIfPlayerLevel ();
	}
	private static void CheckToSeeIfPlayerLevel(){
		if (GameInformation.CurrentXP >= GameInformation.RequiredXP) {
			//level up! Create level up script
			levelUpScript.LevelUpCharacter();
			
		}


	}

}
