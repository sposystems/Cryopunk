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
	private GameObject player1;
	private Character player1Character;
	private GameObject player2;
	private Character player2Character;
	private GameObject player3;
	private Character player3Character;
	private GameObject player4;
	private Character player4Character;
	private GameObject player5;
	private Character player5Character;
	private GameObject enemy1;
	private Character enemy1Character;
	private GameObject enemy2;
	private Character enemy2Character;
	private GameObject enemy3;
	private Character enemy3Character;
	private GameObject enemy4;
	private Character enemy4Character;
	private GameObject enemy5;
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
			player = controller.getPlayer(1);
			break;
		case "Player 2":
			player = controller.getPlayer(2);
			break;
		case "Player 3":
			player = controller.getPlayer(3);
			break;
		case "Player 4":
			player = controller.getPlayer(4);
			break;
		case "Player 5":
			player = controller.getPlayer(5);
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

	//called on object creation, sets up references
	private void Awake() {
		controller = gameObject.GetComponent<BattleController>();

		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

		//references are gotten based on character's z-coordinate. leftmost character is player 1

		foreach (GameObject player in players) {
			switch((int)player.transform.position.z) {
			case -8:
				player1 = player;
				player1Character = player1.GetComponent<Character>();
				break;
			case -4:
				player2 = player;
				player2Character = player2.GetComponent<Character>();
				break;
			case 0:
				player3 = player;
				player3Character = player3.GetComponent<Character>();
				break;
			case 4:
				player4 = player;
				player4Character = player4.GetComponent<Character>();
				break;
			case 8:
				player5 = player;
				player5Character = player5.GetComponent<Character>();
				break;
			}
		}

		foreach (GameObject enemy in enemies) {
			switch((int)enemy.transform.position.z) {
			case -8:
				enemy1 = enemy;
				enemy1Character = enemy1.GetComponent<Character>();
				break;
			case -4:
				enemy2 = enemy;
				enemy2Character = enemy2.GetComponent<Character>();
				break;
			case 0:
				enemy3 = enemy;
				enemy3Character = enemy3.GetComponent<Character>();
				break;
			case 4:
				enemy4 = enemy;
				enemy4Character = enemy4.GetComponent<Character>();
				break;
			case 8:
				enemy5 = enemy;
				enemy5Character = enemy5.GetComponent<Character>();
				break;
			}
		}

		// set up on clicks
		
	}

}