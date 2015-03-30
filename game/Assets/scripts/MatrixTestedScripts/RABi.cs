using UnityEngine;
using System.Collections;

public class RABi : MonoBehaviour {
	public static int enemyType = 0;
	public static int enemyQuantity = 0;
	public static bool fifthMember = false;
	public static int location = 0;
	public int eType, eQuantity, eLocation;
	public bool fMember;
	public string level;

	void OnLevelWasLoaded(){
		//When the scene is loaded, assign all the static vars. 
		enemyType = eType;
		enemyQuantity = eQuantity;
		fifthMember = fMember;
		location = eLocation;
	}
	
}
