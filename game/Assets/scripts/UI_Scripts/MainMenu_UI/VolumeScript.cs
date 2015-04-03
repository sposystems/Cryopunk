using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour {

	private Text volumeNumber;
	private Scrollbar volumeScrollbar;
	private bool M_Mute = false;

	// Use this for initialization
	void Start (){
		volumeNumber = GameObject.Find ("Volume Number Text").GetComponent<Text>();
		volumeScrollbar = GameObject.Find ("Volume Scrollbar").GetComponent<Scrollbar>();
		//volumeScrollbar.value = from DB;
	}

	public void ChangeAudioVolume(){
		AudioListener.volume = volumeScrollbar.value;
		volumeNumber.text = "" + (volumeScrollbar.value * 100);
	}

	public void MuteAllAudio(){
		//swap true and false paused audio states
		M_Mute = !M_Mute;
		AudioListener.pause = M_Mute;
	}
	
}
