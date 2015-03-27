using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public string characterName;
	public int maxHp;
	public int maxSp;
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
	private bool cursed;
	private int curseDuration;
	private int curseAmount;
	private bool stealthed;
	private int stealthDuration;

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
		if (currentHP > maxHp) {
			currentHP = maxHp;
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
		if (currentSP > maxSp) {
			currentSP = maxSp;
		}
	}

	public bool Alive() {
		if (currentHP > 0) {
			return true;
		} else {
			return false;
		}
	}

	public bool HasSP(int amount) {
		if (currentSP >= amount) {
			return true;
		} else {
			return false;
		}
	}

	public int GetHP() {
		return currentHP;
	}

	public int GetSP() {
		return currentSP;
	}

	public int GetBuffAmount() {
		return buffAmount;
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

	public bool IsStunned() {
		return stunned;
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

	public bool IsSilenced() {
		return silenced;
	}
	
	public void Curse(int duration, int amount) {
		cursed = true;
		curseDuration = duration;
		curseAmount = amount;
	}
	
	public int GetCurseAmount() {
		return curseAmount;
	}
	
	public void Stealth(int duration) {
		stealthed = true;
		stealthDuration = duration;
	}
	
	public bool IsStealth() {
		return stealthed;
	}

	//update all status durations and states. apply draining damage
	public void UpdateStatusEffects() {
		if (buffed) {
			if (buffDuration <= 0) {
				buffed = false;
				buffAmount = 0;
			} else {
				buffDuration--;
			}
		}

		if (stunned) {
			if (stunDuration <= 0) {
				stunned = false;
			} else {
				stunDuration--;
			}
		}

		if (silenced) {
			if (silenceDuration <= 0) {
				silenced = false;
			} else {
				silenceDuration--;
			}
		}

		if (hpDraining) {
			if (drainDuration <= 0) {
				hpDraining = false;
				drainAmount = 0;
			} else {
				drainDuration--;
				TakeDamage(drainAmount);
			}
		}
		
		if (cursed) {
			if (curseDuration <= 0) {
				cursed = false;
				curseAmount = 0;
			} else {
				curseDuration--;
			}
		}
		
		if (stealthed) {
			if (stealthDuration <= 0) {
				stealthed = false;
				animation.PlayQueued("Unstealth", QueueMode.PlayNow);
				animation.PlayQueued("Idle", QueueMode.CompleteOthers);
			} else {
				stealthDuration--;
			}
		}
	}
	
	//called when character is clicked
	private void OnMouseDown() {
		if (currentHP > 0 && targetable) {
			targeted = true;
		}
	}

	//called on object creation
	private void Awake() {
		currentHP = maxHp;
		currentSP = maxSp;
		targetable = false;
		targeted = false;
		stunned = false;
		buffed = false;
		hpDraining = false;
		cursed = false;
	}
}