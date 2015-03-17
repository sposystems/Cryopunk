using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public string characterName;
	public int hp;
	public int sp;
	public Ability ability1;
	public Ability ability2;
	public Ability ability3;
	public bool isPlayer;

	private int currentSP;
	private int currentHP;
	private bool targetable;
	private bool targeted;
	private bool stunned;
	private int stunDuration;
	private bool buffed;
	private int buffDuration;
	private int buffAmount;
	private bool hpDraining;
	private int drainDuration;
	private int drainAmount;
	private bool silenced;
	private int silenceDuration;

	public void TakeDamage(int amount) {
		currentHP -= amount;
		if (currentHP <= 0) {
			currentHP=0;
			animation.PlayQueued("Death", QueueMode.PlayNow);
		} else {
			animation.PlayQueued("Hurt", QueueMode.PlayNow);
			animation.PlayQueued("Idle", QueueMode.CompleteOthers);
		}
	}

	public void Heal(int amount) {
		currentHP += amount;
		if (currentHP > hp) {
			currentHP = hp;
		}
	}

	public void UseSP(int amount) {
		currentSP -= amount;
		if(currentSP < 0) {
			currentSP=0;
		}
	}

	public void RecoverSP(int amount) {
		currentSP += amount;
		if (currentSP > sp) {
			currentSP = sp;
		}
	}

	public int GetHP() {
		return currentHP;
	}

	public int GetSP() {
		return currentSP;
	}

	public bool IsTargetable() {
		return targetable;
	}

	public bool IsTargeted() {
		return targeted;
	}

	public void SetTargetable(bool b) {
		targetable = b;
	}

	public void SetTargeted(bool b) {
		targeted = b;
	}

	public void Stun(int duration) {
		stunned = true;
		stunDuration = duration;
	}

	public void HpDrain(int duration, int amount) {
		hpDraining = true;
		drainDuration = duration;
		drainAmount = amount;
	}

	public void Buff(int duration, int amount) {
		buffed = true;
		buffDuration = duration;
		buffAmount = amount;
	}

	public void Silence(int duration) {
		silenced = true;
		silenceDuration = duration;
	}
	
	//called when character is clicked
	private void OnMouseDown() {
		if (currentHP > 0 && targetable) {
			targeted = true;
		}
	}

	//called on object creation
	private void Awake() {
		currentHP = hp;
		currentSP = sp;
		targetable = false;
		targeted = false;
		stunned = false;
		buffed = false;
		hpDraining = false;
	}
}