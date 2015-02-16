using UnityEngine;
using System.Collections;

public class mainMenuButtons : MonoBehaviour {

	public void LoadScene(){
		Application.LoadLevel ("townTest1");
	}

	public void QuitGame(){
		Application.Quit ();
	}


}
