using UnityEngine;
using System.Collections;
using System.IO;

public class Voice : MonoBehaviour {

	public AudioSource dog;
	public AudioSource startVoice;
	public AudioSource EndVoice;
	public AudioSource guide;

	string path=@"";
	string Move_toC_Path=@"";
	string readText;

	// Use this for initialization
	void Start () {
		path=File.ReadAllText(Application.streamingAssetsPath+"/Path.txt");
		//Move_toC_Path=File.ReadAllText(Application.streamingAssetsPath+"/MovetoC.txt");
	}
	
	// Update is called once per frame
	void Update () {
		readText = File.ReadAllText (path);
		print (readText);
		if (readText != "") {
			///////////////////////////////////////////////////////////////////////////////////////////////////////
			//int readScores = int.Parse (readText);
			//File.WriteAllText(Move_toC_Path+"Scores.txt",  (readScores * 1000).ToString());
			//File.WriteAllText(Application.streamingAssetsPath+"/Scores.txt",  (readScores * 1000).ToString());
			///////////////////////////////////////////////////////////////////////////////////////////////////////
			//StartCoroutine ("BGT");

			////////////////////////////////////////////////
			//dog.enabled =startVoice.enabled =  false;
			//EndVoice.enabled = true;
			///////////////////////////////////////////////
			StartCoroutine ("EndGuideVoiceTime");

		} else {
			//EndVoice.enabled =guide.enabled = false; 

			////////////////////////////////////////////
			//EndVoice.enabled = false;
			//startVoice.enabled = true;
			//dog.enabled = true;
			////////////////////////////////////////////

			StartCoroutine ("VoiceTime");

		}
	}

	IEnumerator	VoiceTime ()
	{
		startVoice.enabled = true;
		yield return new WaitForSeconds (15);
		startVoice.enabled =  false;
		dog.enabled = true;
	}

	IEnumerator	EndGuideVoiceTime ()
	{
		dog.enabled =false; 
		EndVoice.enabled = true;
		yield return new WaitForSeconds (8);
		EndVoice.enabled =false; 
		guide.enabled = true;
		yield return new WaitForSeconds (15);
		guide.enabled = false; 
	}
	IEnumerator	BGT ()
	{
		guide.enabled = false; 
		EndVoice.enabled = true;
		yield return new WaitForSeconds (8);
		guide.enabled = true;
		yield return new WaitForSeconds (15);
		guide.enabled = false; 
		yield return new WaitForSeconds (37);

		startVoice.enabled = true;
		yield return new WaitForSeconds (15);
		dog.enabled = true;


		yield return new WaitForSeconds (120);
		dog.enabled =false; 
	}
}
