using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleGUI : MonoBehaviour {

	public Text playerName;
	public Text playerHP;
	public Text playerSP;
	public Button playerAbility1;
	public Button playerAbility2;
	public Text enemyName;
	public Text enemyHP;

	private GameObject player;
	private Character playerCharacter;
	private GameObject enemy;
	private Character enemyCharacter;
	
	public void UpdateGui() {
		//Debug.Log("gui updated");
		playerName.text = playerCharacter.characterName;
		playerHP.text = "HP: " + playerCharacter.GetHP() + "/" + playerCharacter.hp;
		playerSP.text = "SP: " + playerCharacter.GetSP() + "/" + playerCharacter.sp;
		
		enemyName.text = enemyCharacter.characterName;
		enemyHP.text = "HP: " + enemyCharacter.GetHP() + "/" + enemyCharacter.hp;
	}

	//called on object creation, sets up references
	private void Awake() {
		player = GameObject.FindGameObjectWithTag("Player");
		playerCharacter = player.GetComponent<Character>();

		enemy = GameObject.FindGameObjectWithTag("Enemy");
		enemyCharacter = enemy.GetComponent<Character>();
	}
}