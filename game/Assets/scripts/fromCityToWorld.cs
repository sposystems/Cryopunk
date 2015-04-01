using UnityEngine;
using System.Collections;

public class fromCityToWorld : MonoBehaviour {

	// Use this for initialization

	void Start () {
		GameObject.Find("Swordman 1").transform.position = SceneChanger.NewPosition;
	}
	

}
