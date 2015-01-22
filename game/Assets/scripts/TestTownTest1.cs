using UnityEngine;
using System.Collections;

public class TestTownTest1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LoadInformation.LoadAllInformation ();
		Debug.Log ("PlayerName: " + GameInformation.PlayerName);
		Debug.Log ("PlayerLevel: " + GameInformation.PlayerLevel.ToString());
		Debug.Log ("PlayerStamina: " + GameInformation.Stamina.ToString());
		Debug.Log ("PlayerEndurance: " + GameInformation.Endurance.ToString());
		Debug.Log ("PlayerIntellect: " + GameInformation.Intellect.ToString());
		Debug.Log ("PlayerStrength: " + GameInformation.Strength.ToString());




	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
