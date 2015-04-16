using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Targeter : MonoBehaviour {

	private GameObject[] enemies;
	private GameObject[] players;
	private GameObject[] enemiesUI;
	private GameObject[] playersUI;
	private bool waitingForTarget;
	private GameObject[] targetGroup;
	private GameObject[] targetGroupUI;
	private Ability ability;
	private BattleController controller;
	private Button abilityButton;

	private Button alliesButton;
	private Button enemiesButton;
	private Button cancelButton;

	public void EnableTargets(Button button) {
	
		abilityButton = button;
		
		Debug.Log (button);
		Debug.Log (ability);
		
		//enable possible ability targets and wait for user to choose target
		if (ability.targetType == Ability.targetTypeE.single) {
			enemies = GameObject.FindGameObjectsWithTag("Enemy");
			players = GameObject.FindGameObjectsWithTag("Player");
			enemiesUI = GameObject.FindGameObjectsWithTag("EnemyUI");
			playersUI = GameObject.FindGameObjectsWithTag("PlayerUI");

			//Reset the enemies and allies button at the start of each step
			//enemiesButton.enabled = false;
			//alliesButton.enabled = false;

			//set target group
			if (ability.offensive) {
				targetGroup = enemies;
				targetGroupUI = enemiesUI;
				enemiesButton.interactable = true;
				alliesButton.interactable = false;
				EventSystem.current.SetSelectedGameObject(GameObject.Find ("Enemies Button"));
			} else {
				targetGroup = players;
				targetGroupUI = playersUI;
				enemiesButton.interactable = false;
				alliesButton.interactable = true;
				EventSystem.current.SetSelectedGameObject(GameObject.Find ("Allies Button"));
			}

			/*
			for(int i = 0; i < targetGroup.Length; i++){
				Character targetChar = targetGroup[i].GetComponent<Character>();
				Button targetCharName = targetGroupUI[i].GetComponentInChildren<Button>();
				Debug.Log ("TargetGroupUI[" + i + "]: " + targetCharName);

				if (targetChar.IsStealth() == false && targetChar.Alive() == true) {
					targetChar.SetTargetable(true);
					Debug.Log ("Now setting enabled!");
					//targetGroupUI[i].GetComponentInChildren<Button>().interactable = true;
					targetCharName.interactable = true;
				}else{
					Debug.Log ("Now setting DISABLED!");
					targetCharName.interactable = false;
				}
			}
			*/


			int count = 0;
			//set each character in target group as targetable
			foreach (GameObject targetObj in targetGroup) {
				Character targetChar = targetObj.GetComponent<Character>();
				if (targetChar.IsStealth() == false && targetChar.Alive() == true) {
					targetChar.SetTargetable(true);
				}

				count++;


				//Now set the GUI elements as targetable
				if(targetChar.Alive() == true){
					foreach (GameObject targetObjUI in targetGroupUI) {
						Button targetCharName = targetObjUI.GetComponentInChildren<Button>();
						if (targetChar.IsStealth() == false) {
							if(targetChar.Alive()){
								//targetCharName.enabled = true;
								targetCharName.interactable = true;
							}else{
								//targetCharName.enabled = false;
								targetCharName.interactable = false;
							}
						}
					}
				}

			}





			
			controller.gui.DisableButtons();
			abilityButton.image.fillCenter = false;
			
			waitingForTarget = true;
		
		//ability does not require a target
		} else {
			ability.Use(null);
		}
	}
	
	//called on every frame
	private void Update() {
		if (waitingForTarget) {
			foreach (GameObject targetObj in targetGroup) {
				Character targetChar = targetObj.GetComponent<Character>();
				if (targetChar.IsTargeted() && targetChar.Alive()) {
					waitingForTarget = false;
					abilityButton.image.fillCenter = true;


					//Now disable the UI buttons
					foreach (GameObject targetObjUI in targetGroupUI) {
						Button targetCharName = targetObjUI.GetComponentInChildren<Button>();
						targetCharName.interactable = false;
						alliesButton.interactable = false;
						enemiesButton.interactable = false;
					}


					ability.Use(targetChar);
					//Get the UI icon off of the last selected element
					EventSystem.current.SetSelectedGameObject(GameObject.Find ("Allies Button"));
				}


			}
		}
	}
	
	//set up references
	public void Init() {
		controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<BattleController>();
		Debug.Log(transform.GetComponent<Ability>());
		ability = transform.GetComponent<Ability>();
		waitingForTarget = false;

		alliesButton = GameObject.Find ("Allies Button").GetComponent<Button>();
		enemiesButton = GameObject.Find ("Enemies Button").GetComponent<Button>();
		cancelButton = GameObject.Find ("Cancel Button").GetComponent<Button>();

		alliesButton.interactable = true;
		EventSystem.current.SetSelectedGameObject(GameObject.Find ("Allies Button"));
	}
}