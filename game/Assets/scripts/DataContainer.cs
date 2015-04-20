using UnityEngine;
using System.Collections;

public class DataContainer : MonoBehaviour {

	public bool haveSolan;

	public int healthPotionNum;
	public int specialPotionNum;
	public int lifePotionNum;
	public int molotovCocktailNum;
	public int mrFunNum;

	public bool controllerIconsOn;

	public bool[] treasure = new bool[10];

	public Ability itemAbility1;
	public Ability itemAbility2;
	public Ability itemAbility3;
	public Ability itemAbility4;
	public Ability itemAbility5;

	public bool getSecret = false;

	public void IncreaseHealthPotions(int incAmount){
		healthPotionNum = healthPotionNum + incAmount;
	}

	public void IncreaseSpecialPotions(int incAmount){
		specialPotionNum = specialPotionNum + incAmount;
	}

	public void IncreaseLifePotions(int incAmount){
		lifePotionNum = lifePotionNum + incAmount;
	}

	public void IncreaseMolotovCocktails(int incAmount){
		molotovCocktailNum = molotovCocktailNum + incAmount;
	}

	public void IncreaseMrFuns(int incAmount){
		mrFunNum = mrFunNum + incAmount;
	}

	public void ChangeControllerIcons(){
		controllerIconsOn = !controllerIconsOn;
	}
	
}
