using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleGUI : MonoBehaviour {

	public Text player1Name;
	public Text player1HP;
	public Text player1SP;
	public Text player1Status;
	public Button player1Ability1;
	public Button player1Ability2;
	public Button player1Ability3;
	public Text player2Name;
	public Text player2HP;
	public Text player2SP;
	public Text player2Status;
	public Button player2Ability1;
	public Button player2Ability2;
	public Button player2Ability3;
	public Text player3Name;
	public Text player3HP;
	public Text player3SP;
	public Text player3Status;
	public Button player3Ability1;
	public Button player3Ability2;
	public Button player3Ability3;
	public Text player4Name;
	public Text player4HP;
	public Text player4SP;
	public Text player4Status;
	public Button player4Ability1;
	public Button player4Ability2;
	public Button player4Ability3;
	public Text player5Name;
	public Text player5HP;
	public Text player5SP;
	public Text player5Status;
	public Button player5Ability1;
	public Button player5Ability2;
	public Button player5Ability3;
	public Text enemy1Name;
	public Text enemy1HP;
	public Text enemy1Status;
	public Text enemy2Name;
	public Text enemy2HP;
	public Text enemy2Status;
	public Text enemy3Name;
	public Text enemy3HP;
	public Text enemy3Status;
	public Text enemy4Name;
	public Text enemy4HP;
	public Text enemy4Status;
	public Text enemy5Name;
	public Text enemy5HP;
	public Text enemy5Status;

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
		player1HP.text = "HP: " + player1Character.GetHP() + "/" + player1Character.maxHp;
		player1SP.text = "SP: " + player1Character.GetSP() + "/" + player1Character.maxSp;
		player1Status.text = GetStatus(player1Character);
		
		player2Name.text = player2Character.characterName;
		player2HP.text = "HP: " + player2Character.GetHP() + "/" + player2Character.maxHp;
		player2SP.text = "SP: " + player2Character.GetSP() + "/" + player2Character.maxSp;
		player2Status.text = GetStatus(player2Character);
		
		player3Name.text = player3Character.characterName;
		player3HP.text = "HP: " + player3Character.GetHP() + "/" + player3Character.maxHp;
		player3SP.text = "SP: " + player3Character.GetSP() + "/" + player3Character.maxSp;
		player3Status.text = GetStatus(player3Character);
		
		player4Name.text = player4Character.characterName;
		player4HP.text = "HP: " + player4Character.GetHP() + "/" + player4Character.maxHp;
		player4SP.text = "SP: " + player4Character.GetSP() + "/" + player4Character.maxSp;
		player4Status.text = GetStatus(player4Character);
		
		if (player5Character != null) {
			player5Name.text = player5Character.characterName;
			player5HP.text = "HP: " + player5Character.GetHP() + "/" + player5Character.maxHp;
			player5SP.text = "SP: " + player5Character.GetSP() + "/" + player5Character.maxSp;
			player5Status.text = GetStatus(player5Character);
		}
		
		if (enemy1Character != null) {
			enemy1Name.text = enemy1Character.characterName;
			enemy1HP.text = "HP: " + enemy1Character.GetHP() + "/" + enemy1Character.maxHp;
			enemy1Status.text = GetStatus(enemy1Character);
		}
		
		if (enemy2Character != null) {
			enemy2Name.text = enemy2Character.characterName;
			enemy2HP.text = "HP: " + enemy2Character.GetHP() + "/" + enemy2Character.maxHp;
			enemy2Status.text = GetStatus(enemy2Character);
		}
		
		if (enemy3Character != null) {
			enemy3Name.text = enemy3Character.characterName;
			enemy3HP.text = "HP: " + enemy3Character.GetHP() + "/" + enemy3Character.maxHp;
			enemy3Status.text = GetStatus(enemy3Character);
		}
		
		if (enemy4Character != null) {
			enemy4Name.text = enemy4Character.characterName;
			enemy4HP.text = "HP: " + enemy4Character.GetHP() + "/" + enemy4Character.maxHp;
			enemy4Status.text = GetStatus(enemy4Character);
		}
		
		if (enemy5Character != null) {
		enemy5Name.text = enemy5Character.characterName;
			enemy5HP.text = "HP: " + enemy5Character.GetHP() + "/" + enemy5Character.maxHp;
			enemy5Status.text = GetStatus(enemy5Character);
		}
	}

	public void DisableButtons() {
		player1Ability1.interactable = false;
		player1Ability1.image.fillCenter = true;
		player1Ability2.interactable = false;
		player1Ability2.image.fillCenter = true;
		player1Ability3.interactable = false;
		player1Ability3.image.fillCenter = true;
		player2Ability1.interactable = false;
		player2Ability1.image.fillCenter = true;
		player2Ability2.interactable = false;
		player2Ability2.image.fillCenter = true;
		player2Ability3.interactable = false;
		player2Ability3.image.fillCenter = true;
		player3Ability1.interactable = false;
		player3Ability1.image.fillCenter = true;
		player3Ability2.interactable = false;
		player3Ability2.image.fillCenter = true;
		player3Ability3.interactable = false;
		player3Ability3.image.fillCenter = true;
		player4Ability1.interactable = false;
		player4Ability1.image.fillCenter = true;
		player4Ability2.interactable = false;
		player4Ability2.image.fillCenter = true;
		player4Ability3.interactable = false;
		player4Ability3.image.fillCenter = true;
		player5Ability1.interactable = false;
		player5Ability1.image.fillCenter = true;
		player5Ability2.interactable = false;
		player5Ability2.image.fillCenter = true;
		player5Ability3.interactable = false;
		player5Ability3.image.fillCenter = true;
	}
	
	public void DisablePlayerGUI(int playerNum) {
		if (playerNum == 1) {
			player1HP.gameObject.SetActive(false);
			player1Name.gameObject.SetActive(false);
			player1SP.gameObject.SetActive(false);
			player1Ability1.gameObject.SetActive(false);
			player1Ability2.gameObject.SetActive(false);
			player1Ability3.gameObject.SetActive(false);
			player1Status.gameObject.SetActive(false);
		} else if (playerNum == 2) {
			player2HP.gameObject.SetActive(false);
			player2Name.gameObject.SetActive(false);
			player2SP.gameObject.SetActive(false);
			player2Ability1.gameObject.SetActive(false);
			player2Ability2.gameObject.SetActive(false);
			player2Ability3.gameObject.SetActive(false);
			player2Status.gameObject.SetActive(false);
		} else if (playerNum == 3) {
			player3HP.gameObject.SetActive(false);
			player3Name.gameObject.SetActive(false);
			player3SP.gameObject.SetActive(false);
			player3Ability1.gameObject.SetActive(false);
			player3Ability2.gameObject.SetActive(false);
			player3Ability3.gameObject.SetActive(false);
			player3Status.gameObject.SetActive(false);
		} else if (playerNum == 4) {
			player4HP.gameObject.SetActive(false);
			player4Name.gameObject.SetActive(false);
			player4SP.gameObject.SetActive(false);
			player4Ability1.gameObject.SetActive(false);
			player4Ability2.gameObject.SetActive(false);
			player4Ability3.gameObject.SetActive(false);
			player4Status.gameObject.SetActive(false);
		} else if (playerNum == 5) {
			player5HP.gameObject.SetActive(false);
			player5Name.gameObject.SetActive(false);
			player5SP.gameObject.SetActive(false);
			player5Ability1.gameObject.SetActive(false);
			player5Ability2.gameObject.SetActive(false);
			player5Ability3.gameObject.SetActive(false);
			player5Status.gameObject.SetActive(false);
		}
	}
	
	public void DisableEnemyGUI(int enemyNum) {
		if (enemyNum == 1) {
			enemy1HP.gameObject.SetActive(false);
			enemy1Name.gameObject.SetActive(false);
			enemy1Status.gameObject.SetActive(false);
		} else if (enemyNum == 2) {
			enemy2HP.gameObject.SetActive(false);
			enemy2Name.gameObject.SetActive(false);
			enemy2Status.gameObject.SetActive(false);
		} else if (enemyNum == 3) {
			enemy3HP.gameObject.SetActive(false);
			enemy3Name.gameObject.SetActive(false);
			enemy3Status.gameObject.SetActive(false);
		} else if (enemyNum == 4) {
			enemy4HP.gameObject.SetActive(false);
			enemy4Name.gameObject.SetActive(false);
			enemy4Status.gameObject.SetActive(false);
		} else if (enemyNum == 5) {
			enemy5HP.gameObject.SetActive(false);
			enemy5Name.gameObject.SetActive(false);
			enemy5Status.gameObject.SetActive(false);
		}
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
			player.ability1.GetComponent<Targeter>().EnableTargets(button);
			break;
		case "Ability 2 Button":
			player.ability2.GetComponent<Targeter>().EnableTargets(button);
			break;
		case "Ability 3 Button":
			player.ability3.GetComponent<Targeter>().EnableTargets(button);
			break;
		}

	}
	
	public void InitializeGUI() {
		controller = gameObject.GetComponent<BattleController>();
		
		player1Character = controller.GetPlayer(1);
		if(player1Character != null) {
			player1Ability1.GetComponentInChildren<Text>().text = player1Character.ability1.abilityName;
			player1Ability2.GetComponentInChildren<Text>().text = player1Character.ability2.abilityName;
			player1Ability3.GetComponentInChildren<Text>().text = player1Character.ability3.abilityName;
		}
		
		player2Character = controller.GetPlayer(2);
		if(player2Character != null) {
			player2Ability1.GetComponentInChildren<Text>().text = player2Character.ability1.abilityName;
			player2Ability2.GetComponentInChildren<Text>().text = player2Character.ability2.abilityName;
			player2Ability3.GetComponentInChildren<Text>().text = player2Character.ability3.abilityName;
		}
		
		player3Character = controller.GetPlayer(3);
		if(player3Character != null) {
			player3Ability1.GetComponentInChildren<Text>().text = player3Character.ability1.abilityName;
			player3Ability2.GetComponentInChildren<Text>().text = player3Character.ability2.abilityName;
			player3Ability3.GetComponentInChildren<Text>().text = player3Character.ability3.abilityName;
		}
		
		player4Character = controller.GetPlayer(4);
		if(player4Character != null) {
			player4Ability1.GetComponentInChildren<Text>().text = player4Character.ability1.abilityName;
			player4Ability2.GetComponentInChildren<Text>().text = player4Character.ability2.abilityName;
			player4Ability3.GetComponentInChildren<Text>().text = player4Character.ability3.abilityName;
		}
		
		player5Character = controller.GetPlayer(5);
		if(player5Character != null) {
			player5Ability1.GetComponentInChildren<Text>().text = player5Character.ability1.abilityName;
			player5Ability2.GetComponentInChildren<Text>().text = player5Character.ability2.abilityName;
			player5Ability3.GetComponentInChildren<Text>().text = player5Character.ability3.abilityName;
		}
		
		enemy1Character = controller.GetEnemy(1);
		enemy2Character = controller.GetEnemy(2);
		enemy3Character = controller.GetEnemy(3);
		enemy4Character = controller.GetEnemy(4);
		enemy5Character = controller.GetEnemy(5);
	}
	
	private string GetStatus(Character character) {
		string status = "";
		if (character.IsSilenced()) {
			status += "SILENCED ";
		}
		if (character.IsStealth()) {
			status += "STEALTH ";
		}
		if (character.IsStunned()) {
			status += "STUNNED ";
		}
		if (character.IsBuffed()) {
			status += "BUFFED ";
		}
		if (character.IsDraining()) {
			status += "POISONED ";
		}
		if (character.IsCursed()) {
			status += "CURSED ";
		}
		return status;
	}
}