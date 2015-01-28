using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour {
	public string level;
	void OnTriggerEnter(Collider other) { 
		Application.LoadLevel(level); 
	}
}
