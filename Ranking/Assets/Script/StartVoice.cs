using UnityEngine;
using System.Collections;

public class StartVoice : MonoBehaviour {
	
	public VoiceControl VoiceControl;

	// Use this for initialization
	void  OnEnable () 
	{
		StartCoroutine ("VoiceTime");
	}

	IEnumerator	VoiceTime ()
	{
		VoiceControl.startVoice.enabled = true;
		yield return new WaitForSeconds (15);
		VoiceControl.startVoice.enabled =  false;
		VoiceControl.dog.enabled = true;
	}

}
