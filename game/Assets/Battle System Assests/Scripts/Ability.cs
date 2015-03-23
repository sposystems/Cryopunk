using UnityEngine;
using System.Collections;

public class Ability : MonoBehaviour {
	
	public string abilityName;
	public int spCost;
	public int damage;
	public bool isOffensive;
	public int animationNumber;

	private Character abilityUser;
	private BattleController controller;

	public void Use(Character target) {
		StartCoroutine(PlayAnimation());
		StartCoroutine(UseOnOne(target));
	}
	
	//called on object creation, sets up refrences
	private void Awake() {
		abilityUser = transform.parent.gameObject.GetComponent<Character>();
		controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<BattleController>();
	}
	
	private IEnumerator PlayAnimation() {
		string animationName = "";
		if (animationNumber == 1) {
			animationName = "Attack1";
		} else if (animationNumber == 2) {
			animationName = "Special1";
		} else if (animationNumber == 3) {
			animationName = "Special2";
		} else {
			Debug.Log("Invalid animation number");
		}
		
		abilityUser.animation.PlayQueued(animationName, QueueMode.PlayNow);
		yield return new WaitForSeconds(abilityUser.animation[animationName].length - 0.5f);
		abilityUser.animation.PlayQueued("Idle", QueueMode.CompleteOthers);
		
	}
	
	private IEnumerator UseOnOne(Character target) {
		abilityUser.UseSP(spCost);
		target.TakeDamage(damage);
		yield return new WaitForSeconds(1);
		controller.EndTurn();
	}
	
	private IEnumerator UseOnAll() {
		abilityUser.UseSP(spCost);
		
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		GameObject[] targets = null;
		
		if ((abilityUser.isPlayer && isOffensive) || (!abilityUser.isPlayer && !isOffensive)) {
			targets = enemies;
		} else if ((abilityUser.isPlayer && !isOffensive) || (!abilityUser.isPlayer && isOffensive)) {
			targets = players;
		} else {
			Debug.Log("Could not determine target group");
		}
		
		foreach (GameObject target in targets) {
			target.GetComponent<Character>().TakeDamage(damage);
		}
		yield return new WaitForSeconds(1);
		controller.EndTurn();
	}
	
}