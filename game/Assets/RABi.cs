using UnityEngine;
using System.Collections;
/*
 * Welcome to RABi  
 * *******************
 * Data for the battle system.
 * Append to each scene. 
 * The character controller will be looking for this script.
 */
public class RABi : MonoBehaviour {

	// Use this for initialization
	public static int e_type = 2;
	public static int e_level = 1;
	public static int e_probability = 1;
	public int enemyType;
	public int enemyLevel;
	public int enemyProbability;
	void OnLevelWasLoaded(){
		enemyType = e_type;
		enemyLevel = e_level;
		enemyProbability = e_probability;
	}

}
