using UnityEngine;
using System.Collections;

public class UnlockSolan : MonoBehaviour {

	private DataContainer dc;
	private GameObject menuHandler;
	private PauseMenuAnim pma;

	// Use this for initialization
	void Start () {
		dc = GameObject.FindGameObjectWithTag ("DataContainer").GetComponent<DataContainer>();
		menuHandler = GameObject.Find ("MENU_HANDLER");
		pma = menuHandler.GetComponent<PauseMenuAnim>();
	}

	void OnTriggerEnter(){
		if (dc.haveSolan == false) {
			BattleLauncher.fifthMember = true;
			pma.getSolan ();
			dc.haveSolan = true;
		}
	}

}
