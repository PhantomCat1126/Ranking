using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.IO;

public class SaveScores : MonoBehaviour {

	public LoadScores LoadScores;
	public string NowTime;
	public GameObject[] PicG;
	public Texture2D[] PicT;


	private byte[] P1_bytes;
	private byte[] P2_bytes;
	private byte[] P3_bytes;

//	public Texture2D P1;
//	public string path ;

	Shader outShader;

	public DDDDebug DDDDebug;

	// Use this for initialization
	void OnEnable () {
		//获取设置当前屏幕分辩率  
		Resolution[] resolutions = Screen.resolutions;  
		//设置当前分辨率  
		Screen.SetResolution(resolutions[resolutions.Length - 1].width, resolutions[resolutions.Length - 1].height, true);  
		Screen.fullScreen = true;  //设置成全屏,  

		LoadScores.scores_num [0] = LoadScores.PICNameInt [0] = PlayerPrefs.GetInt ("NO.1");
		LoadScores.scores_num [1] = LoadScores.PICNameInt [1] = PlayerPrefs.GetInt ("NO.2");
		LoadScores.scores_num [2] = LoadScores.PICNameInt [2] = PlayerPrefs.GetInt ("NO.3");

		StartCoroutine ("PIC");
	}
	
	// Update is called once per frame
	void Update () {
		DDDDebug.debug_dataPath.text = Application.streamingAssetsPath;

//		print ( "Pic [0] width:"+PicT [0].width+"，Pic [0] height:"+PicT[0].height);

		NowTime=DateTime.Now.ToString("HHmm");
		if (NowTime == "1720") 
		{
			PlayerPrefs.SetInt ("NO.1",LoadScores.scores_num[0]);
			PlayerPrefs.SetInt ("NO.2",LoadScores.scores_num[1]);
			PlayerPrefs.SetInt ("NO.3",LoadScores.scores_num[2]);

			PicT [0] = PicG [0].GetComponent<Image> ().sprite.texture;
			P1_bytes =PicT [0].EncodeToJPG();
			File.WriteAllBytes( Application.streamingAssetsPath+"/"+LoadScores.scores_num[0].ToString()+".jpg", P1_bytes);	//圖片存到檔案裡

			PicT [1] = PicG [1].GetComponent<Image> ().sprite.texture;
			P2_bytes =PicT [1].EncodeToJPG();
			File.WriteAllBytes(Application.streamingAssetsPath+"/"+LoadScores.scores_num[1].ToString()+".jpg", P2_bytes);	//圖片存到檔案裡

			PicT [2] = PicG [2].GetComponent<Image> ().sprite.texture;
			P3_bytes =PicT [2].EncodeToJPG();
			File.WriteAllBytes(Application.streamingAssetsPath+"/"+LoadScores.scores_num[2].ToString()+".jpg", P3_bytes);	//圖片存到檔案裡


		}
	

	}

	IEnumerator	PIC ()
	{
		print ("wimg00 : "+Application.streamingAssetsPath+"/"+PlayerPrefs.GetInt ("NO.1").ToString ()+".jpg");
		WWW wimg00 = new WWW ("file://"+Application.streamingAssetsPath+"/"+PlayerPrefs.GetInt ("NO.1").ToString ()+".jpg");
		yield return wimg00;
		PicT[0] = wimg00.texture;
		LoadScores.PIC [0].GetComponent<Image> ().sprite = Sprite.Create (PicT[0], new Rect (0, 0, PicT[0].width, PicT[0].height), Vector2.zero);
		LoadScores.PIC [0].name = LoadScores.PicName [0] = PlayerPrefs.GetInt ("NO.1").ToString ();
		LoadScores.PIC [0].GetComponent<Image> ().sprite.name = LoadScores.PicName [0] = PlayerPrefs.GetInt ("NO.1").ToString ();

		WWW wimg01 = new WWW ("file://"+Application.streamingAssetsPath+"/"+PlayerPrefs.GetInt ("NO.2").ToString ()+".jpg");
		yield return wimg01;
		PicT[1] = wimg01.texture;
		LoadScores.PIC [1].GetComponent<Image> ().sprite = Sprite.Create (PicT[1], new Rect (0, 0, PicT[1].width, PicT[1].height), Vector2.zero);
		LoadScores.PIC [1].name = LoadScores.PicName [1] = PlayerPrefs.GetInt ("NO.2").ToString ();
		LoadScores.PIC [1].GetComponent<Image> ().sprite.name = LoadScores.PicName [1] = PlayerPrefs.GetInt ("NO.2").ToString ();

		WWW wimg02 = new WWW ("file://"+Application.streamingAssetsPath+"/"+PlayerPrefs.GetInt ("NO.3").ToString ()+".jpg");
		yield return wimg02;
		PicT[2] = wimg02.texture;
		LoadScores.PIC [2].GetComponent<Image> ().sprite = Sprite.Create (PicT[2], new Rect (0, 0, PicT[2].width, PicT[2].height), Vector2.zero);
		LoadScores.PIC [2].name = LoadScores.PicName [2] = PlayerPrefs.GetInt ("NO.3").ToString ();
		LoadScores.PIC [2].GetComponent<Image> ().sprite.name = LoadScores.PicName [2] = PlayerPrefs.GetInt ("NO.3").ToString ();
	}
				
}
