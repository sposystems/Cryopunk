using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ability : MonoBehaviour {
	
	public string abilityName;
	public int spCost;
	public int damage;
	public bool offensive;
	public enum targetTypeE {single, all, singleRandom, multiRandom, self};
	public targetTypeE targetType;
	public enum statusEffectE {none, stun, hpDrain, silence, buff, curse, stealth};
	public statusEffectE statusEffect;
	public int statusLength = 0;
	public int statusAmount = 0;
	public int animationNumber;

	private Character abilityUser;
	private BattleController controller;

	//use ability on appropriate targets
	public void Use(Character target) {
		//Debug.Log (abilityUser.characterName + " uses " + abilityName + " on " + target.name);
		
		abilityUser.UseSP(spCost);
		StartCoroutine(PlayAnimation());

		switch(targetType) {
		case targetTypeE.single:
			StartCoroutine(UseOnOne(target));
			break;
		case targetTypeE.all:
			StartCoroutine(UseOnAll());
			break;
		case targetTypeE.singleRandom:
			StartCoroutine(UseOnRandom(1));
			break;
		case targetTypeE.multiRandom:
			if (GetTargetGroup().Length > 3) {
				StartCoroutine(UseOnRandom(3));
			} else if (GetTargetGroup().Length == 3) {
				StartCoroutine(UseOnRandom(2));
			} else {
				StartCoroutine(UseOnRandom(1));
			}
			break;
		case targetTypeE.self:
			StartCoroutine(UseOnOne(abilityUser));
			break;
		}
		
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

	//ability is used on 1 character
	private IEnumerator UseOnOne(Character target) {
		ApplyAbilityToTarget(target.gameObject);
		yield return new WaitForSeconds(1);
		controller.EndTurn();
	}

	//ability is used on all enemies or all players
	private IEnumerator UseOnAll() {
		//get target group
		GameObject[] targets = GetTargetGroup();

		//use on all in target group
		foreach (GameObject target in targets) {
			if (target.GetComponent<Character>().Alive()){
				ApplyAbilityToTarget(target);
			}
		}
		yield return new WaitForSeconds(1);
		controller.EndTurn();
	}

	//ability is used on random amount of players or enemies
	private IEnumerator UseOnRandom(int amount) {
		GameObject[] targetGroup = GetTargetGroup();

		//have to convert array to list so we can remove targets that have already been attacked
		List<GameObject> targetList = new List<GameObject>();
		targetList.AddRange(targetGroup);

		//use ability on certain amount of random targets
		int random;
		while (amount > 0) {
			random = Random.Range(0, targetList.Count);
			if (targetList[random].GetComponent<Character>().Alive()){
				ApplyAbilityToTarget(targetList[random]);
			}
			targetList.RemoveAt(random);
			amount--;
		}

		yield return new WaitForSeconds(1);
		controller.EndTurn();
	}

	//applys status effect and damage to target
	private void ApplyAbilityToTarget(GameObject targetObj){
		Character target = targetObj.GetComponent<Character>();

		if (target.Alive()) {
			if (statusEffect == statusEffectE.hpDrain) {
				target.HpDrain(statusLength, statusAmount);
			} else if (statusEffect == statusEffectE.stun) {
				target.Stun(statusLength);
			} else if (statusEffect == statusEffectE.buff) {
				target.Buff(statusLength, statusAmount);
			} else if (statusEffect == statusEffectE.silence) {
				target.Silence(statusLength);
			} else if (statusEffect == statusEffectE.curse) {
				target.Curse(statusLength, statusAmount);
			} else if (statusEffect == statusEffectE.stealth) {
				target.Stealth(statusLength);
			}
			
			if(offensive) {
				target.TakeDamage(damage + abilityUser.GetBuffAmount() - abilityUser.GetCurseAmount());
			} else if (statusEffect != statusEffectE.stealth){
				target.Heal(damage);
			}
		} else {
			Debug.Log("error, target is dead");
		}
	}

	//returns array of all possible targets the ability can be used on
	private GameObject[] GetTargetGroup() {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		GameObject[] targets = null;
		if ((abilityUser.isPlayer && offensive) || (!abilityUser.isPlayer && !offensive)) {
			targets = enemies;
		} else if ((abilityUser.isPlayer && !offensive) || (!abilityUser.isPlayer && offensive)) {
			targets = players;
		} else {
			Debug.Log("Could not determine target group");
		}
		return targets;
	}

	//called on object creation, sets up refrences
	private void Awake() {
		abilityUser = transform.parent.gameObject.GetComponent<Character>();
		controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<BattleController>();
	}
}