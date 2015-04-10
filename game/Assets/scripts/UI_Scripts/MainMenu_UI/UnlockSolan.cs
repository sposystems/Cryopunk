﻿using UnityEngine;
using System.Collections;

public class UnlockSolan : MonoBehaviour {

	private GameObject menuHandler;
	private PauseMenuAnim pma;

	// Use this for initialization
	void Start () {
		menuHandler = GameObject.Find ("MENU_HANDLER");
		pma = menuHandler.GetComponent<PauseMenuAnim>();
	}

	void OnTriggerEnter(){
		BattleLauncher.fifthMember = true;
		pma.getSolan ();
	}

}
