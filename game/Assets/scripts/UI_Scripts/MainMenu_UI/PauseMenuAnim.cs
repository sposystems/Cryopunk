using UnityEngine;
using System.Collections;

public class PauseMenuAnim : MonoBehaviour {

	public CanvasGroup startMenuCanvas;
	private bool pauseGame = false;
	Animator anim;

	public void Start(){
		anim = startMenuCanvas.GetComponent<Animator> ();

	}
	/*
	public void goToItems(){
		startMenuCanvas.animation.Play ("pause_menu_anim_main_exit");
		StartCoroutine (Wait (.33f));
		//startMenuCanvas.animation.Play ("pause_menu_items_enter");
	}

	public void itemsGoBackToMain(){
		startMenuCanvas.animation.Play ("pause_menu_items_exit");
		StartCoroutine (Wait (.33f));
		startMenuCanvas.animation.Play ("pause_menu_anim1");
	}
	
	IEnumerator Wait(float seconds){
		Debug.Log ("Waited for " + seconds + " seconds.");
		yield return new WaitForSeconds(seconds);
	}

	public void Shift1(){
		anim.SetBool ("mainState", true);
		anim.SetTrigger ("mainState");
	}
	*/
	
	public void OpenMenu(){
		if ((Input.GetKeyDown (KeyCode.T) || Input.GetKeyDown (KeyCode.Tab)) && !pauseGame) {
			//If not currently paused, then stop time and show the GUI
			if (!pauseGame) {
				Debug.Log ("Tab/T properly pressed to pause game.");
				pauseGame = true;
				//StartCoroutine(Wait(.05f)); //IEnumerator Wait, then stops
				//Time.timeScale = 0;
				//startMenuCanvas.animation.Play ("pause_menu_anim1");
			}
		} else if ((Input.GetKeyDown (KeyCode.T) || Input.GetKeyDown (KeyCode.Tab)) && pauseGame) {
			if (pauseGame) {
				Debug.Log ("Tab/T properly pressed to UNpause game.");
				//Time.timeScale = 1;
				pauseGame = false;
				//startMenuCanvas.animation.Play ("pause_menu_anim1_exit");
			}
		}
	}



	
	public void Update(){
		if ((Input.GetKeyDown (KeyCode.T) || Input.GetKeyDown (KeyCode.Tab)) && !pauseGame) {
			//If not currently paused, then stop time and show the GUI
			if (!pauseGame) {
				Debug.Log ("Tab/T properly pressed to pause game.");
				pauseGame = true;
				//StartCoroutine(Wait(.05f)); //IEnumerator Wait, then stops
				Time.timeScale = 0;
				//startMenuCanvas.animation.Play ("pause_menu_anim1");
				anim.SetBool ("Main Screen", true);
			}
		} else if ((Input.GetKeyDown (KeyCode.T) || Input.GetKeyDown (KeyCode.Tab)) && pauseGame) {
			if (pauseGame) {
				Debug.Log ("Tab/T properly pressed to UNpause game.");
				Time.timeScale = 1;
				pauseGame = false;
				//startMenuCanvas.animation.Play ("pause_menu_anim1_exit");
				anim.SetBool ("Main Screen", false);
			}
		}
	}
}
