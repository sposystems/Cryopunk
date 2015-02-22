using UnityEngine;
using System.Collections;

public class BattleLauncher : MonoBehaviour {

	public static int enemyType;
	public static int enemyQuantity;
	public static bool fifthMember;
	public static int location;
	public int eType, eQuantity, eLocation;
	public bool fMember;
	public string level;
	/*
	 * So send me a location, enemy type, enemy quantity, 
	 * and a boolean saying whether or not the 5th party member has been acquired.
	 * Lets assume for now that there will be 3 enemy types, 
	 * one that appears in the world, one that appears in the dungeon, 
	 * and the boss.
	 */
	void OnTriggerEnter(Collider other) { 
		enemyType = eType;
		enemyQuantity = eQuantity;
		fifthMember = fMember;
		location = eLocation;
		Application.LoadLevel(level); 
	}
}
