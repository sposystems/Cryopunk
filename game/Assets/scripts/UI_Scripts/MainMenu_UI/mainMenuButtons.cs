using UnityEngine;
using System.Collections;

public class mainMenuButtons : MonoBehaviour {

	public string startingScene;

	public void LoadScene(){
		Application.LoadLevel (startingScene);
	}

	public void QuitGame(){
		Application.Quit ();
	}


}
