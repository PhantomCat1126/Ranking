using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class TimeControl : MonoBehaviour {

	public LoadScores LoadScores;


	// Use this for initialization
	void Start () 
	{
		string[] files = System.IO.Directory.GetFileSystemEntries(Application.dataPath+"/Pictures/","*.jpg");
		for (int i = 0; i < files.Length; i++) {
			print (files [i]);
		}
		//Save();
		Load();
		print ("現在時間："+DateTime.Now);
		print ("現在小時："+DateTime.Now.Hour);

	}


	// Update is called once per frame
	void Update () 
	{
		//if (DateTime.Now.Hour >= 15) {
			//Save();
		//}
	}

	public void Save () 
	{
		PlayerPrefs.SetInt("scores_num[0]", LoadScores.scores_num[0]);
		PlayerPrefs.SetInt("scores_num[1]", LoadScores.scores_num[1]);
		PlayerPrefs.SetInt("scores_num[2]", LoadScores.scores_num[2]);
		PlayerPrefs.SetInt("scores_num[3]", LoadScores.scores_num[3]);
		PlayerPrefs.SetInt("scores_num[4]", LoadScores.scores_num[4]);
		PlayerPrefs.SetInt("scores_num[5]", LoadScores.scores_num[5]);
		PlayerPrefs.SetInt("scores_num[6]", LoadScores.scores_num[6]);
		PlayerPrefs.SetInt("scores_num[7]", LoadScores.scores_num[7]);
		PlayerPrefs.SetInt("scores_num[8]", LoadScores.scores_num[8]);
		PlayerPrefs.SetInt("scores_num[9]", LoadScores.scores_num[9]);

		PlayerPrefs.SetString("Key02", "Hellow");
		PlayerPrefs.SetFloat("key03", 5.5f);
	}

	public void Load () 
	{
		int iInt0 = PlayerPrefs.GetInt("scores_num[0]");
		int iInt1 = PlayerPrefs.GetInt("scores_num[1]");
		int iInt2 = PlayerPrefs.GetInt("scores_num[2]");
		int iInt3 = PlayerPrefs.GetInt("scores_num[3]");
		int iInt4 = PlayerPrefs.GetInt("scores_num[4]");
		int iInt5 = PlayerPrefs.GetInt("scores_num[5]");
		int iInt6 = PlayerPrefs.GetInt("scores_num[6]");
		int iInt7 = PlayerPrefs.GetInt("scores_num[7]");
		int iInt8 = PlayerPrefs.GetInt("scores_num[8]");
		int iInt9 = PlayerPrefs.GetInt("scores_num[9]");

		string sString = PlayerPrefs.GetString("Key02");
		float fNum = PlayerPrefs.GetFloat("Key03");

		print("scores_num[]: " +  iInt0+ "，" + iInt1 + "，" +iInt2 + "，" + iInt3 +"，" + iInt4 +"，" + iInt5 +"，" + iInt6+"，" + iInt7 +"，" +iInt8 + "，" + iInt9);
		print("sString: " + sString + ", fNum: " + fNum.ToString());
	}
}
