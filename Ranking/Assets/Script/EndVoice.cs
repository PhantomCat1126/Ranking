using UnityEngine;
using System.Collections;

public class EndVoice : MonoBehaviour {
	
	public VoiceControl VoiceControl;

	// Use this for initialization
	void  OnEnable () 
	{
		StartCoroutine ("EndGuideVoiceTime");
	}

	IEnumerator	EndGuideVoiceTime ()
	{
		VoiceControl.dog.enabled =false; 
		VoiceControl.EndVoice.enabled = true;
		yield return new WaitForSeconds (8);
		VoiceControl.EndVoice.enabled =false; 
		VoiceControl.guide.enabled = true;
		yield return new WaitForSeconds (15);
		VoiceControl.guide.enabled = false; 
	}
}
