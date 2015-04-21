using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class BattleGUI : MonoBehaviour {

	private DataContainer dc;
	public Text player1Name;
	public Text player1HP;
	public Text player1SP;
	public Text player1Status;
	public Image player1HPBar;
	public Image player1SPBar;
	public Button player1Ability1;
	public Button player1Ability2;
	public Button player1Ability3;
	public Button player1NameBox;
	public Text player2Name;
	public Text player2HP;
	public Text player2SP;
	public Text player2Status;
	public Image player2HPBar;
	public Image player2SPBar;
	public Button player2Ability1;
	public Button player2Ability2;
	public Button player2Ability3;
	public Button player2NameBox;
	public Text player3Name;
	public Text player3HP;
	public Text player3SP;
	public Text player3Status;
	public Image player3HPBar;
	public Image player3SPBar;
	public Button player3Ability1;
	public Button player3Ability2;
	public Button player3Ability3;
	public Button player3NameBox;
	public Text player4Name;
	public Text player4HP;
	public Text player4SP;
	public Text player4Status;
	public Image player4HPBar;
	public Image player4SPBar;
	public Button player4Ability1;
	public Button player4Ability2;
	public Button player4Ability3;
	public Button player4NameBox;
	public Text player5Name;
	public Text player5HP;
	public Text player5SP;
	public Text player5Status;
	public Image player5HPBar;
	public Image player5SPBar;
	public CanvasGroup player5Canvas; //FOR HIDING SOLAN'S STUFF
	public Button player5Ability1;
	public Button player5Ability2;
	public Button player5Ability3;
	public Button player5NameBox;
	public Text enemy1Name;
	public Text enemy1HP;
	public Text enemy1Status;
	public Image enemy1HPBar;
	public Button enemy1NameBox;
	public CanvasGroup enemy1Canvas; //FOR HIDING ENEMY INFO WHEN NOT IN BATTLE
	public Text enemy2Name;
	public Text enemy2HP;
	public Text enemy2Status;
	public Image enemy2HPBar;
	public Button enemy2NameBox;
	public CanvasGroup enemy2Canvas; //FOR HIDING ENEMY INFO WHEN NOT IN BATTLE
	public Text enemy3Name;
	public Text enemy3HP;
	public Text enemy3Status;
	public Image enemy3HPBar;
	public Button enemy3NameBox;
	public CanvasGroup enemy3Canvas; //FOR HIDING ENEMY INFO WHEN NOT IN BATTLE
	public Text enemy4Name;
	public Text enemy4HP;
	public Text enemy4Status;
	public Image enemy4HPBar;
	public Button enemy4NameBox;
	public CanvasGroup enemy4Canvas; //FOR HIDING ENEMY INFO WHEN NOT IN BATTLE
	public Text enemy5Name;
	public Text enemy5HP;
	public Text enemy5Status;
	public Image enemy5HPBar;
	public Button enemy5NameBox;
	public CanvasGroup enemy5Canvas; //FOR HIDING ENEMY INFO WHEN NOT IN BATTLE
	public Text enemyTurnText;

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

	public Button healthPotionButton;
	public Button specialPotionButton;
	public Button lifePotionButton;
	public Button molotovCocktailButton;
	public Button mrFunButton;

	public Text healthPotionQuantity;
	public Text specialPotionQuantity;
	public Text lifePotionQuantity;
	public Text molotovCocktailQuantity;
	public Text mrFunQuantity;
	
	public void UpdateGui() {
		player1Name.text = player1Character.characterName;
		player1HP.text = player1Character.GetHP() + "/" + player1Character.maxHp;
		player1SP.text = player1Character.GetSP() + "/" + player1Character.maxSp;
		player1Status.text = GetStatus(player1Character);
		player1HPBar.fillAmount = (float)player1Character.GetHP () / (float)player1Character.maxHp;
		player1SPBar.fillAmount = (float)player1Character.GetSP () / (float)player1Character.maxSp;
		player1NameBox.enabled = true;
		player1NameBox.interactable = false;
		
		player2Name.text = player2Character.characterName;
		player2HP.text = player2Character.GetHP() + "/" + player2Character.maxHp;
		player2SP.text = player2Character.GetSP() + "/" + player2Character.maxSp;
		player2Status.text = GetStatus(player2Character);
		player2HPBar.fillAmount = (float)player2Character.GetHP () / (float)player2Character.maxHp;
		player2SPBar.fillAmount = (float)player2Character.GetSP () / (float)player2Character.maxSp;
		player2NameBox.enabled = true;
		player2NameBox.interactable = false;
		
		player3Name.text = player3Character.characterName;
		player3HP.text = player3Character.GetHP() + "/" + player3Character.maxHp;
		player3SP.text = player3Character.GetSP() + "/" + player3Character.maxSp;
		player3Status.text = GetStatus(player3Character);
		player3HPBar.fillAmount = (float)player3Character.GetHP () / (float)player3Character.maxHp;
		player3SPBar.fillAmount = (float)player3Character.GetSP () / (float)player3Character.maxSp;
		player3NameBox.enabled = true;
		player3NameBox.interactable = false;
		
		player4Name.text = player4Character.characterName;
		player4HP.text = player4Character.GetHP() + "/" + player4Character.maxHp;
		player4SP.text = player4Character.GetSP() + "/" + player4Character.maxSp;
		player4Status.text = GetStatus(player4Character);
		player4HPBar.fillAmount = (float)player4Character.GetHP () / (float)player4Character.maxHp;
		player4SPBar.fillAmount = (float)player4Character.GetSP () / (float)player4Character.maxSp;
		player4NameBox.enabled = true;
		player4NameBox.interactable = false;
		
		if (player5Character != null) {
			player5Canvas.alpha = 1; //set Solan to visible
			player5Canvas.interactable = true; //set Solan's GUI to interactable
			player5Name.text = player5Character.characterName;
			player5HP.text = player5Character.GetHP() + "/" + player5Character.maxHp;
			player5SP.text = player5Character.GetSP() + "/" + player5Character.maxSp;
			player5Status.text = GetStatus(player5Character);
			player5HPBar.fillAmount = (float)player5Character.GetHP () / (float)player5Character.maxHp;
			player5SPBar.fillAmount = (float)player5Character.GetSP () / (float)player5Character.maxSp;
			player5NameBox.enabled = true;
			player5NameBox.interactable = false;
		}
		
		if (enemy1Character != null) {
			enemy1Canvas.alpha = 1; //set enemy 1 to visible
			enemy1Canvas.interactable = true;
			enemy1Name.text = enemy1Character.characterName;
			enemy1HP.text = enemy1Character.GetHP() + "/" + enemy1Character.maxHp;
			enemy1Status.text = GetStatus(enemy1Character);
			enemy1HPBar.fillAmount = (float)enemy1Character.GetHP () / (float)enemy1Character.maxHp;
			enemy1NameBox.enabled = true;
			enemy1NameBox.interactable = false;
		}
		
		if (enemy2Character != null) {
			enemy2Canvas.alpha = 1; //set enemy 2 to visible
			enemy2Canvas.interactable = true;
			enemy2Name.text = enemy2Character.characterName;
			enemy2HP.text = enemy2Character.GetHP() + "/" + enemy2Character.maxHp;
			enemy2Status.text = GetStatus(enemy2Character);
			enemy2HPBar.fillAmount = (float)enemy2Character.GetHP () / (float)enemy2Character.maxHp;
			enemy2NameBox.enabled = true;
			enemy2NameBox.interactable = false;
		}
		
		if (enemy3Character != null) {
			enemy3Canvas.alpha = 1; //set enemy 3 to visible
			enemy3Canvas.interactable = true;
			enemy3Name.text = enemy3Character.characterName;
			enemy3HP.text = enemy3Character.GetHP() + "/" + enemy3Character.maxHp;
			enemy3Status.text = GetStatus(enemy3Character);
			enemy3HPBar.fillAmount = (float)enemy3Character.GetHP () / (float)enemy3Character.maxHp;
			enemy3NameBox.enabled = true;
			enemy3NameBox.interactable = false;
		}
		
		if (enemy4Character != null) {
			enemy4Canvas.alpha = 1; //set enemy 4 to visible
			enemy4Canvas.interactable = true;
			enemy4Name.text = enemy4Character.characterName;
			enemy4HP.text = enemy4Character.GetHP() + "/" + enemy4Character.maxHp;
			enemy4Status.text = GetStatus(enemy4Character);
			enemy4HPBar.fillAmount = (float)enemy4Character.GetHP () / (float)enemy4Character.maxHp;
			enemy4NameBox.enabled = true;
			enemy4NameBox.interactable = false;
		}
		
		if (enemy5Character != null) {
			enemy5Canvas.alpha = 1; //set enemy 5 to visible
			enemy5Canvas.interactable = true;
			enemy5Name.text = enemy5Character.characterName;
			enemy5HP.text = enemy5Character.GetHP() + "/" + enemy5Character.maxHp;
			enemy5Status.text = GetStatus(enemy5Character);
			enemy5HPBar.fillAmount = (float)enemy5Character.GetHP () / (float)enemy5Character.maxHp;
			enemy5NameBox.enabled = true;
			enemy5NameBox.interactable = false;
		}

		healthPotionQuantity.text = "x" + dc.healthPotionNum;
		specialPotionQuantity.text = "x" + dc.specialPotionNum;
		lifePotionQuantity.text = "x" + dc.lifePotionNum;
		molotovCocktailQuantity.text = "x" + dc.molotovCocktailNum;
		mrFunQuantity.text = "x" + dc.mrFunNum;
	}
	
	public void SetEnemyTurnText(string text) {
		enemyTurnText.text = text;
		UpdateGui();
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

		healthPotionButton.interactable = false;
		healthPotionButton.image.fillCenter = true;
		specialPotionButton.interactable = false;
		specialPotionButton.image.fillCenter = true;
		lifePotionButton.interactable = false;
		lifePotionButton.image.fillCenter = true;
		molotovCocktailButton.interactable = false;
		molotovCocktailButton.image.fillCenter = true;
		mrFunButton.interactable = false;
		mrFunButton.image.fillCenter = true;
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
			player1NameBox.interactable = false;
		} else if (playerNum == 2) {
			player2HP.gameObject.SetActive(false);
			player2Name.gameObject.SetActive(false);
			player2SP.gameObject.SetActive(false);
			player2Ability1.gameObject.SetActive(false);
			player2Ability2.gameObject.SetActive(false);
			player2Ability3.gameObject.SetActive(false);
			player2Status.gameObject.SetActive(false);
			player2NameBox.interactable = false;
		} else if (playerNum == 3) {
			player3HP.gameObject.SetActive(false);
			player3Name.gameObject.SetActive(false);
			player3SP.gameObject.SetActive(false);
			player3Ability1.gameObject.SetActive(false);
			player3Ability2.gameObject.SetActive(false);
			player3Ability3.gameObject.SetActive(false);
			player3Status.gameObject.SetActive(false);
			player3NameBox.interactable = false;
		} else if (playerNum == 4) {
			player4HP.gameObject.SetActive(false);
			player4Name.gameObject.SetActive(false);
			player4SP.gameObject.SetActive(false);
			player4Ability1.gameObject.SetActive(false);
			player4Ability2.gameObject.SetActive(false);
			player4Ability3.gameObject.SetActive(false);
			player4Status.gameObject.SetActive(false);
			player4NameBox.interactable = false;
		} else if (playerNum == 5) {
			player5HP.gameObject.SetActive(false);
			player5Name.gameObject.SetActive(false);
			player5SP.gameObject.SetActive(false);
			player5Ability1.gameObject.SetActive(false);
			player5Ability2.gameObject.SetActive(false);
			player5Ability3.gameObject.SetActive(false);
			player5Status.gameObject.SetActive(false);
			player5NameBox.interactable = false;
		}
	}
	
	public void DisableEnemyGUI(int enemyNum) {
		if (enemyNum == 1) {
			enemy1HP.gameObject.SetActive(false);
			enemy1Name.gameObject.SetActive(false);
			enemy1Status.gameObject.SetActive(false);
			enemy1NameBox.interactable = false;
		} else if (enemyNum == 2) {
			enemy2HP.gameObject.SetActive(false);
			enemy2Name.gameObject.SetActive(false);
			enemy2Status.gameObject.SetActive(false);
			enemy2NameBox.interactable = false;
		} else if (enemyNum == 3) {
			enemy3HP.gameObject.SetActive(false);
			enemy3Name.gameObject.SetActive(false);
			enemy3Status.gameObject.SetActive(false);
			enemy3NameBox.interactable = false;
		} else if (enemyNum == 4) {
			enemy4HP.gameObject.SetActive(false);
			enemy4Name.gameObject.SetActive(false);
			enemy4Status.gameObject.SetActive(false);
			enemy4NameBox.interactable = false;
		} else if (enemyNum == 5) {
			enemy5HP.gameObject.SetActive(false);
			enemy5Name.gameObject.SetActive(false);
			enemy5Status.gameObject.SetActive(false);
			enemy5NameBox.interactable = false;
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
		default:
			switch(controller.GetCurrentTurn()) {
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
			default:
				Debug.Log ("error binding to targeter");
				break;
			}
			break;
		}
		
		Debug.Log (button.name);
		Debug.Log(player);
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
		case "Item 1 Button":
			player.itemAbility1.GetComponent<Targeter>().EnableTargets(button);
			break;
		case "Item 2 Button":
			player.itemAbility2.GetComponent<Targeter>().EnableTargets(button);
			break;
		case "Item 3 Button":
			player.itemAbility3.GetComponent<Targeter>().EnableTargets(button);
			break;
		case "Item 4 Button":
			player.itemAbility4.GetComponent<Targeter>().EnableTargets(button);
			break;
		case "Item 5 Button":
			player.itemAbility5.GetComponent<Targeter>().EnableTargets(button);
			break;

		}

	}
	
	public void InitializeGUI() {
		controller = gameObject.GetComponent<BattleController>();
		dc = GameObject.FindGameObjectWithTag ("DataContainer").GetComponent<DataContainer>();
		
		player1Character = controller.GetPlayer(1);
		/*
		if(player1Character != null) {
			player1Ability1.GetComponentInChildren<Text>().text = player1Character.ability1.abilityName;
			player1Ability2.GetComponentInChildren<Text>().text = player1Character.ability2.abilityName;
			player1Ability3.GetComponentInChildren<Text>().text = player1Character.ability3.abilityName;
		}
		*/
		
		player2Character = controller.GetPlayer(2);
		/*
		if(player2Character != null) {
			player2Ability1.GetComponentInChildren<Text>().text = player2Character.ability1.abilityName;
			player2Ability2.GetComponentInChildren<Text>().text = player2Character.ability2.abilityName;
			player2Ability3.GetComponentInChildren<Text>().text = player2Character.ability3.abilityName;
		}
		*/
		
		player3Character = controller.GetPlayer(3);
		/*
		if(player3Character != null) {
			player3Ability1.GetComponentInChildren<Text>().text = player3Character.ability1.abilityName;
			player3Ability2.GetComponentInChildren<Text>().text = player3Character.ability2.abilityName;
			player3Ability3.GetComponentInChildren<Text>().text = player3Character.ability3.abilityName;
		}
		*/
		
		player4Character = controller.GetPlayer(4);
		/*
		if(player4Character != null) {
			player4Ability1.GetComponentInChildren<Text>().text = player4Character.ability1.abilityName;
			player4Ability2.GetComponentInChildren<Text>().text = player4Character.ability2.abilityName;
			player4Ability3.GetComponentInChildren<Text>().text = player4Character.ability3.abilityName;
		}
		*/
		
		player5Character = controller.GetPlayer(5);
		/*
		if(player5Character != null) {
			player5Ability1.GetComponentInChildren<Text>().text = player5Character.ability1.abilityName;
			player5Ability2.GetComponentInChildren<Text>().text = player5Character.ability2.abilityName;
			player5Ability3.GetComponentInChildren<Text>().text = player5Character.ability3.abilityName;
		}
		*/
		
		enemy1Character = controller.GetEnemy(1);
		enemy2Character = controller.GetEnemy(2);
		enemy3Character = controller.GetEnemy(3);
		enemy4Character = controller.GetEnemy(4);
		enemy5Character = controller.GetEnemy(5);
		
		enemyTurnText.text = "";

		if (dc.controllerIconsOn) {
			CanvasGroup backspaceKey = GameObject.Find ("Backspace Key").GetComponent<CanvasGroup>();
			CanvasGroup bButton = GameObject.Find ("B Button").GetComponent<CanvasGroup>();
			backspaceKey.alpha = 0;
			bButton.alpha = 1;
		}
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