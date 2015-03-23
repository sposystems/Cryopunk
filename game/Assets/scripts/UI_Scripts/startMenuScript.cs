using UnityEngine;
using System.Collections;

public class startMenuScript : MonoBehaviour {
	//public CanvasGroup startMenuCanvas;
	public static float deltaTime;
	private static float _lastframetime;


	private bool pauseGame = false;
	private bool showGUI = false;

	void Start () {
		//_lastframetime = Time.realtimeSinceStartup;
	}

	void FixedUpdate(){
		//Press T or Tab to pause the game

	}





	/*
	// Update is called once per frame
	void Update () {
		//deltaTime = Time.realtimeSinceStartup - _lastframetime;
		//_lastframetime = Time.realtimeSinceStartup;
		if ((Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.Tab)) && !pauseGame) {
			//If not currently paused, then stop time and show the GUI
			if (!pauseGame) {
				Debug.Log("Tab/T properly pressed to pause game.");
				pauseGame = true;
				//StartCoroutine(Wait(.05f)); //IEnumerator Wait, then stops
				//Time.timeScale = 0;
				startMenuCanvas.animation.Play ("pause_menu_anim1");
			}
		}else if ((Input.GetKeyDown (KeyCode.T) || Input.GetKeyDown (KeyCode.Tab)) && pauseGame) {
			if (pauseGame) {
				Debug.Log ("Tab/T properly pressed to UNpause game.");
				//Time.timeScale = 1;
				pauseGame = false;
				startMenuCanvas.animation.Play ("pause_menu_anim1_exit");
			}
		}

	}
	*/

	IEnumerator Wait(float seconds){
		Debug.Log ("Waited for " + seconds + " seconds.");
		pauseGame = true;
		yield return new WaitForSeconds(seconds);
		Time.timeScale = 0;
	}

	/*
	 * void FixedUpdate(){
		//Press T or Tab to pause the game
		if (Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.Tab)) {
			//If not currently paused, then stop time and show the GUI
			if (!pauseGame) {
				Debug.Log("Tab/T properly pressed to pause game.");
				pauseGame = true;
				showGUI = true;
				//StartCoroutine(Wait(.333f)); //IEnumerator Wait, then stops
				Time.timeScale = 0;
			}else if (pauseGame){
				Debug.Log("Tab/T properly pressed to UNpause game.");
				Time.timeScale = 1;
				pauseGame = false;
				showGUI = false;
			}

			if (showGUI == true) {
				startMenuCanvas.animation.Play ("pause_menu_anim1");
			} else {
				startMenuCanvas.animation.Play ("pause_menu_anim1_exit");
			}
			
			//If we are to show the GUI, play the start animation; otherwise, the exit one

		}
	}*/
	
}
