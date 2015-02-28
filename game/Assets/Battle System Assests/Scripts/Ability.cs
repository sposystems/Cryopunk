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
	private Character target;

	public void Use(Character targ) {
		
		target = targ;
		
		if (animationNumber == 1) {
			StartCoroutine(PlayAnim("Attack1"));
		} else if (animationNumber == 2) {
			StartCoroutine(PlayAnim("Special1"));
		} else if (animationNumber == 3) {
			StartCoroutine(PlayAnim("Special2"));
		} else {
			Debug.Log("invalid animation number");
		}
	}

	//called on object creation, sets up refrences
	private void Awake() {
		abilityUser = transform.parent.gameObject.GetComponent<Character>();
		controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<BattleController>();
	}
	
	private IEnumerator PlayAnim(string animationName) {
		abilityUser.animation.PlayQueued(animationName, QueueMode.PlayNow);
		yield return new WaitForSeconds(abilityUser.animation[animationName].length - 0.5f);
		abilityUser.animation.PlayQueued("Idle", QueueMode.CompleteOthers);
		
		abilityUser.UseSP(spCost);
		target.TakeDamage(damage);
		yield return new WaitForSeconds(1);
		controller.EndTurn();
	}
}