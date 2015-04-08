using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpTextTriggering : MonoBehaviour {
	
	public string readableText;
	public string talker;
	public Sprite talkingImage;
	public int specialCase;

	private bool showText;
	private bool textNotShown = true;
	
	private Image bottomBorder;
	private Image chatPanel;
	private Image chatCharacter;
	private Text enterText;
	private Text chatText;
	private Text talkerText;

	private CanvasGroup bottomBorderCG;
	private CanvasGroup chatPanelCG;
	private CanvasGroup chatCharTransparencyCG;
	private CanvasGroup talkerPanelCG;

	void Start(){
		bottomBorder = GameObject.Find ("Bottom Border").GetComponent<Image>();
		chatPanel = GameObject.Find ("Chat Panel").GetComponent<Image>();
		chatCharacter = GameObject.Find ("Chat Character").GetComponent<Image>();
		enterText = GameObject.Find ("Enter Text").GetComponent<Text>();
		chatText = GameObject.Find ("Chat Text").GetComponent<Text>();
		talkerText = GameObject.Find ("Talker Name").GetComponent<Text>();
			
		bottomBorderCG = GameObject.Find ("Bottom Border").GetComponent<CanvasGroup> ();
		chatPanelCG = GameObject.Find ("Chat Panel").GetComponent<CanvasGroup> ();
		chatCharTransparencyCG = GameObject.Find ("Chat Character").GetComponent<CanvasGroup> ();
		talkerPanelCG = GameObject.Find ("Talker Name Panel").GetComponent<CanvasGroup> ();

		enterText.text = "Talk";
		chatText.text = "";
		talkerText.text = "Talker";
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Return))
		{
			if(showText)
			{
				Time.timeScale = 1;
				showText = false;
				textNotShown = false;
				chatPanelCG.alpha = 0;
				talkerPanelCG.alpha = 0;
				chatCharTransparencyCG.alpha = 0;
				chatCharacter.sprite = null;
				talkerText.text = "";
				chatText.text = "";
				bottomBorderCG.alpha = 0; //ensure nothing shows up afterwards
			}
		}
	}

	void OnTriggerEnter()
	{
		if (textNotShown)
		{
			Time.timeScale = 0;
			showText = true;
			chatPanelCG.alpha = 1;
			talkerPanelCG.alpha = 1;
			talkerText.text = talker; //assign the talker name
			if(talkingImage == null){
				chatCharTransparencyCG.alpha = 0; 
			}else{
				chatCharacter.sprite = talkingImage;
				chatCharTransparencyCG.alpha = 1;
			}
			chatText.text = readableText;
		}

		if (specialCase == 1) {
			//insert special commands here
		}
	}


}
