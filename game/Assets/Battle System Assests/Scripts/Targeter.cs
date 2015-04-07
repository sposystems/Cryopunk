using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Targeter : MonoBehaviour {

	private GameObject[] enemies;
	private GameObject[] players;
	private bool waitingForTarget;
	private GameObject[] targetGroup;
	private Ability ability;
	private BattleController controller;
	private Button abilityButton;

	public void EnableTargets(Button button) {
	
		abilityButton = button;
		
		Debug.Log (button);
		Debug.Log (ability);
		
		//enable possible ability targets and wait for user to choose target
		if (ability.targetType == Ability.targetTypeE.single) {
			enemies = GameObject.FindGameObjectsWithTag("Enemy");
			players = GameObject.FindGameObjectsWithTag("Player");

			//set target group
			if (ability.offensive) {
				targetGroup = enemies;
			} else {
				targetGroup = players;
			}
			
			//set each character in target group as targetable
			foreach (GameObject targetObj in targetGroup) {
				Character targetChar = targetObj.GetComponent<Character>();
				if (targetChar.IsStealth() == false) {
					targetChar.SetTargetable(true);
				}
			}
			
			controller.gui.DisableButtons();
			abilityButton.image.fillCenter = false;
			
			waitingForTarget = true;
		
		//ability does not require a target
		} else {
			ability.Use(null);
		}
	}
	
	//called on every frame
	private void Update() {
		if (waitingForTarget) {
			foreach (GameObject targetObj in targetGroup) {
				Character targetChar = targetObj.GetComponent<Character>();
				if (targetChar.IsTargeted()) {
					waitingForTarget = false;
					abilityButton.image.fillCenter = true;
					ability.Use(targetChar);
				}
			}
		}
	}
	
	//set up references
	public void Init() {
		controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<BattleController>();
		Debug.Log(transform.GetComponent<Ability>());
		ability = transform.GetComponent<Ability>();
		waitingForTarget = false;
	}
}