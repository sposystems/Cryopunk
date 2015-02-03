using UnityEngine;
using System.Collections;

public class Ability : MonoBehaviour {

	public string abilityName;
	public int spCost;
	public int damage;
	public bool isOffensive;

	private Character usedBy;
	private BattleController controller;

	public void Use(Character target) {
		usedBy.UseSP(spCost);
		target.TakeDamage(damage);
		controller.EndTurn();
	}

	//called on object creation, sets up refrences
	private void Awake() {
		usedBy = transform.parent.gameObject.GetComponent<Character>();
		controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<BattleController>();
	}
}