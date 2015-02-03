using UnityEngine;
using System.Collections;

public class BattleController : MonoBehaviour {

	public BattleGUI gui;
	public Character player1Character;
	public Character player2Character;
	public Character player3Character;
	public Character player4Character;
	public Character player5Character;
	public Character enemy1Character;
	public Character enemy2Character;
	public Character enemy3Character;
	public Character enemy4Character;
	public Character enemy5Character;
	
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

	//complete the turn and set up for next turn
	public void EndTurn() {
		gui.UpdateGui();
		gui.DisableButtons();

		//clear all targets
		player1Character.SetTargeted(false);
		player1Character.SetTargetable(false);
		player2Character.SetTargeted(false);
		player2Character.SetTargetable(false);
		player3Character.SetTargeted(false);
		player3Character.SetTargetable(false);
		player4Character.SetTargeted(false);
		player4Character.SetTargetable(false);
		player5Character.SetTargeted(false);
		player5Character.SetTargetable(false);
		enemy1Character.SetTargeted(false);
		enemy1Character.SetTargetable(false);
		enemy2Character.SetTargeted(false);
		enemy2Character.SetTargetable(false);
		enemy3Character.SetTargeted(false);
		enemy3Character.SetTargetable(false);
		enemy4Character.SetTargeted(false);
		enemy4Character.SetTargetable(false);
		enemy5Character.SetTargeted(false);
		enemy5Character.SetTargetable(false);
		

		//check for loss
		if (player1Character.GetHP() <= 0 && 
		player2Character.GetHP() <= 0 && 
		player3Character.GetHP() <= 0 && 
		player4Character.GetHP() <= 0 && 
		player5Character.GetHP() <= 0) {
			currentState = BattleStates.LoseBattle;
		
		//check for win
		} else if (enemy1Character.GetHP() <= 0 &&
		enemy1Character.GetHP() <= 0 &&
		enemy2Character.GetHP() <= 0 &&
		enemy3Character.GetHP() <= 0 &&
		enemy4Character.GetHP() <= 0 &&
		enemy5Character.GetHP() <= 0) {
			currentState = BattleStates.WinBattle;
			
		//if all enemies have gone, go back to player 1
		} else if (currentState == BattleStates.Enemy5Turn) {
			currentState = BattleStates.Player1Turn;
			
		//go to the next player's turn
		} else {
			currentState++;
		}

		ChangeState();
	}

	//setup battle
	private void Start() {
		gui.UpdateGui();
		currentState = BattleStates.Player1Turn;
		ChangeState();
	}
	
	private void ChangeState() {
		switch(currentState) {
		
		case(BattleStates.Player1Turn):
			if (player1Character.GetHP() > 0) {
				gui.player1Ability1.interactable = true;
				gui.player1Ability2.interactable = true;
			} else {
				currentState++;
				ChangeState();
			}
			break;
			
		case(BattleStates.Player2Turn):
			if (player2Character.GetHP() > 0) {
				gui.player2Ability1.interactable = true;
				gui.player2Ability2.interactable = true;
			} else {
				currentState++;
				ChangeState();
			}
			break;
			
		case(BattleStates.Player3Turn):
			if (player3Character.GetHP() > 0) {
				gui.player3Ability1.interactable = true;
				gui.player3Ability2.interactable = true;
			} else {
				currentState++;
				ChangeState();
			}
			break;
			
		case(BattleStates.Player4Turn):
			if (player4Character.GetHP() > 0) {
				gui.player4Ability1.interactable = true;
				gui.player4Ability2.interactable = true;
			} else {
				currentState++;
				ChangeState();
			}
			break;
			
		case(BattleStates.Player5Turn):
			if (player5Character.GetHP() > 0) {
				gui.player5Ability1.interactable = true;
				gui.player5Ability2.interactable = true;
			} else {
				currentState++;
				ChangeState();
			}
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
			break;
			
		case(BattleStates.LoseBattle):
			//display game over
			Debug.Log("lose state entered");
			break;
		}
	}
	
	//enemy chooses random attack
	private void EnemyTurn(Character enemy) {		
		Character target = player1Character;
		bool validTarget = false;
		bool validAbility = false;
		
		while(validTarget == false) {
			randTarget = Random.Range(0,5);
			validTarget = true;
			if (randTarget == 0 && player1Character.GetHP() > 0) {
				target = player1Character;
			} else if (randTarget == 1 && player2Character.GetHP() > 0) {
				target = player2Character;
			} else if (randTarget == 2 && player3Character.GetHP() > 0) {
				target = player3Character;
			} else if (randTarget == 3 && player4Character.GetHP() > 0) {
				target = player4Character;
			} else if (randTarget == 4 && player5Character.GetHP() > 0) {
				target = player5Character;
			} else {
				validTarget = false;
			}
		}
		
		while(validAbility == false) {
			randAbility = Random.Range(0,2);
			validAbility = true;
			if (randAbility == 0 && enemy.ability1.spCost <= enemy.GetSP()) {
				enemy.ability1.Use(target);
			} else if (randAbility == 1 && enemy.ability2.spCost <= enemy.GetSP()) {
				enemy.ability2.Use(target);
			} else {
				validAbility = false;
			}
		}
	}
}