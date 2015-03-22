using UnityEngine;
using System.Collections;

public class Targeter : MonoBehaviour {

	private GameObject[] enemies;
	private GameObject[] players;
	private bool waitingForTarget;
	private GameObject[] targetGroup;
	private Ability ability;

	public void EnableTargets() {

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
				targetChar.SetTargetable(true);
			}
			
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
					ability.Use(targetChar);
				}
			}
		}
	}
	
	//called on object creation, set up references
	private void Awake() {
		ability = transform.GetComponent<Ability>();
		waitingForTarget = false;
	}
}