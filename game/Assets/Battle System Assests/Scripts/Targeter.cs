using UnityEngine;
using System.Collections;

public class Targeter : MonoBehaviour {

	public int abilityNumber;

	private GameObject[] enemies;
	private GameObject[] players;
	private bool waitingForTarget;
	private GameObject[] targetGroup;
	private Ability ability;

	public void EnableTargets() {
		
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		players = GameObject.FindGameObjectsWithTag("Player");
		
		//set target group
		if (ability.isOffensive) {
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
	}

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

	private void Awake() {
		ability = transform.GetComponent<Ability>();
		waitingForTarget = false;
	}
}