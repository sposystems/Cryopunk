using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenuAnim : MonoBehaviour {

	//startMenuCanvas is in charge of all main commands in this script
	public CanvasGroup startMenuCanvas;
	public CanvasGroup fifthCanvas; //Solan's Canvas Group for visibility
	//pauseGame keeps track of pause state for pausing/unpausing
	public bool pauseGame = false;
	//inCharScreen used for Character Screen loops
	private bool inCharScreen = false;
	//anim allows us to animate without needing to use the Animator for initial pausing
	private Animator anim;

	//Variables for ensuring no pausing while in menus
	private GameObject[] popUps1;
	private GameObject[] popUps2;
	private GameObject[] popUps3;
	private PopUpTextTriggering[] pu1;
	private PopUpTextEnterExit[] pu2;
	private PopUpTextInteractable[] pu3;

	private Text locationArea;

	private GameObject player1;
	private GameObject player2;
	private GameObject player3;
	private GameObject player4;
	private GameObject player5;
	private Character player1Character;
	private Character player2Character;
	private Character player3Character;
	private Character player4Character;
	private Character player5Character;

	private bool fifthAcquired = false;

	//HP Text, SP, LV, etc. for all 5 characters' boxes
	private Text hpTextK;
	private Text hpTextL;
	private Text hpTextR;
	private Text hpTextC;
	private Text hpTextS;

	private Text spTextK;
	private Text spTextL;
	private Text spTextR;
	private Text spTextC;
	private Text spTextS;

	private Text lvTextK;
	private Text lvTextL;
	private Text lvTextR;
	private Text lvTextC;
	private Text lvTextS;

	private Text expTextK;
	private Text expTextL;
	private Text expTextR;
	private Text expTextC;
	private Text expTextS;

	private Image scrollbarHPK;
	private Image scrollbarSPK;
	private Image scrollbarHPL;
	private Image scrollbarSPL;
	private Image scrollbarHPR;
	private Image scrollbarSPR;
	private Image scrollbarHPC;
	private Image scrollbarSPC;
	private Image scrollbarHPS;
	private Image scrollbarSPS;

	//Items Screen Variables
	private Text hpPotions;
	private Text spPotions;
	private Text lifePotions;
	private Text molotovCocktails;
	private Text mrFuns;

	private Sprite hpPotionArt;
	private Sprite spPotionArt;
	private Sprite lifePotionArt;
	private Sprite molotovCocktailArt;
	private Sprite mrFunArt;

	private Image itemImage;
	private Text itemDesc;
	/// <summary>
	/// INSERT OTHER ITEMS HERE
	/// </summary>

	
	//Character Screen Variables
	private Text strStat;
	private Text defStat;
	private Text magStat;
	private Text hpStatChars;
	private Text spStatChars;
	private Image hpBarChars;
	private Image spBarChars;
	private Text lvStat;
	private Text expStat;
	private Text charName;
	private Image characterImage;
	private Image characterImageShadow;
	private Text charBookDialog;

	private Sprite kira_art;
	private Sprite law_art;
	private Sprite robo_art;
	private Sprite constance_art;
	private Sprite solan_art;
	private Image solan_menu_image;
	private Image solan_select_image;

	//Exit Game Variables
	//private Image overlappingBackPanel;

	//Assign all variables to their respective components
	public void Start(){
		anim = startMenuCanvas.GetComponent<Animator> ();

		//Initializing arrays of objects with select tags
		popUps1 = GameObject.FindGameObjectsWithTag ("Trigger1");
		popUps2 = GameObject.FindGameObjectsWithTag ("Trigger2");
		popUps3 = GameObject.FindGameObjectsWithTag ("Trigger3");
		pu1 = new PopUpTextTriggering[popUps1.Length];
		pu2 = new PopUpTextEnterExit[popUps2.Length];
		pu3 = new PopUpTextInteractable[popUps3.Length];
		for (int i = 0; i < popUps1.Length; i++) {
			pu1[i] = popUps1[i].GetComponent<PopUpTextTriggering>();
			Debug.Log (pu1[i].name);
		}
		for (int i = 0; i < popUps2.Length; i++) {
			pu2[i] = popUps2[i].GetComponent<PopUpTextEnterExit>();
			Debug.Log (pu2[i].name);
		}
		for (int i = 0; i < popUps3.Length; i++) {
			pu3[i] = popUps3[i].GetComponent<PopUpTextInteractable>();
			Debug.Log (pu3[i].name);
		}


		locationArea = GameObject.Find ("Location").GetComponent<Text>();

		hpPotions = GameObject.Find ("Health Potion Quantity").GetComponent<Text>();
		spPotions = GameObject.Find ("Special Potion Quantity").GetComponent<Text>();
		lifePotions = GameObject.Find ("Life Potion Quantity").GetComponent<Text>();
		molotovCocktails = GameObject.Find ("Molotov Cocktail Quantity").GetComponent<Text>();
		mrFuns = GameObject.Find ("Mr Fun Quantity").GetComponent<Text>();

		hpPotions.text = "x" + "3"; //CHANGE TO ACTUAL NUMBER FROM DB
		spPotions.text = "x" + "2";
		lifePotions.text = "x" + "0";
		molotovCocktails.text = "x" + "0";
		mrFuns.text = "x" + "0";

		itemDesc = GameObject.Find ("Item Description").GetComponent<Text>();
		itemImage = GameObject.Find ("Item Image Big").GetComponent<Image>();

		hpPotionArt = Resources.Load<Sprite> ("hp_potion");
		spPotionArt = Resources.Load<Sprite> ("sp_potion");
		lifePotionArt = Resources.Load<Sprite> ("life_potion");
		molotovCocktailArt = Resources.Load<Sprite> ("molotov_cocktail");
		mrFunArt = Resources.Load<Sprite> ("mr_fun_item");

		strStat = GameObject.Find ("STR Stat").GetComponent<Text>();
		defStat = GameObject.Find ("DEF Stat").GetComponent<Text>();
		magStat = GameObject.Find ("MAG Stat").GetComponent<Text>();
		hpStatChars = GameObject.Find ("HP_Num (Chars)").GetComponent<Text>();
		spStatChars = GameObject.Find ("SP_Num (Chars)").GetComponent<Text>();
		hpBarChars = GameObject.Find ("hp_bar_percent (Chars)").GetComponent<Image>();
		spBarChars = GameObject.Find ("sp_bar_percent (Chars)").GetComponent<Image>();
		lvStat = GameObject.Find ("Level Stat (Chars)").GetComponent<Text>();
		expStat = GameObject.Find ("To Next Stat (Chars)").GetComponent<Text>();
		charName = GameObject.Find ("Char Name Text").GetComponent<Text>();
		characterImage = GameObject.Find ("Char Image").GetComponent<Image>();
		characterImageShadow = GameObject.Find ("Char Image Shadow").GetComponent<Image>();
		charBookDialog = GameObject.Find ("Char Book Dialog").GetComponent<Text> ();

		//Solan specific parameters for acquirement
		solan_menu_image = GameObject.Find ("CharDetails (Solan)").GetComponent<Image>();
		solan_select_image = GameObject.Find ("Solan Select").GetComponent<Image>();

		kira_art = Resources.Load<Sprite> ("kira_tp");
		law_art = Resources.Load<Sprite> ("law_tp");
		robo_art = Resources.Load<Sprite> ("robo_tp");
		constance_art = Resources.Load<Sprite> ("constance_tp");
		solan_art = Resources.Load<Sprite> ("solan_tp");

		//Character Finding/Loading
		player1 = GameObject.Find ("Warrior");
		player1Character = player1.GetComponent<Character>();
		player1.transform.position = new Vector3(14,-1000,-8.5f);

		player2 = GameObject.Find ("Wizard");
		player2Character = player2.GetComponent<Character>();
		player2.transform.position = new Vector3(14,-1000,-8.5f);

		player3 = GameObject.Find ("Thief");
		player3Character = player3.GetComponent<Character>();
		player3.transform.position = new Vector3(14,-1000,-8.5f);

		player4 = GameObject.Find ("Priest");
		player4Character = player4.GetComponent<Character>();
		player4.transform.position = new Vector3(14,-1000,-8.5f);
		
		if (fifthAcquired) {
			player5 = GameObject.Find ("Archer");
			player5Character = player5.GetComponent<Character> ();
			player5.transform.position = new Vector3(14,-1000,-8.5f);
			fifthCanvas.alpha = 1; //Active Solan Canvas
		} else {
			player5 = GameObject.Find ("Archer");
			player5Character = player5.GetComponent<Character> ();
			player5.transform.position = new Vector3(14,-1000,-8.5f);
			solan_menu_image.enabled = false;
			solan_select_image.enabled = false;
			fifthCanvas.alpha = 0; //Inactive Solan Canvas
		}

		//All main menu box details below
		hpTextK = GameObject.Find ("CharDetails (Kira)/hp_bar_outline/HP_Num").GetComponent<Text>();
		scrollbarHPK = GameObject.Find ("CharDetails (Kira)/hp_bar_percent").GetComponent<Image>();
		spTextK = GameObject.Find ("CharDetails (Kira)/sp_bar_outline/SP_Num").GetComponent<Text>();
		scrollbarSPK = GameObject.Find ("CharDetails (Kira)/sp_bar_percent").GetComponent<Image>();
		lvTextK = GameObject.Find ("CharDetails (Kira)/Level").GetComponent<Text>();
		expTextK = GameObject.Find ("CharDetails (Kira)/ToNext").GetComponent<Text>();

		hpTextL = GameObject.Find ("CharDetails (Law)/hp_bar_outline/HP_Num").GetComponent<Text>();
		scrollbarHPL = GameObject.Find ("CharDetails (Law)/hp_bar_percent").GetComponent<Image>();
		spTextL = GameObject.Find ("CharDetails (Law)/sp_bar_outline/SP_Num").GetComponent<Text>();
		scrollbarSPL = GameObject.Find ("CharDetails (Law)/sp_bar_percent").GetComponent<Image>();
		lvTextL = GameObject.Find ("CharDetails (Law)/Level").GetComponent<Text>();
		expTextL = GameObject.Find ("CharDetails (Law)/ToNext").GetComponent<Text>();

		hpTextR = GameObject.Find ("CharDetails (Robo)/hp_bar_outline/HP_Num").GetComponent<Text>();
		scrollbarHPR = GameObject.Find ("CharDetails (Robo)/hp_bar_percent").GetComponent<Image>();
		spTextR = GameObject.Find ("CharDetails (Robo)/sp_bar_outline/SP_Num").GetComponent<Text>();
		scrollbarSPR = GameObject.Find ("CharDetails (Robo)/sp_bar_percent").GetComponent<Image>();
		lvTextR = GameObject.Find ("CharDetails (Robo)/Level").GetComponent<Text>();
		expTextR = GameObject.Find ("CharDetails (Robo)/ToNext").GetComponent<Text>();

		hpTextC = GameObject.Find ("CharDetails (Constance)/hp_bar_outline/HP_Num").GetComponent<Text>();
		scrollbarHPC = GameObject.Find ("CharDetails (Constance)/hp_bar_percent").GetComponent<Image>();
		spTextC = GameObject.Find ("CharDetails (Constance)/sp_bar_outline/SP_Num").GetComponent<Text>();
		scrollbarSPC = GameObject.Find ("CharDetails (Constance)/sp_bar_percent").GetComponent<Image>();
		lvTextC = GameObject.Find ("CharDetails (Constance)/Level").GetComponent<Text>();
		expTextC = GameObject.Find ("CharDetails (Constance)/ToNext").GetComponent<Text>();

		if (fifthAcquired) {
			hpTextS = GameObject.Find ("CharDetails (Solan)/hp_bar_outline/HP_Num").GetComponent<Text>();
			scrollbarHPS = GameObject.Find ("CharDetails (Solan)/hp_bar_percent").GetComponent<Image>();
			spTextS = GameObject.Find ("CharDetails (Solan)/sp_bar_outline/SP_Num").GetComponent<Text>();
			scrollbarSPS = GameObject.Find ("CharDetails (Solan)/sp_bar_percent").GetComponent<Image>();
			lvTextS = GameObject.Find ("CharDetails (Solan)/Level").GetComponent<Text>();
			expTextS = GameObject.Find ("CharDetails (Solan)/ToNext").GetComponent<Text>();
		}

	}

	/*
	IEnumerator Wait(float seconds){
		Debug.Log ("Waited for " + seconds + " seconds.");
		yield return new WaitForSeconds(seconds);
	}
	*/

	public void getSolan(){
		//player5 = (GameObject)Instantiate (Resources.Load ("Archer"));
		player5 = GameObject.Find ("Archer");
		player5Character = player5.GetComponent<Character> ();
		player5Character.currentHP = player5Character.maxHp;
		player5Character.currentSP = player5Character.maxSp;

		hpTextS = GameObject.Find ("CharDetails (Solan)/hp_bar_outline/HP_Num").GetComponent<Text>();
		scrollbarHPS = GameObject.Find ("CharDetails (Solan)/hp_bar_percent").GetComponent<Image>();
		spTextS = GameObject.Find ("CharDetails (Solan)/sp_bar_outline/SP_Num").GetComponent<Text>();
		scrollbarSPS = GameObject.Find ("CharDetails (Solan)/sp_bar_percent").GetComponent<Image>();
		lvTextS = GameObject.Find ("CharDetails (Solan)/Level").GetComponent<Text>();
		expTextS = GameObject.Find ("CharDetails (Solan)/ToNext").GetComponent<Text>();

		solan_select_image = GameObject.Find ("Solan Select").GetComponent<Image>();
		solan_select_image.enabled = true;
		solan_menu_image.enabled = true;
		fifthCanvas.alpha = 1;

		BattleLauncher.fifthMember = true;
		fifthAcquired = true;
	}

	public void hpPotionPress(){
		changeItemInfo ("hpPotion");
	}

	public void spPotionPress(){
		changeItemInfo ("spPotion");
	}

	public void lifePotionPress(){
		changeItemInfo ("lifePotion");
	}

	public void molotovCocktailPress(){
		changeItemInfo ("molotovCocktail");
	}

	public void mrFunPress(){
		changeItemInfo ("mrFun");
	}

	private void changeItemInfo(string itemName){
		if(itemName == "hpPotion"){
			itemDesc.text = "A restorative potion used for restoring a small amount of HP.";
			itemImage.GetComponent<Image>().sprite = hpPotionArt;
		}else if(itemName == "spPotion"){
			itemDesc.text = "A special potion used for restoring a small amount of SP.";
			itemImage.GetComponent<Image>().sprite = spPotionArt;
		}else if(itemName == "lifePotion"){
			itemDesc.text = "A holy potion used for resurrecting people from death.";
			itemImage.GetComponent<Image>().sprite = lifePotionArt;
		}else if(itemName == "molotovCocktail"){
			itemDesc.text = "An otherworldly weapon used for intense combat situations.";
			itemImage.GetComponent<Image>().sprite = molotovCocktailArt;
		}else if(itemName == "mrFun"){
			itemDesc.text = "A remnant of fun found by an ancient locator service entitled Fun Finder™.";
			itemImage.GetComponent<Image>().sprite = mrFunArt;
		}
	}
	
	public void KiraPress(){
		charName.text = "" + player1Character.characterName;
		strStat.text = "" + player1Character.str;;
		defStat.text = "" + player1Character.def;;
		magStat.text = "" + player1Character.mag;
		lvStat.text = "LV " + player1Character.lv;
		expStat.text = "" + player1Character.exp;;
		hpStatChars.text = player1Character.currentHP + "/" + player1Character.maxHp;
		spStatChars.text = player1Character.currentSP + "/" + player1Character.maxSp;
		hpBarChars.fillAmount = (float) player1Character.currentHP / (float) player1Character.maxHp;
		spBarChars.fillAmount = (float) player1Character.currentSP / (float) player1Character.maxSp;
		charBookDialog.text = "\"What kind of jokers are you all anyways?\"";

		characterImage.GetComponent<Image>().sprite = kira_art;
		characterImageShadow.GetComponent<Image>().sprite = kira_art;

		GoToCharacters ();
	}

	public void LawPress(){
		charName.text = "" + player2Character.characterName;
		strStat.text = "" + player2Character.str;;
		defStat.text = "" + player2Character.def;;
		magStat.text = "" + player2Character.mag;
		lvStat.text = "LV " + player2Character.lv;
		expStat.text = "" + player2Character.exp;;
		hpStatChars.text = player2Character.currentHP + "/" + player2Character.maxHp;
		spStatChars.text = player2Character.currentSP + "/" + player2Character.maxSp;
		hpBarChars.fillAmount = (float) player2Character.currentHP / (float) player2Character.maxHp;
		spBarChars.fillAmount = (float) player2Character.currentSP / (float) player2Character.maxSp;
		charBookDialog.text = "\"Wait, you don't expect a lawyer to fight, do you?  I object to such nonsense!\"";
		
		characterImage.GetComponent<Image>().sprite = law_art;
		characterImageShadow.GetComponent<Image>().sprite = law_art;
		
		GoToCharacters ();
	}

	public void RoboPress(){
		charName.text = "" + player3Character.characterName;
		strStat.text = "" + player3Character.str;;
		defStat.text = "" + player3Character.def;;
		magStat.text = "" + player3Character.mag;
		lvStat.text = "LV " + player3Character.lv;
		expStat.text = "" + player3Character.exp;;
		hpStatChars.text = player3Character.currentHP + "/" + player3Character.maxHp;
		spStatChars.text = player3Character.currentSP + "/" + player3Character.maxSp;
		hpBarChars.fillAmount = (float) player3Character.currentHP / (float) player3Character.maxHp;
		spBarChars.fillAmount = (float) player3Character.currentSP / (float) player3Character.maxSp;
		charBookDialog.text = "\"BEEP BOOP BOOP BEEP zzt\"";
		
		characterImage.GetComponent<Image>().sprite = robo_art;
		characterImageShadow.GetComponent<Image>().sprite = robo_art;
		
		GoToCharacters ();
	}

	public void ConstancePress(){
		charName.text = "" + player4Character.characterName;
		strStat.text = "" + player4Character.str;;
		defStat.text = "" + player4Character.def;;
		magStat.text = "" + player4Character.mag;
		lvStat.text = "LV " + player4Character.lv;
		expStat.text = "" + player4Character.exp;;
		hpStatChars.text = player4Character.currentHP + "/" + player4Character.maxHp;
		spStatChars.text = player4Character.currentSP + "/" + player4Character.maxSp;
		hpBarChars.fillAmount = (float) player4Character.currentHP / (float) player4Character.maxHp;
		spBarChars.fillAmount = (float) player4Character.currentSP / (float) player4Character.maxSp;
		charBookDialog.text = "\"Just one more battle... I will prevail!\"";
		
		characterImage.GetComponent<Image>().sprite = constance_art;
		characterImageShadow.GetComponent<Image>().sprite = constance_art;
		
		GoToCharacters ();
	}
	
	public void SolanPress(){
		charName.text = "" + player5Character.characterName;
		strStat.text = "" + player5Character.str;;
		defStat.text = "" + player5Character.def;;
		magStat.text = "" + player5Character.mag;
		lvStat.text = "LV " + player5Character.lv;
		expStat.text = "" + player5Character.exp;;
		hpStatChars.text = player5Character.currentHP + "/" + player5Character.maxHp;
		spStatChars.text = player5Character.currentSP + "/" + player5Character.maxSp;
		hpBarChars.fillAmount = (float) player5Character.currentHP / (float) player5Character.maxHp;
		spBarChars.fillAmount = (float) player5Character.currentSP / (float) player5Character.maxSp;
		charBookDialog.text = "\"Y'all are idiots.\"";
		
		characterImage.GetComponent<Image>().sprite = solan_art;
		characterImageShadow.GetComponent<Image>().sprite = solan_art;
		
		GoToCharacters ();
	}


	public void GoToItems(){
		anim.SetBool ("Items Screen", true);
	}

	public void GoToCharacters(){
		if (!inCharScreen) {
			inCharScreen = true;
			anim.SetBool ("Characters Screen", true);
		} else {
			anim.SetTrigger ("Reenter");
		}
	}
	
	public void GoToOptions(){
		anim.SetBool ("Options Screen", true);
	}

	public void GoToExit(){
		anim.SetBool ("Exit Screen", true);
	}

	public void GoToMain(){
		inCharScreen = false;
		anim.SetBool ("Items Screen", false);
		anim.SetBool ("Characters Screen", false);
		anim.SetBool ("Options Screen", false);
		anim.SetBool ("Exit Screen", false);
	}

	public void QuitGame(){
		//Destroy(GameObject.Find ("PlayerContainer"));
		//Application.LoadLevel ("MainMenu");
		Application.Quit ();
	}

	public void UpdateParametersOnMenuOpen(){
		locationArea.text = Application.loadedLevelName; //set area to name of Scene

		hpTextK.text = player1Character.currentHP + "/" + player1Character.maxHp;
		spTextK.text = player1Character.currentSP + "/" + player1Character.maxSp;
		lvTextK.text = "LV " + player1Character.lv;
		expTextK.text = "" + player1Character.exp;
		scrollbarHPK.fillAmount = (float) player1Character.currentHP / (float) player1Character.maxHp;
		scrollbarSPK.fillAmount = (float) player1Character.currentSP / (float) player1Character.maxSp;
	
		hpTextL.text = player2Character.currentHP + "/" + player2Character.maxHp;
		spTextL.text = player2Character.currentSP + "/" + player2Character.maxSp;
		lvTextL.text = "LV " + player2Character.lv;
		expTextL.text = "" + player2Character.exp;
		scrollbarHPL.fillAmount = (float) player2Character.currentHP / (float) player2Character.maxHp;
		scrollbarSPL.fillAmount = (float) player2Character.currentSP / (float) player2Character.maxSp;

		hpTextR.text = player3Character.currentHP + "/" + player3Character.maxHp;
		spTextR.text = player3Character.currentSP + "/" + player3Character.maxSp;
		lvTextR.text = "LV " + player3Character.lv;
		expTextR.text = "" + player3Character.exp;
		scrollbarHPR.fillAmount = (float) player3Character.currentHP / (float) player3Character.maxHp;
		scrollbarSPR.fillAmount = (float) player3Character.currentSP / (float) player3Character.maxSp;

		hpTextC.text = player4Character.currentHP + "/" + player4Character.maxHp;
		spTextC.text = player4Character.currentSP + "/" + player4Character.maxSp;
		lvTextC.text = "LV " + player4Character.lv;
		expTextC.text = "" + player4Character.exp;
		scrollbarHPC.fillAmount = (float) player4Character.currentHP / (float) player4Character.maxHp;
		scrollbarSPC.fillAmount = (float) player4Character.currentSP / (float) player4Character.maxSp;

		if (fifthAcquired) {
			hpTextS.text = player5Character.currentHP + "/" + player5Character.maxHp;
			spTextS.text = player5Character.currentSP + "/" + player5Character.maxSp;
			lvTextS.text = "LV " + player5Character.lv;
			expTextS.text = "" + player5Character.exp;
			scrollbarHPS.fillAmount = (float) player5Character.currentHP / (float) player5Character.maxHp;
			scrollbarSPS.fillAmount = (float) player5Character.currentSP / (float) player5Character.maxSp;
		}
	}

	//Checks to ensure that every single pop up text is turned off
	public bool allPopUpsOff(){
		foreach (PopUpTextTriggering pop1 in pu1) {
			if(pop1.showText == true){
				return false;
			}
		}
		foreach (PopUpTextEnterExit pop2 in pu2) {
			if(pop2.showText == true){
				return false;
			}
		}
		foreach (PopUpTextInteractable pop3 in pu3) {
			if(pop3.showText == true){
				return false;
			}
		}

		//return true in all cases where everything succeeds
		return true;
	}


	public void Update(){
		if ((Input.GetKeyDown (KeyCode.T) || Input.GetKeyDown (KeyCode.Tab)) && !pauseGame) {
			//If not currently paused & all pops ups are off, then stop time and show the GUI
			if (!pauseGame && allPopUpsOff()) {
				Debug.Log ("Tab/T properly pressed to pause game.");
				pauseGame = true;
				Time.timeScale = 0;
				UpdateParametersOnMenuOpen();
				anim.SetBool ("Main Screen", true);
			}
		} else if ((Input.GetKeyDown (KeyCode.T) || Input.GetKeyDown (KeyCode.Tab) || Input.GetKeyDown (KeyCode.Escape)) && pauseGame) {
			if (pauseGame) {
				Debug.Log ("Tab/T properly pressed to UNpause game.");
				Time.timeScale = 1;
				pauseGame = false;

				inCharScreen = false;
				anim.SetBool ("Main Screen", false);
				anim.SetBool ("Items Screen", false);
				anim.SetBool ("Characters Screen", false);
				anim.SetBool ("Options Screen", false);
				anim.SetBool ("Exit Screen", false);
			}
		}
	}
}
