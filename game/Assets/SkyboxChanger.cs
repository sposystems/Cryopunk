using UnityEngine;
using System.Collections;

public class SkyboxChanger : MonoBehaviour {

	// Use this for initialization
	public Material skybox;

	void Awake () {
		//get MainCamera and set the skybox

		RenderSettings.skybox = skybox;	
	}
}
