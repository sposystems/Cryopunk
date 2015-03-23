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

	public void UseSP(int amount) {
		currentSP -= amount;
		if(currentSP<0) {
			currentSP=0;
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
	}
}