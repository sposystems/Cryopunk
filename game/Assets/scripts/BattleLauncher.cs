using UnityEngine;
using System.Collections;

public class BattleLauncher : MonoBehaviour {
	//Intended for the deployment of a battle on collision
	public static int enemyType = 0;
	public static int enemyQuantity = 0;
	public static bool fifthMember = false;
	public static int location = 0;
	public int eType, eQuantity, eLocation;
	public bool fMember;
	public string level;

	void OnTriggerEnter(Collider other) { 
		enemyType = eType;
		enemyQuantity = eQuantity;
		fifthMember = fMember;
		location = eLocation;
		Application.LoadLevel(level); 
	}
}
