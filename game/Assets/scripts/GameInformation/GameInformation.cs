using UnityEngine;
using System.Collections;

public class GameInformation : MonoBehaviour {

	void awake(){
		DontDestroyOnLoad (transform.gameObject);//keeps this object every time scene changes
		}
	public static BaseEquipment EquipmentOne{ get; set; }

	public static string PlayerName{ get; set; }
	
	public static int PlayerLevel{ get; set; }
	public static BaseCharacterClass PlayerClass{ get; set; }
	public static int Stamina{ get; set; }
	public static int Endurance{ get; set; }
	public static int Intellect{ get; set; }
	public static int Strength{ get; set; }
	public static int CurrentXP{ get; set; }
	public static int RequiredXP{ get; set; }

}
