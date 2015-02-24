using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleGUI : MonoBehaviour {

	public Text player1Name;
	public Text player1HP;
	public Text player1SP;
	public Button player1Ability1;
	public Button player1Ability2;
	public Text player2Name;
	public Text player2HP;
	public Text player2SP;
	public Button player2Ability1;
	public Button player2Ability2;
	public Text player3Name;
	public Text player3HP;
	public Text player3SP;
	public Button player3Ability1;
	public Button player3Ability2;
	public Text player4Name;
	public Text player4HP;
	public Text player4SP;
	public Button player4Ability1;
	public Button player4Ability2;
	public Text player5Name;
	public Text player5HP;
	public Text player5SP;
	public Button player5Ability1;
	public Button player5Ability2;
	public Text enemy1Name;
	public Text enemy1HP;
	public Text enemy2Name;
	public Text enemy2HP;
	public Text enemy3Name;
	public Text enemy3HP;
	public Text enemy4Name;
	public Text enemy4HP;
	public Text enemy5Name;
	public Text enemy5HP;

	private BattleController controller;
	private Character player1Character;
	private Character player2Character;
	private Character player3Character;
	private Character player4Character;
	private Character player5Character;
	private Character enemy1Character;
	private Character enemy2Character;
	private Character enemy3Character;
	private Character enemy4Character;
	private Character enemy5Character;

	public void UpdateGui() {
		player1Name.text = player1Character.characterName;
		player1HP.text = "HP: " + player1Character.GetHP() + "/" + player1Character.hp;
		player1SP.text = "SP: " + player1Character.GetSP() + "/" + player1Character.sp;
		
		player2Name.text = player2Character.characterName;
		player2HP.text = "HP: " + player2Character.GetHP() + "/" + player2Character.hp;
		player2SP.text = "SP: " + player2Character.GetSP() + "/" + player2Character.sp;
		
		player3Name.text = player3Character.characterName;
		player3HP.text = "HP: " + player3Character.GetHP() + "/" + player3Character.hp;
		player3SP.text = "SP: " + player3Character.GetSP() + "/" + player3Character.sp;
		
		player4Name.text = player4Character.characterName;
		player4HP.text = "HP: " + player4Character.GetHP() + "/" + player4Character.hp;
		player4SP.text = "SP: " + player4Character.GetSP() + "/" + player4Character.sp;
		
		player5Name.text = player5Character.characterName;
		player5HP.text = "HP: " + player5Character.GetHP() + "/" + player5Character.hp;
		player5SP.text = "SP: " + player5Character.GetSP() + "/" + player5Character.sp;
		
		enemy1Name.text = enemy1Character.characterName;
		enemy1HP.text = "HP: " + enemy1Character.GetHP() + "/" + enemy1Character.hp;
		
		enemy2Name.text = enemy2Character.characterName;
		enemy2HP.text = "HP: " + enemy2Character.GetHP() + "/" + enemy2Character.hp;
		
		enemy3Name.text = enemy3Character.characterName;
		enemy3HP.text = "HP: " + enemy3Character.GetHP() + "/" + enemy3Character.hp;
		
		enemy4Name.text = enemy4Character.characterName;
		enemy4HP.text = "HP: " + enemy4Character.GetHP() + "/" + enemy4Character.hp;
		
		enemy5Name.text = enemy5Character.characterName;
		enemy5HP.text = "HP: " + enemy5Character.GetHP() + "/" + enemy5Character.hp;
	}

	public void DisableButtons() {
		player1Ability1.interactable = false;
		player1Ability2.interactable = false;
		player2Ability1.interactable = false;
		player2Ability2.interactable = false;
		player3Ability1.interactable = false;
		player3Ability2.interactable = false;
		player4Ability1.interactable = false;
		player4Ability2.interactable = false;
		player5Ability1.interactable = false;
		player5Ability2.interactable = false;
	}

	//Called onClick(). Calls EnableTargets() for the appropriate ability
	public void BindToTargeter(Button button) {

		Character player = null;
		switch(button.transform.parent.name) {
		case "Player 1":
			player = controller.GetPlayer(1);
			break;
		case "Player 2":
			player = controller.GetPlayer(2);
			break;
		case "Player 3":
			player = controller.GetPlayer(3);
			break;
		case "Player 4":
			player = controller.GetPlayer(4);
			break;
		case "Player 5":
			player = controller.GetPlayer(5);
			break;
		}

		switch(button.name) {
		case "Ability 1 Button":
			player.ability1.GetComponent<Targeter>().EnableTargets();
			break;
		case "Ability 2 Button":
			player.ability2.GetComponent<Targeter>().EnableTargets();
			break;
		}

	}
	
	public void InitializeGUI() {
		controller = gameObject.GetComponent<BattleController>();
		
		player1Character = controller.GetPlayer(1);
		player2Character = controller.GetPlayer(2);
		player3Character = controller.GetPlayer(3);
		player4Character = controller.GetPlayer(4);
		player5Character = controller.GetPlayer(5);
		
		enemy1Character = controller.GetEnemy(1);
		enemy2Character = controller.GetEnemy(2);
		enemy3Character = controller.GetEnemy(3);
		enemy4Character = controller.GetEnemy(4);
		enemy5Character = controller.GetEnemy(5);
		
	}

}