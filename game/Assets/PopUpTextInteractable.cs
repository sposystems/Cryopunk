using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpTextInteractable : MonoBehaviour {

	private GameObject playerCharacter;
	private GameObject menuHandler;
	private PauseMenuAnim pma;
	
	public string readableText;
	public string readableText2;
	public string readableText3;
	public string readableText4;
	public string readableText5;
	public string enterTriggerName;
	public string talker;
	public Sprite talkingImage;
	public int numLinesDialogue;
	public bool changeDialogue;
	public bool isRepeatable = true;
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
	
	private int count = 0;

	//Special Case 1
	private GameObject boulder;
	private GameObject boulderTrig;
	public string animType;
	private bool flipped;
	
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

		//Special Case 1
		if (specialCase == 1) {
			boulder = GameObject.Find("BlockingBoulder");
			boulderTrig = GameObject.Find("BoulderTrigger");
		}
	}
	
	void Update()
	{
		//must be in box of specific object to peform right
		if (inBox) {
			if(Input.GetKeyDown (KeyCode.Return) && (pma.pauseGame == false))
			{
				//if in the collider, not at 0 time, and CAN talk, then show
				if(inBox && Time.timeScale == 1 && (cannotTalk == false)){
					BoxShow(); //positive actions
				}
				//if not in collider, currently at 0 time, or not repeatable, don't show
				else{
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
			}else if(count == 1){
				chatText.text = readableText2;
			}else if(count == 2){
				chatText.text = readableText3;
			}else if(count == 3){
				chatText.text = readableText4;
			}else if(count == 4){
				chatText.text = readableText5;
				count = 0; //reset count back to 0 to loop
			}else{
				chatText.text = readableText;
			}
			count++;
			if(count >= numLinesDialogue){
				count = 0; //reset count early if max lines dialogue reached
			}
		}else{
			chatText.text = readableText;
		}
		
		if (specialCase == 1) {
			//move the boulder in the cave
			MoveBoulder ();
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
	
	//Special Case 1. Move the boulder in the cave
	void MoveBoulder(){
		animation.Play(animType);
		flipped = true;
		boulder.transform.position = new Vector3(200,0,150);
		boulderTrig.transform.position = new Vector3(200,0,150);
	}
}
