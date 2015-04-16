using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpTextNextArea : MonoBehaviour {

	public string nextAreaName;
	private CanvasGroup bottomBorderAreaSwitch;
	private Text nextAreaText;

	// Use this for initialization
	void Start () {
		bottomBorderAreaSwitch = GameObject.Find ("Bottom Border Area Switch").GetComponent<CanvasGroup> ();
		nextAreaText = GameObject.Find ("Next Area Text").GetComponent<Text> ();
	}


	void OnTriggerEnter(){
		nextAreaText.text = nextAreaName;
		bottomBorderAreaSwitch.alpha = 1;
	}

	void OnTriggerExit(){
		nextAreaText.text = "";
		bottomBorderAreaSwitch.alpha = 0;
	}
}
