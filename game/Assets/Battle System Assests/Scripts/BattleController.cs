using UnityEngine;
using System.Collections;

public class BattleController : MonoBehaviour {

	public BattleGUI gui;
	public Character playerCharacter;
	public Character enemyCharacter;
	
	private enum BattleStates {
		PlayerTurn,
		EnemyTurn,
		WinBattle,
		LoseBattle
	};
	private BattleStates currentState;
	private int randNum;

	public void EndTurn() {
		gui.UpdateGui();

		//clear all targets
		playerCharacter.SetTargeted(false);
		playerCharacter.SetTargetable(false);
		enemyCharacter.SetTargeted(false);
		enemyCharacter.SetTargetable(false);

		//check for win/loss
		if (playerCharacter.GetHP() <= 0) {
			currentState = BattleStates.LoseBattle;
		} else if (enemyCharacter.GetHP() <= 0) {
			currentState = BattleStates.WinBattle;
		} else if (currentState == BattleStates.PlayerTurn) {
			currentState = BattleStates.EnemyTurn;
		} else if (currentState == BattleStates.EnemyTurn) {
			currentState = BattleStates.PlayerTurn;
		} else {
			Debug.Log("Somehow entered a bad state");
		}

		ChangeState();
	}

	//setup battle
	private void Start() {
		gui.UpdateGui();
		currentState = BattleStates.PlayerTurn;
		ChangeState();
	}
	
	private void ChangeState() {
		switch(currentState) {
		case(BattleStates.PlayerTurn):
			//Debug.Log("Player turn state entered");
			//enable player's abilities
			gui.playerAbility1.interactable = true;
			gui.playerAbility2.interactable = true;
			break;
		case(BattleStates.EnemyTurn):
			//Debug.Log("enemy turn state entered");
			//enemy chooses random attack
			randNum = Random.Range(0,2);
			if (randNum == 0) {
				enemyCharacter.ability1.Use(playerCharacter);
			} else if (randNum == 1) {
				enemyCharacter.ability2.Use(playerCharacter);
			} else {
				Debug.Log("ran gen error");
			}
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
}