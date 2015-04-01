using UnityEngine;
using System.Collections;

public class updatePosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//reference to player object . set position to SceneChanger.NewPosition
		Debug.Log (SceneChanger.NewPosition);
		GameObject.Find("Swordman 1").transform.position = SceneChanger.NewPosition;
	}
	
	// Update is called once per frame

}
