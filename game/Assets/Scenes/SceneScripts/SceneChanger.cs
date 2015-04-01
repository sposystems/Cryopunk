using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour {
	public string level;
	public static Vector3 NewPosition;
	public float PositionX = 356f;
	public float PositionY = 20f;
	public float PositionZ = 565f;
	void Awake() {
		NewPosition = new Vector3 (PositionX, PositionY, PositionZ);
	}
	void OnTriggerEnter(Collider other) { 
		Application.LoadLevel(level); 
	}
}
