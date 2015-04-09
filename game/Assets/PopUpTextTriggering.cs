using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpTextTriggering : MonoBehaviour {

	private GameObject playerCharacter;
	private GameObject menuHandler;
	private PauseMenuAnim pma;

	public string readableText;
	public string talker;
	public Sprite talkingImage;
	public int specialCase;

	public bool showText = false; //must be public for PauseMenuAnim
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
		playerCharacter = GameObject.Find ("Swordman 1");

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

		menuHandler = GameObject.Find ("MENU_HANDLER");
		pma = menuHandler.GetComponent<PauseMenuAnim>();

		enterText.text = "Talk";
		chatText.text = "";
		talkerText.text = "Talker";
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Return) && (pma.pauseGame == false))
		{
			//Debug.Log ("Update after Input.GetKeyDown()");
			//Debug.Log ("textNotShown = " + textNotShown);
			//Debug.Log ("showText = " + showText);
			if((showText == true) && (textNotShown == true))
			{
				Debug.Log ("showText && textNotShown are true, executing code.");
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

	//The collider ensures Swordman 1 is the one to collide with the other colliders
	void OnTriggerEnter(Collider collider)
	{
		//Debug.Log ("OnTriggerEnter()");
		//Debug.Log ("textNotShown = " + textNotShown);
		//Debug.Log ("showText = " + showText);
		//Debug.Log ("collider = " + collider.name);
		if ((textNotShown == true) && (collider.name == "Swordman 1"))
		{
			Debug.Log ("textNotShown is true, exeucting onTriggerEnter()");
			Time.timeScale = 0;
			showText = true;
			chatPanelCG.alpha = 1;
			if(talker.Equals("")){
				talkerPanelCG.alpha = 0;
			}else{
				talkerPanelCG.alpha = 1;
				talkerText.text = talker; //assign the talker name
			}
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
