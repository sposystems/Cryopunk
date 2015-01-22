using UnityEngine;
using System.Collections;

public class SaveInformation{
	public static void SaveAllInformation(){
		PlayerPrefs.SetInt("PLAYERLEVEL", GameInformation.PlayerLevel);
		PlayerPrefs.SetString ("PLAYERNAME", GameInformation.PlayerName);
		PlayerPrefs.SetInt("PLAYERSTAMINA", GameInformation.Stamina);
		PlayerPrefs.SetInt("PLAYERENDURANCE", GameInformation.Endurance);
		PlayerPrefs.SetInt("PLAYERINTELLECT", GameInformation.Intellect);
		PlayerPrefs.SetInt("PLAYERSTRENGTH", GameInformation.Strength);
		if (GameInformation.EquipmentOne != null) {
						PPSerialization.Save ("EQUIPMENTITEM1", GameInformation.EquipmentOne);
				}
			Debug.Log ("Saved all information");
	}
}
