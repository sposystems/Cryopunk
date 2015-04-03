using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenuAnim : MonoBehaviour {

	//startMenuCanvas is in charge of all main commands in this script
	public CanvasGroup startMenuCanvas;
	//pauseGame keeps track of pause state for pausing/unpausing
	private bool pauseGame = false;
	//inCharScreen used for Character Screen loops
	private bool inCharScreen = false;
	//anim allows us to animate without needing to use the Animator for initial pausing
	private Animator anim;

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

	//Assign all variables to their respective components
	public void Start(){
		anim = startMenuCanvas.GetComponent<Animator> ();

		hpPotions = GameObject.Find ("Health Potion Quantity").GetComponent<Text>();
		spPotions = GameObject.Find ("Special Potion Quantity").GetComponent<Text>();
		lifePotions = GameObject.Find ("Life Potion Quantity").GetComponent<Text>();
		molotovCocktails = GameObject.Find ("Molotov Cocktail Quantity").GetComponent<Text>();
		mrFuns = GameObject.Find ("Mr Fun Quantity").GetComponent<Text>();

		hpPotions.text = "x" + "12"; //CHANGE TO ACTUAL NUMBER FROM DB
		spPotions.text = "x" + "4";
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

		kira_art = Resources.Load<Sprite> ("kira_tp");
		law_art = Resources.Load<Sprite> ("law_tp");
		robo_art = Resources.Load<Sprite> ("robo_tp");
		constance_art = Resources.Load<Sprite> ("constance_tp");
		solan_art = Resources.Load<Sprite> ("solan_tp");


	}

	/*
	IEnumerator Wait(float seconds){
		Debug.Log ("Waited for " + seconds + " seconds.");
		yield return new WaitForSeconds(seconds);
	}
	*/

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



	private void getKiraInfo(){

	}

	public void KiraPress(){
		charName.text = "Kira";
		strStat.text = "300"; //ASSIGN THESE VARIABLES ACCORDING TO DATABASE DATA
		defStat.text = "-50"; //THEY MUST USE MATH VALUES IN FINAL VERSION
		magStat.text = "100";
		lvStat.text = "LV " + "55";
		expStat.text = "423";
		hpStatChars.text = "200/400";
		spStatChars.text = "15/30";
		hpBarChars.fillAmount = 0.5f;
		spBarChars.fillAmount = 0.5f;
		charBookDialog.text = "\"What kind of jokers are you all anyways?\"";

		characterImage.GetComponent<Image>().sprite = kira_art;
		characterImageShadow.GetComponent<Image>().sprite = kira_art;

		GoToCharacters ();
	}

	public void LawPress(){
		charName.text = "Law";
		strStat.text = "1"; //ASSIGN THESE VARIABLES ACCORDING TO DATABASE DATA
		defStat.text = "-9999999"; //THEY MUST USE MATH VALUES IN FINAL VERSION
		magStat.text = "magic?";
		lvStat.text = "LV " + "1";
		expStat.text = ".76";
		hpStatChars.text = "1/100";
		spStatChars.text = "0/0";
		hpBarChars.fillAmount = 0.01f;
		spBarChars.fillAmount = 0.0f;
		charBookDialog.text = "\"Wait, you don't expect a lawyer to fight, do you?  I object to such nonsense!\"";
		
		characterImage.GetComponent<Image>().sprite = law_art;
		characterImageShadow.GetComponent<Image>().sprite = law_art;
		
		GoToCharacters ();
	}

	public void RoboPress(){
		charName.text = "Robo";
		strStat.text = "1000"; //ASSIGN THESE VARIABLES ACCORDING TO DATABASE DATA
		defStat.text = "250"; //THEY MUST USE MATH VALUES IN FINAL VERSION
		magStat.text = "50";
		lvStat.text = "LV " + "76";
		expStat.text = "7382";
		hpStatChars.text = "1000/1000";
		spStatChars.text = "25/25";
		hpBarChars.fillAmount = 1.0f;
		spBarChars.fillAmount = 1.0f;
		charBookDialog.text = "\"BEEP BOOP BOOP BEEP zzt\"";
		
		characterImage.GetComponent<Image>().sprite = robo_art;
		characterImageShadow.GetComponent<Image>().sprite = robo_art;
		
		GoToCharacters ();
	}

	public void ConstancePress(){
		charName.text = "Constance";
		strStat.text = "$8.95"; //ASSIGN THESE VARIABLES ACCORDING TO DATABASE DATA
		defStat.text = "5"; //THEY MUST USE MATH VALUES IN FINAL VERSION
		magStat.text = "1337";
		lvStat.text = "LV " + "12";
		expStat.text = "423";
		hpStatChars.text = "75/300";
		spStatChars.text = "700/700";
		hpBarChars.fillAmount = 0.25f;
		spBarChars.fillAmount = 1.0f;
		charBookDialog.text = "\"Just one more battle... I will prevail!\"";
		
		characterImage.GetComponent<Image>().sprite = constance_art;
		characterImageShadow.GetComponent<Image>().sprite = constance_art;
		
		GoToCharacters ();
	}
	
	public void SolanPress(){
		charName.text = "Solan";
		strStat.text = "69"; //ASSIGN THESE VARIABLES ACCORDING TO DATABASE DATA
		defStat.text = "42"; //THEY MUST USE MATH VALUES IN FINAL VERSION
		magStat.text = "777";
		lvStat.text = "LV " + "95";
		expStat.text = "60023";
		hpStatChars.text = "495/500";
		spStatChars.text = "200/1000";
		hpBarChars.fillAmount = 0.99f;
		spBarChars.fillAmount = 0.2f;
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


	public void Update(){
		if ((Input.GetKeyDown (KeyCode.T) || Input.GetKeyDown (KeyCode.Tab)) && !pauseGame) {
			//If not currently paused, then stop time and show the GUI
			if (!pauseGame) {
				Debug.Log ("Tab/T properly pressed to pause game.");
				pauseGame = true;
				Time.timeScale = 0;
				anim.SetBool ("Main Screen", true);
			}
		} else if ((Input.GetKeyDown (KeyCode.T) || Input.GetKeyDown (KeyCode.Tab)) && pauseGame) {
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
