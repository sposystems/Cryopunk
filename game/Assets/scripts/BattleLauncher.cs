using UnityEngine;
using System.Collections;

public class BattleLauncher : MonoBehaviour {
	//Intended for the deployment of a battle on collision
	//IE Boss battles
	//362,20,552
	public static int enemyType = 0;
	public static int enemyQuantity = 0;
	public static bool fifthMember = false;
	public static int location = 0;
	public static Vector3 previousLocation;
	public int eType, eQuantity, eLocation;
	public bool fMember;
	public string level;


	void OnTriggerEnter(Collider other) { 
		//check if the player has already defeated the enemy
						
		GameObject player = GameObject.Find ("Swordman 1");
		Transform playerTransform = player.transform;
		previousLocation = playerTransform.position;
		Debug.Log ("battle launcher");
		Debug.Log(previousLocation);
		Debug.Log ("Vector 3");
		enemyType = eType;
		enemyQuantity = eQuantity;
		fifthMember = fMember;
		location = eLocation;
		Application.LoadLevel (level); 

	}
}
