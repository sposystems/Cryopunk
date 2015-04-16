using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour {
	//(356.0, 20.0, 565.0)
	//86,20,1767
	//-76.40581, 6.855456, -173.1025
	public string level;

	public static float PositionX = -76.40581f;
	public static float PositionY = 6.855456f;
	public static float PositionZ = -173.1025f;
	public float sendToX;
	public float sendToY;
	public float sendToZ;
	public static Vector3 NewPosition = new Vector3 (PositionX, PositionY, PositionZ);

	private CanvasGroup loadingScreen;
	private GameObject[] loaders;

	void Awake() {
		//NewPosition = new Vector3 (sendToX, sendToY, sendToZ);
		//NewPosition.x = sendToX;
		//NewPosition.y = sendToY;
		//NewPosition.z = sendToZ;
	}
	void OnTriggerEnter(Collider other) { 
		//NewPosition = new Vector3 (PositionX, PositionY, PositionZ);
		NewPosition.x = sendToX;
		NewPosition.y = sendToY;
		NewPosition.z = sendToZ;

		loaders = GameObject.FindGameObjectsWithTag ("LoadScreen");

		if (loaders.Length > 0) {
			Debug.Log ("Number of loaders (>0): " + loaders.Length);
			loadingScreen = GameObject.Find ("Scene Change Panel").GetComponent<CanvasGroup>();
			loadingScreen.animation.Play ("loading_fade_in");
			loadingScreen.alpha = 1;
			
			StartCoroutine (Wait (1.5f));
		} else {
			Debug.Log ("Number of loaders (OUT): " + loaders.Length);
			//loadingScreen = GameObject.Find ("Scene Change Panel").GetComponent<CanvasGroup>();
			//loadingScreen.animation.Play ("loading_fade_out");
			//loadingScreen.alpha = 0;
			Application.LoadLevel(level);
		}


	}
	public static void setPositionThroughCode(float x, float y, float z){
		NewPosition.x = x;
		NewPosition.y = y;
		NewPosition.z = z;
	}
	public static void setPositionThroughCode(Vector3 newPosition){
		NewPosition = newPosition;
	}
	public static void winChangeScene(){
		NewPosition = BattleLauncher.previousLocation; //battle launcher holds where the player launched from. (vector3)
		adjust();
		//could just end game
		Application.LoadLevel(PlayerPrefs.GetInt("previouslevel")); //sends player to area before battle (numbered scene)

		}
	private static void adjust(){ // kick back to not launch battle again
		//NewPosition.x += 20;
		NewPosition.y += 2;
		//NewPosition.z += 20;
	}

	IEnumerator Wait(float seconds){
		Debug.Log ("Waited for " + seconds + " seconds.");
		yield return new WaitForSeconds(seconds);
		Application.LoadLevel(level); 
		loadingScreen = GameObject.Find ("Scene Change Panel").GetComponent<CanvasGroup>();
		loadingScreen.animation.Play ("loading_fade_out");
	}
}
