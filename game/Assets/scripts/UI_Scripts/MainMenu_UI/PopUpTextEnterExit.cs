using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpTextEnterExit : MonoBehaviour {

	private GameObject playerCharacter;
	private GameObject menuHandler;
	private PauseMenuAnim pma;

	public string readableText;
	public string readableText2;
	public string readableText3;
	public string readableText4;
	public string readableText5;
	public string readableText6;
	public string readableText7;
	public string readableText8;
	public string enterTriggerName;
	public string talker;
	public string talker2;
	public string talker3;
	public string talker4;
	public string talker5;
	public string talker6;
	public string talker7;
	public string talker8;
	public Sprite talkingImage;
	public Sprite talkingImage2;
	public Sprite talkingImage3;
	public Sprite talkingImage4;
	public Sprite talkingImage5;
	public Sprite talkingImage6;
	public Sprite talkingImage7;
	public Sprite talkingImage8;
	public int numLinesDialogue;
	public bool changeDialogue;
	public bool changeTalker;
	public bool isRepeatable = true;
	public bool consistentConversation;
	public int specialCase;
	private bool cannotTalk = false;
	
	public bool showText; //must be public for PauseMenuAnim
	private bool inBox;
	
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

	//checks for the end of conversation
	private bool doneWithConversation = true;

	private int count = 0;
	
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

		bottomBorderCG.alpha = 0;

		//set consistent conversation to not being done just yet
		if (consistentConversation) {
			doneWithConversation = false;
		}
	}

	void Update()
	{
		//must be in box of specific object to peform right
		if (inBox) {
			if(Input.GetButtonDown("Submit") && (pma.pauseGame == false))
			{
				//Debug.Log ("inBox = " + inBox);
				//Debug.Log ("timeScale = " + Time.timeScale);
				//Debug.Log ("cannotTalk = " + cannotTalk);

				//if in the collider, not at 0 time, and CAN talk, then show
				if(inBox && Time.timeScale == 1 && (cannotTalk == false) && (doneWithConversation == true)){
					BoxShow(); //positive actions
				}else if(inBox && (cannotTalk == false) && (doneWithConversation == false)){
					BoxShow();
				//if not in collider, currently at 0 time, or not repeatable, don't show
				}else{
					BoxAway(); //negative actions
				}

			}
		}

	}

	//Everything that brings up the dialogue box
	void BoxShow(){
		bottomBorderCG.alpha = 0;
		Time.timeScale = 0;
		showText = true;
		chatPanelCG.alpha = 1;
		//check if there is no talker
		if(talker.Equals("")){
			talkerPanelCG.alpha = 0;
		}else{
			talkerPanelCG.alpha = 1;
			talkerText.text = talker; //assign the talker name
		}

		if(talkingImage == null){
			chatCharTransparencyCG.alpha = 0; 
		}else{
			chatCharacter.sprite = talkingImage;
			chatCharTransparencyCG.alpha = 1;
		}

		
		//if you want to allow different dialogue boxes on subsequent talks
		if(changeDialogue){
			if(count == 0){
				chatText.text = readableText;
				if(changeTalker){
					talkerText.text = talker;
					if(talkingImage == null){
						chatCharTransparencyCG.alpha = 0;
					}else{
						chatCharTransparencyCG.alpha = 1;
						chatCharacter.sprite = talkingImage;
					}
					if(consistentConversation){
						doneWithConversation = false;
					}
				}
			}else if(count == 1){
				chatText.text = readableText2;
				if(changeTalker){
					talkerText.text = talker2;
					if(talkingImage2 == null){
						chatCharTransparencyCG.alpha = 0;
					}else{
						chatCharTransparencyCG.alpha = 1;
						chatCharacter.sprite = talkingImage2;
					}
				}
			}else if(count == 2){
				chatText.text = readableText3;
				if(changeTalker){
					talkerText.text = talker3;
					if(talkingImage3 == null){
						chatCharTransparencyCG.alpha = 0;
					}else{
						chatCharTransparencyCG.alpha = 1;
						chatCharacter.sprite = talkingImage3;
					}
				}
			}else if(count == 3){
				chatText.text = readableText4;
				if(changeTalker){
					talkerText.text = talker4;
					if(talkingImage4 == null){
						chatCharTransparencyCG.alpha = 0;
					}else{
						chatCharTransparencyCG.alpha = 1;
						chatCharacter.sprite = talkingImage4;
					}
				}
			}else if(count == 4){
				chatText.text = readableText5;
				if(changeTalker){
					talkerText.text = talker5;
					if(talkingImage5 == null){
						chatCharTransparencyCG.alpha = 0;
					}else{
						chatCharTransparencyCG.alpha = 1;
						chatCharacter.sprite = talkingImage5;
					}
				}
			}else if(count == 5){
				chatText.text = readableText6;
				if(changeTalker){
					talkerText.text = talker6;
					if(talkingImage6 == null){
						chatCharTransparencyCG.alpha = 0;
					}else{
						chatCharTransparencyCG.alpha = 1;
						chatCharacter.sprite = talkingImage6;
					}
				}
			}else if(count == 6){
				chatText.text = readableText7;
				if(changeTalker){
					talkerText.text = talker7;
					if(talkingImage7 == null){
						chatCharTransparencyCG.alpha = 0;
					}else{
						chatCharTransparencyCG.alpha = 1;
						chatCharacter.sprite = talkingImage7;
					}
				}
			}else if(count == 7){
				chatText.text = readableText8;
				if(changeTalker){
					talkerText.text = talker8;
					if(talkingImage8 == null){
						chatCharTransparencyCG.alpha = 0;
					}else{
						chatCharTransparencyCG.alpha = 1;
						chatCharacter.sprite = talkingImage8;
					}
				}
			}else{
				chatText.text = readableText;
			}
			count++;
			if(count >= numLinesDialogue){
				count = 0; //reset count early if max lines dialogue reached
				//end conversation here if doneWithConversation
				if(consistentConversation){
					doneWithConversation = true;
				}
			}
		}else{
			chatText.text = readableText;
		}
		
		if (specialCase == 1) {
			//insert special commands here
		}
		
		//stops from talking again if isRepeatable is set to false
		if(!isRepeatable){
			cannotTalk = true;
		}
	}

	//Everything that takes away the dialogue box
	void BoxAway(){
		//must still be in the box for the border to show up
		if(inBox && (cannotTalk == false)){
			bottomBorderCG.alpha = 1;
		}
		Time.timeScale = 1;
		showText = false;
		chatPanelCG.alpha = 0;
		talkerPanelCG.alpha = 0;
		chatCharTransparencyCG.alpha = 0;
		chatCharacter.sprite = null;
		talkerText.text = "";
		chatText.text = "";
	}
	
	void OnTriggerEnter()
	{
		//check to see if dialogue has already been exhausted; through isRepeatable = false
		if (cannotTalk) {
			//nothing
		} else {
			inBox = true;
			bottomBorderCG.alpha = 1;
			enterText.text = enterTriggerName;
		}
	}
	
	void OnTriggerExit()
	{
		inBox = false;
		bottomBorderCG.alpha = 0;
		enterText.text = "";
	}

}
