using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpTextTreasure : MonoBehaviour {

	private GameObject menuHandler;
	private PauseMenuAnim pma;

	private DataContainer dc;

	public Animator anim;
	public GameObject treasureChest;
	public string enterTriggerName;
	public int treasureChestNumber;
	
	public string itemName;
	public int itemQuantity;
	public Sprite itemSprite;

	public bool alreadyOpened;

	public bool showText; //must be public for PauseMenuAnim
	private bool inBox;

	private CanvasGroup bottomBorderCG;
	private Text enterText;
	private CanvasGroup itemGetPanelCG;
	private Text itemNameUI;
	private Image itemImageUI;
	private Text itemQuantityUI;



	// Use this for initialization
	void Start () {
		menuHandler = GameObject.Find ("MENU_HANDLER");
		pma = menuHandler.GetComponent<PauseMenuAnim>();
		bottomBorderCG = GameObject.Find ("Bottom Border").GetComponent<CanvasGroup> ();
		enterText = GameObject.Find ("Enter Text").GetComponent<Text>();
		itemGetPanelCG = GameObject.Find ("Item Get Panel").GetComponent<CanvasGroup> ();
		itemNameUI = GameObject.Find ("Item Get Name").GetComponent<Text> ();
		itemImageUI = GameObject.Find ("Item Get Image").GetComponent<Image> ();
		itemQuantityUI = GameObject.Find ("Item Get Quantity").GetComponent<Text> ();

		dc = GameObject.FindGameObjectWithTag ("DataContainer").GetComponent<DataContainer>();
		if (dc.treasure[treasureChestNumber]) {
			alreadyOpened = true;
			anim.SetBool ("Opened", true);
		}

		bottomBorderCG.alpha = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//must be in box of specific object to peform right
		if (inBox) {
			if(Input.GetButtonDown("Submit") && (pma.pauseGame == false))
			{
				//if in the collider, not at 0 time, and not opened yet, openable
				if(inBox && Time.timeScale == 1 && (alreadyOpened == false)){
					BoxShow(); //positive actions
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
		itemGetPanelCG.alpha = 1;

		itemNameUI.text = "" + itemName;
		itemImageUI.sprite = itemSprite;
		itemQuantityUI.text = "x" + itemQuantity;

		if(itemName.Equals("Health Potion")){
			dc.healthPotionNum = dc.healthPotionNum + itemQuantity;
		}else if(itemName.Equals("Special Potion")){
			dc.specialPotionNum = dc.specialPotionNum + itemQuantity;
		}else if(itemName.Equals("Life Potion")){
			dc.lifePotionNum = dc.lifePotionNum + itemQuantity;
		}else if(itemName.Equals("Molotov Cocktail")){
			dc.molotovCocktailNum = dc.molotovCocktailNum + itemQuantity;
		}else if(itemName.Equals("Mr Fun")){
			dc.mrFunNum = dc.mrFunNum + itemQuantity;
		}else{
			//no extra action
		}

		//set this treasure chest to being unlocked
		dc.treasure[treasureChestNumber] = true;
		anim.SetBool ("Opened", true);
		alreadyOpened = true;
		pma.ItemsScreenUpdate();
		treasureChest.audio.Play();

	}

	//Everything that takes away the dialogue box
	void BoxAway(){
		Time.timeScale = 1;
		showText = false;
		itemGetPanelCG.alpha = 0;

		itemNameUI.text = "";
		itemImageUI.sprite = null;
		itemQuantityUI.text = "";
	}

	void OnTriggerEnter()
	{
		//check to see if dialogue has already been exhausted; through isRepeatable = false
		if (alreadyOpened) {
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
