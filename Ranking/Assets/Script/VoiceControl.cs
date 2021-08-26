using UnityEngine;
using System.Collections;
using System.IO;

public class VoiceControl : MonoBehaviour {

	public AudioSource dog;
	public AudioSource startVoice;
	public AudioSource EndVoice;
	public AudioSource guide;

	string path=@"";
	string readText;

	public GameObject StartV;
	public GameObject EndV;

	// Use this for initialization
	void Start () {
		path=File.ReadAllText(Application.streamingAssetsPath+"/Path.txt");
	}
	
	// Update is called once per frame
	void Update () {
		readText = File.ReadAllText (path);
		if (readText != "") {
			EndV.SetActive (true);
			StartV.SetActive (false);
		} else {
			StartV.SetActive (true);
			EndV.SetActive (false);
		}


	}
}
