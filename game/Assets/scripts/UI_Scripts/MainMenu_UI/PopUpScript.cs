using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUpScript : MonoBehaviour {

	private Image bottomBorder;
	private Image chatPanel;
	private Text enterText;
	private Text chatText;

	// Use this for initialization
	void Start () {
		bottomBorder = GameObject.Find ("Bottom Border").GetComponent<Image>();
		chatPanel = GameObject.Find ("Chat Panel").GetComponent<Image>();
		enterText = GameObject.Find ("Enter Text").GetComponent<Text>();
		chatText = GameObject.Find ("Chat Text").GetComponent<Text>();

		enterText.text = "Chat";
		chatText.text = "Find Solan!";
		bottomBorder.enabled = false;
		chatPanel.enabled = false;
	}

	public void ReadText(string readableText){
		chatPanel.enabled = true;
		chatText.text = readableText;
	}
	

}
