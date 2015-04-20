using UnityEngine;
using System.Collections;

public class UnlockSecret : MonoBehaviour {

	DataContainer dc;

	// Use this for initialization
	void Start () {
		dc = GameObject.FindGameObjectWithTag ("DataContainer").GetComponent<DataContainer> ();
	}

	void OnTriggerEnter(){
		dc.getSecret = true;
	}
}
