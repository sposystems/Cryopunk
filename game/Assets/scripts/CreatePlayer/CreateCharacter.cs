using UnityEngine;
using System.Collections;

public class CreateCharacter : MonoBehaviour {

	private BasePlayer newPlayer;
	private bool isMageClass;
	private bool isWarriorClass;
	private string playerName = "EnterName";
	void Start () {
		newPlayer = new BasePlayer();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		playerName = GUILayout.TextArea (playerName, 15);
		isMageClass = GUILayout.Toggle (isMageClass, "Mage Class");
		isWarriorClass = GUILayout.Toggle(isWarriorClass,"Warrior Class");
		if(GUILayout.Button("Create")){
			if(isMageClass){
				newPlayer.PlayerClass = new BaseMageClass();

			
			} else if(isWarriorClass){
				newPlayer.PlayerClass = new BaseWarriorClass();
				
				
			}
			newPlayer.PlayerLevel = 1;
			newPlayer.Stamina = newPlayer.PlayerClass.Stamina;
			newPlayer.Endurance = newPlayer.PlayerClass.Endurance;
			newPlayer.Intellect = newPlayer.PlayerClass.Intellect;
			newPlayer.Strength = newPlayer.PlayerClass.Strength;

			newPlayer.PlayerName=playerName;
			StoreNewPlayerInfo();
			SaveInformation.SaveAllInformation();
			Debug.Log("Player class: " + newPlayer.PlayerClass.CharacterClassName);
			Debug.Log("Player name: " + newPlayer.PlayerName);

		}
		if (GUILayout.Button ("Load")) {
			Application.LoadLevel("testTown1");
		}
	}
	private void StoreNewPlayerInfo(){
		GameInformation.PlayerName = newPlayer.PlayerName;
		GameInformation.PlayerLevel = newPlayer.PlayerLevel;
		GameInformation.Stamina = newPlayer.Stamina;
		GameInformation.Endurance = newPlayer.Endurance;
		GameInformation.Intellect = newPlayer.Intellect;
		GameInformation.Strength = newPlayer.Strength;
	}
}
