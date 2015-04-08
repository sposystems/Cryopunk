using UnityEngine;
using System.Collections;

public class initialize : MonoBehaviour {

	private GameObject camera;

	// Use this for initialization
	//public SceneChanger mySceneChanger;
	void Start () {
		//mySceneChanger = new SceneChanger ();//creates a new instance of scenechanger
		camera = GameObject.Find("Main Camera");
		//camera.SetActive (false);
		Destroy (camera);
	}

	void Awake(){

	}

}
