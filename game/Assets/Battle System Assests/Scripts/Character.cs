using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public string characterName;
	public int hp;
	public int sp;
	public Ability ability1;
	public Ability ability2;
	public bool isPlayer;

	private int currentSP;
	private int currentHP;
	private bool targetable;
	private bool targeted;

	public void TakeDamage(int amount) {
		//Debug.Log("damage taken");
		currentHP -= amount;
		if (currentHP <= 0) {
			currentHP=0;
		}
	}

	public void UseSP(int amount) {
		//Debug.Log("sp used");
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
	
	//called on every frame
	private void Update() {
		if (Input.GetMouseButtonDown(0)) {
			if (currentHP > 0 && targetable) {
				targeted = true;
			}
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