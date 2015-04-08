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
	public static int areaNumber = 0;
	public static int instance = 0; 
	//public static bool battled = false;

	public int eType, eQuantity, eLocation, eAreaNumber, launcherInstance; 
	//launcher instance is a number assigned to an instance of a battle cube.
	//launcherInstance = 1, instance = 0,
	//when the battle gets triggered, to disable the cube, set the static number to the launcher instance.
	//if instance 1 == launcherInstance 1, the battle has already taken place.
	public bool isFinalBattle = false;
	public bool fMember;
	public string level;


	void start(){

	}
	void OnTriggerEnter(Collider other) { 
		//check if the player has already defeated the enemy
		if (instance != launcherInstance) { 
			GameObject player = GameObject.Find ("Swordman 1");
			Transform playerTransform = player.transform;
			previousLocation = playerTransform.position;
			Debug.Log ("battle launcher");
			Debug.Log (previousLocation);
			Debug.Log ("Vector 3");
			enemyType = eType;
			enemyQuantity = eQuantity;
			areaNumber = eAreaNumber;
			fifthMember = fMember;
			location = eLocation;
			//battled = true;
			instance = launcherInstance;

		

				Application.LoadLevel (level); 
			
		}	

	}
}
