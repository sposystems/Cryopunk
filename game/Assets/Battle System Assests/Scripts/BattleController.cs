using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleController : MonoBehaviour {

	public BattleGUI gui;

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
	private bool isFinalBattle = false;
	private enum BattleStates {
		Player1Turn,
		Player2Turn,
		Player3Turn,
		Player4Turn,
		Player5Turn,
		Enemy1Turn,
		Enemy2Turn,
		Enemy3Turn,
		Enemy4Turn,
		Enemy5Turn,
		WinBattle,
		LoseBattle
	};
	private BattleStates currentState;
	private int randAbility;
	private int randTarget;
	public GameObject camera;
	public GameObject playerContainer;
	private Text hoverAbilityText;
	//private SceneChanger sceneChangerElement = new SceneChanger(); //do I want this object to persist throughout?

	//return reference to a player
	public Character GetPlayer(int playerNum) {
		if(playerNum == 1) {
			return player1Character;
		} else if (playerNum == 2) {
			return player2Character;
		} else if (playerNum == 3) {
			return player3Character;
		} else if (playerNum == 4) {
			return player4Character;
		} else if (playerNum == 5) {
			return player5Character;
		} else {
			Debug.Log ("no such player");
			return null;
		}
	}
	
	//return reference to an enemy
	public Character GetEnemy(int enemyNum) {
		if(enemyNum == 1) {
			return enemy1Character;
		} else if (enemyNum == 2) {
			return enemy2Character;
		} else if (enemyNum == 3) {
			return enemy3Character;
		} else if (enemyNum == 4) {
			return enemy4Character;
		} else if (enemyNum == 5) {
			return enemy5Character;
		} else {
			Debug.Log ("no such enemy");
			return null;
		}
	}
	
	//complete the turn and set up for next turn
	public void EndTurn() {
		gui.SetEnemyTurnText("");
		gui.DisableButtons();

		//clear all targets
		ClearTargets(player1Character);
		ClearTargets(player2Character);
		ClearTargets(player3Character);
		ClearTargets(player4Character);
		ClearTargets(player5Character);
		ClearTargets(enemy1Character);
		ClearTargets(enemy2Character);
		ClearTargets(enemy3Character);
		ClearTargets(enemy4Character);
		ClearTargets(enemy5Character);
		
		//check for win
		if (GameOverCheck(true)) {
			currentState = BattleStates.WinBattle;
		
		//check for loss
		} else if (GameOverCheck(false)) {
			currentState = BattleStates.LoseBattle;
			
		//if all enemies have gone, go back to player 1
		} else if (currentState == BattleStates.Enemy5Turn) {
			currentState = BattleStates.Player1Turn;
			
		//go to the next player's turn
		} else {
			currentState++;
		}

		ChangeState();
	}
	
	private void ClearTargets(Character character) {
		if (character != null) {
			character.SetTargeted(false);
			character.SetTargetable(false);
		}
	}
	
	private bool GameOverCheck(bool lookingForWin) {
		
		GameObject[] players;
		bool loss = true;
		
		if (lookingForWin) {
			players = GameObject.FindGameObjectsWithTag("Enemy");
		} else {
			players = GameObject.FindGameObjectsWithTag("Player");
		}
		
		foreach (GameObject player in players) {
			if (player.GetComponent<Character>().Alive()) {
				loss = false;
				break;
			}
		}
		
		return loss;
	}
	
	private void ImportPlayers(bool fifthAcquired) {
		//hardcoded for testing
		//fifthAcquired = true;
		
		player1 = (GameObject)Instantiate(Resources.Load("Warrior"));
		player1Character = player1.GetComponent<Character>();
		player1.transform.position = new Vector3(14,0,-8.5f);
		
		player2 = (GameObject)Instantiate(Resources.Load("Wizard"));
		player2Character = player2.GetComponent<Character>();
		player2.transform.position = new Vector3(14,0,-4);
		
		player3 = (GameObject)Instantiate(Resources.Load("Thief"));
		player3Character = player3.GetComponent<Character>();
		player3.transform.position = new Vector3(14,0,0);
		
		player4 = (GameObject)Instantiate(Resources.Load("Priest"));
		player4Character = player4.GetComponent<Character>();
		player4.transform.position = new Vector3(14,0,4);
		
		if (fifthAcquired) {
			player5 = (GameObject)Instantiate(Resources.Load("Archer"));
			player5Character = player5.GetComponent<Character>();
			player5.transform.position = new Vector3(14,0,8.5f);
		} else {
			gui.DisablePlayerGUI(5);
		}
	}
	
	private void ImportEnemies(int type, int amount) {
		//hardcoded values for testing
		//type=2;
		//amount=5;
		
		string enemyType = "";
		if (type == 1) {
			enemyType = "Zombie";
		} else if (type == 2) {
			enemyType = "Spider";
		} else if (type == 3) {
			enemyType = "Boss";
			isFinalBattle = true;
		}
		else {
			Debug.Log("ERROR: Invalid enemy type");
		}
		
		enemy1 = (GameObject)Instantiate(Resources.Load(enemyType));
		enemy1Character = enemy1.GetComponent<Character>();
		enemy1.transform.position = new Vector3(2,0,-13.5f);
		enemy1.transform.Rotate(0,-20,0);
		
		if (amount > 1) {
			enemy2 = (GameObject)Instantiate(Resources.Load(enemyType));
			enemy2Character = enemy2.GetComponent<Character>();
			enemy2.transform.position = new Vector3(2,0,-7);
			enemy2.transform.Rotate(0,-10,0);
		} else {
			gui.DisableEnemyGUI(2);
		}
		
		if (amount > 2) {
			enemy3 = (GameObject)Instantiate(Resources.Load(enemyType));
			enemy3Character = enemy3.GetComponent<Character>();
			enemy3.transform.position = new Vector3(2,0,-.5f);
		} else {
			gui.DisableEnemyGUI(3);
		}
		
		if (amount > 3) {
			enemy4 = (GameObject)Instantiate(Resources.Load(enemyType));
			enemy4Character = enemy4.GetComponent<Character>();
			enemy4.transform.position = new Vector3(2,0,6);
			enemy4.transform.Rotate(0,10,0);
		} else {
			gui.DisableEnemyGUI(4);
		}
		
		if (amount > 4) {
			enemy5 = (GameObject)Instantiate(Resources.Load(enemyType));
			enemy5Character = enemy5.GetComponent<Character>();
			enemy5.transform.position = new Vector3(2,0,12.5f);
			enemy5.transform.Rotate(0,20,0);
		} else {
			gui.DisableEnemyGUI(5);
		}
		
		if(amount > 5 || amount < 1) {
			Debug.Log("ERROR: Invalid amount");
		}
	}
	
	private void ApplyLocation(int location){
	
	}

	//setup battle
	private void Start() {
		camera = GameObject.Find("Main Camera");
		playerContainer = GameObject.Find("PlayerContainer");
		hoverAbilityText = GameObject.Find ("Description Text").GetComponent<Text>(); //for the mouse hovering over abilities
		camera.SetActive(false);
		playerContainer.SetActive(false);
		
		ApplyLocation(BattleLauncher.location);
		ImportPlayers(BattleLauncher.fifthMember);
		ImportEnemies(BattleLauncher.enemyType, BattleLauncher.enemyQuantity);	
		gui.InitializeGUI();
		gui.UpdateGui();
		currentState = BattleStates.Player1Turn;
		ChangeState();
	}
	
	private void ChangeState() {
		switch(currentState) {

		case(BattleStates.Player1Turn):
			PlayerTurn(player1Character, gui.player1Ability1, gui.player1Ability2, gui.player1Ability3);
			break;
			
		case(BattleStates.Player2Turn):
			PlayerTurn(player2Character, gui.player2Ability1, gui.player2Ability2, gui.player2Ability3);
			break;
			
		case(BattleStates.Player3Turn):
			PlayerTurn(player3Character, gui.player3Ability1, gui.player3Ability2, gui.player3Ability3);
			break;
			
		case(BattleStates.Player4Turn):
			PlayerTurn(player4Character, gui.player4Ability1, gui.player4Ability2, gui.player4Ability3);
			break;
			
		case(BattleStates.Player5Turn):
			PlayerTurn(player5Character, gui.player5Ability1, gui.player5Ability2, gui.player5Ability3);
			break;

		case(BattleStates.Enemy1Turn):
			EnemyTurn(enemy1Character);
			break;
			
		case(BattleStates.Enemy2Turn):
			EnemyTurn(enemy2Character);
			break;
			
		case(BattleStates.Enemy3Turn):
			EnemyTurn(enemy3Character);
			break;
			
		case(BattleStates.Enemy4Turn):
			EnemyTurn(enemy4Character);
			break;
			
		case(BattleStates.Enemy5Turn):
			EnemyTurn(enemy5Character);
			break;
			
		case(BattleStates.WinBattle):
			//display win
			Debug.Log("win state entered");
			//GameObject battlecamera = GameObject.Find("Battle Camera");
			//GameObject playerContainer = GameObject.Find("PlayerContainer");
			//battlecamera.SetActive(false);
			if(isFinalBattle){
				Application.LoadLevel (8); 
			} else{
				camera.SetActive(true); //need our player and camera back
				playerContainer.SetActive(true);
				SceneChanger.winChangeScene();//you have won the battle, transition back to previous scene
			}
			break;
			
		case(BattleStates.LoseBattle):
			//display game over
			Debug.Log("lose state entered");
			break;
		}
	}

	private void PlayerTurn(Character player, Button ability1, Button ability2, Button ability3) {

		if (player != null && player.Alive()) {
			player.UpdateStatusEffects();

			//check if alive again incase status effect killed player
			if (player.Alive() && player.IsStunned() == false && player.IsStealth() == false) {
				if (player.HasSP(player.ability1.spCost)) {
					ability1.interactable = true;
				}
				if (player.HasSP(player.ability2.spCost) && player.IsSilenced() == false) {
					ability2.interactable = true;
				}
				if (player.HasSP(player.ability3.spCost) && player.IsSilenced() == false) {
					ability3.interactable = true;
				}
			} else {
				currentState++;
				ChangeState();
			}
		} else {
		currentState++;
		ChangeState();
		}
	}
	
	//enemy chooses random attack
	private void EnemyTurn(Character enemy) {		
		if (enemy != null && enemy.Alive()) {
			enemy.UpdateStatusEffects();

			//check if alive again incase status effect killed enemy
			if (enemy.Alive() && enemy.IsStunned() == false) {

				Character target = null;
				bool validTarget = false;
				bool validAbility = false;
				
				GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");
				
				//choose target at random
				while(validTarget == false) {
					randTarget = Random.Range(0,targets.Length);
					
					if (targets[randTarget].GetComponent<Character>().Alive() && targets[randTarget].GetComponent<Character>().IsStealth() == false) {
						target = targets[randTarget].GetComponent<Character>();
						validTarget = true;
					}
				}
				
				Ability enemyAbility = null;
				
				//choose ability at random
				while(validAbility == false) {
					randAbility = Random.Range(0,3);
					validAbility = true;
					if (randAbility == 0 && enemy.HasSP(enemy.ability1.spCost)) {
						enemyAbility = enemy.ability1;
					} else if (randAbility == 1 && enemy.HasSP(enemy.ability2.spCost) && !enemy.IsSilenced()) {
						enemyAbility = enemy.ability2;
					} else if (randAbility == 2 && enemy.HasSP(enemy.ability3.spCost) && !enemy.IsSilenced()) {
						enemyAbility = enemy.ability3;
					} else {
						validAbility = false;
					}
				}

				string turnText = enemy.characterName + " uses " + enemyAbility.name;
				if (enemyAbility.targetType == Ability.targetTypeE.single) {
					turnText += " on " + target.characterName;
				}
				hoverAbilityText.text = ""; //Reset the text for Ability Descriptions
				gui.SetEnemyTurnText(turnText);
				
				enemyAbility.Use(target);
				
			} else {
				EndTurn();
				gui.SetEnemyTurnText(""); //Reset the text for Enemy Turn
			}
		} else {
			EndTurn();
			gui.SetEnemyTurnText(""); //Reset the text for Enemy Turn
		}
	}

	public void DisplayHoverAttack(){
		hoverAbilityText.text = "Attack - A low damage attack";
	}

	public void DisplayHoverWhirlwind(){
		hoverAbilityText.text = "Whirlwind - A sweeping attack damaging all enemies - 25 SP";
	}

	public void DisplayHoverBattlecry(){
		hoverAbilityText.text = "Battlecry - Increase party damage temporarily - 25 SP";
	}

	public void DisplayHoverFreeze(){
		hoverAbilityText.text = "Freeze - Stun an enemy for one turn - 25 SP";
	}

	public void DisplayHoverSilence(){
		hoverAbilityText.text = "Silence - Prevent an enemy from using special abilities - 25 SP";
	}

	public void DisplayHoverPoisonShot(){
		hoverAbilityText.text = "Poison Shot - Damage and poison an enemy to take damage over time - 25 SP";
	}

	public void DisplayHoverStealth(){
		hoverAbilityText.text = "Stealth - Render self invisible to enemies for a few turns - 25 SP";
	}

	public void DisplayHoverHeal(){
		hoverAbilityText.text = "Heal - Heal an ally's health - 25 SP";
	}

	public void DisplayHoverCurse(){
		hoverAbilityText.text = "Curse - Lower an enemy's defense - 25 SP";
	}

	public void DisplayHoverDoubleShot(){
		hoverAbilityText.text = "Double Shot - Deal high damage to one enemy - 25 SP";
	}

	public void DisplayHoverArrowRain(){
		hoverAbilityText.text = "Arrow Rain - Deal damage to 3 random enemies - 25 SP";
	}

}