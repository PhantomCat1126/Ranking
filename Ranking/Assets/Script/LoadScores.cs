using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class LoadScores : MonoBehaviour {

	//資料路徑
	string path=@"";
	string Move_toC_Path=@"";
	string ImgNamePath=@"";
	string ImgPath=@"";

	//判斷現在是否有分數和照片
	public bool ishaveScores;				//確認是否有分數
	public bool ishaveImg;					//確認是否有照片
	//	public bool isTakePhotoB;				

	//匯入照片
	public bool isPICTime;					//判斷IEnumerator(匯入圖片)是否執行完成
	public Texture2D imgT2;					// 從外部拖拉自己喜歡的圖片進來

	string O_readText;						//存入txt裡的原始分數
	string ImgName;							//儲存照片名字

	//儲存分數&照片
	public int saveScores;					//存入原始分數加乘後的分數
	public int Snum_saveScores;
	public GameObject savePIC; 
	public string savePICname;

	//分數
	public Text[] SCORES;					//文字物件
	public int[] scores_num=new int[11];	//要排序的int

	public string readText;
	public int readScores;					//轉換string分數

	public int saveScoresI;
	public int I;							//照片位置
	public bool isSaveI;

	//圖片
	public GameObject[] PIC;
	public int[] PICNameInt;
	public string[] PicName;
	int numS = 0;							//計算文字Update跑的次數??
	public int numP = 0;							//計算圖片Update跑的次數??

	public DDDDebug DDDDebug;
	public GameObject Sorting;

	bool isTakingPhoto;
	string readyTakePhoto;

	int SortingI = 0;	
	// Use this for initialization
	void OnEnable () 
	{
		//Path：內容為C槽Ander的分數txt檔，等於「原始分數」。讀取Path.txt裡面的路徑，確認分數路徑是否存在
		path=File.ReadAllText(Application.streamingAssetsPath+"/Path.txt");//print ("Scores path："+path+"，"+File.Exists (path));
		//Move_toC_Path：內容為Z槽文件的路徑。目的是要把分數移動到Z槽的文件
		Move_toC_Path=File.ReadAllText(Application.streamingAssetsPath+"/MovetoC.txt");//print ("Public path："+Move_toC_Path+"，"+File.Exists (Move_toC_Path));

		//ImgNamePath：內容為Z槽文件的圖片名稱txt檔，等於「圖片檔名」。目的是存入片名稱txt檔內的圖片檔名
		ImgNamePath = File.ReadAllText (Application.streamingAssetsPath + "/ImgNamePath.txt");//print ("Img Name Path：" + ImgNamePath + "，" + File.Exists (ImgNamePath));
		//ImgPath：內容為Z槽的圖片資料夾。目的是去抓裡面的圖片
		ImgPath = File.ReadAllText (Application.streamingAssetsPath + "/ImgPath.txt");//print ("Img Path：" + ImgPath + ImgName + "，" + File.Exists (ImgPath + ImgName));	

		I=10;

		for(int i=0;i<PicName.Length-1;i++){
			SCORES [i].text = scores_num [i].ToString ();
			PicName [i] = PIC [i].GetComponent<Image>().sprite.name;
			PIC [i].GetComponent<Image> ().name = PicName [i];
			PICNameInt [i] = int.Parse (PicName [i].ToString ());
			for (int j = 0; j < PicName.Length - 2; j++) {
				if (PIC [i].GetComponent<Image> ().sprite.name == PICNameInt [j].ToString ()) {
					Sprite ss = PIC [i].GetComponent<Image> ().sprite;
					PIC [i].GetComponent<Image> ().sprite = PIC [j].GetComponent<Image> ().sprite;
					PIC [j].GetComponent<Image> ().sprite = ss;
				}
			}
		}
	}

	
	// Update is called once per frame
	void Update () 
	{
		DDDDebug.debug_Sorting.text = "Sorting : "+ Sorting.active.ToString ();

		//ImgName是照片的名字
		ImgName = File.ReadAllText (ImgNamePath);
		savePICname=ImgName;
		//持續偵測是否有照片&&路徑是存在的，如果有照片的話，就開始匯入照片
		if (ImgName != ""&&File.Exists (ImgPath + ImgName) ) {
			numP++;
			ishaveImg=true;
			savePIC.name = savePICname;

			DDDDebug.debug_readScores.text = "有照片，遊戲分數："+readScores;
			DDDDebug.debug_ImgName.text = "照片檔案名：" + ImgName;
			DDDDebug.debug_PICnum.text = "圖片名稱：" + savePICname;
		}else {
			numP = 0;
			ishaveImg=false;

			DDDDebug.debug_readScores.text = "無照片，遊戲分數："+readScores;
			DDDDebug.debug_ImgName.text = "照片檔案名：暫無照片";
		}

		//現在在拍照
		readyTakePhoto = File.ReadAllText (Move_toC_Path + "readyTakePhoto.txt");
		if (readyTakePhoto != "" && File.Exists (Move_toC_Path + "readyTakePhoto.txt")) {
			isTakingPhoto =false;
		}else
			isTakingPhoto = true;


		//如果有照片，且還沒匯入照片的話，就匯入照片
		if (ishaveImg==true && isPICTime==false)
		{
			StartCoroutine ("PICTime");
		}
	
		//持續偵測是否有分數，如果txt內部是空值，則目前正在進行遊戲
		O_readText = File.ReadAllText (path);
		if (O_readText != "") {
			saveScores= int.Parse (O_readText);//print ("readScores:" + readScores * 1000);

			//把分數轉到共用資料夾
			File.WriteAllText(Move_toC_Path+"Scores.txt",  (saveScores * 1000).ToString());
			//表示遊戲結束
			File.WriteAllText(Move_toC_Path+"TheGame.txt","ucJ4");

			DDDDebug.debug_OScores.text = "抓到隻數："+saveScores;
			DDDDebug.debug_TheGame.text = "遊戲是否開始?ucJ4";
		} else {
			//File.WriteAllText(Move_toC_Path+"Scores.txt", "0");
			File.WriteAllText(Move_toC_Path+"Scores.txt", O_readText);
			File.WriteAllText(Move_toC_Path+"TheGame.txt","");
			saveScores = 0;

			if ( saveScoresI == saveScores && ishaveImg == true && isTakingPhoto == false) {
				File.WriteAllText(ImgNamePath,"");
				ishaveImg = isPICTime = ishaveImg = false;

			}
			DDDDebug.debug_OScores.text = "抓到隻數："+saveScores;
			DDDDebug.debug_TheGame.text = "遊戲是否開始?Y";
		}

		//轉錄分數
		readText = File.ReadAllText (Move_toC_Path+"Scores.txt");
		//如果轉錄的分數不等於空值
		if (readText !="") {
			readScores =int.Parse (readText);//print ("readScores:" + readScores * 1000);
			ishaveScores = true;
			numS++;

			DDDDebug.debug_10.text = "scores_num [10]：" + scores_num [10];
		} else {
			File.WriteAllText(Move_toC_Path+"Scores.txt", "");
			ishaveScores = false;
			numS = 0;

			DDDDebug.debug_10.text = "待排序的分數，scores_num [10]：" + scores_num [10];
		}

		//目前正在進行遊戲&且&scores_num [10]不為0
		if (ishaveScores == true && numS <2) {
			Snum_saveScores = readScores;
			scores_num [10] = saveScoresI= Snum_saveScores;
//			Sorting.SetActive (true);

			DDDDebug.debug_10.text = "待排序的分數，scores_num [10]：" + scores_num [10];
		} else {			
			DDDDebug.debug_10.text = "遊戲結束，待排序的分數scores_num [10]：" + scores_num [10];
		}
//		print ("saveScores:"+saveScores);
			
		if (saveScores < 1 && SortingI <= 1 && Snum_saveScores == scores_num [10] && Snum_saveScores == saveScoresI && Snum_saveScores != 0 && saveScoresI > 0 && PIC [I].GetComponent<Image> ().sprite.name != "0") {
			SortingI++;
			if (SortingI <= 1) {
				Sorting.SetActive (true);
			
			}
		}

		for (int i = 0; i < scores_num.Length - 1; i++) {
			//顯示在文字上
			SCORES [i].text = scores_num [i].ToString ();
			//換圖片
			PICNameInt [i] = int.Parse (PicName [i].ToString ());

			//如果儲存的數值=排序後的數值，然後大於0
			if (saveScoresI > 0) {	
				Sorting.SetActive (true);
				for (int j = 0; j < scores_num.Length; j++) {
					if (saveScoresI == scores_num [i]) {
						I = i;
						isSaveI = true;
//					} else
//						I = 10;
//						isSaveI  =false;
					
					}

					if (isSaveI == true && isTakingPhoto == false) {
						Sorting.SetActive (true);
						if (isPICTime == true) {
							PIC [I].GetComponent<Image> ().sprite = Sprite.Create (savePIC.GetComponent<Image> ().sprite.texture, new Rect (0, 0, imgT2.width, imgT2.height), Vector2.zero);
							PIC [I].name = PIC [I].GetComponent<Image> ().sprite.name = saveScoresI.ToString ();
							ImgName =savePICname= "";
							File.WriteAllText (ImgNamePath, "");
							
							ishaveScores = isSaveI = ishaveScores = isPICTime = false;
//						I = 10;

							Snum_saveScores = scores_num [10] = saveScoresI = 0;

							File.WriteAllText (Move_toC_Path + "Scores.txt", "0");
							SortingI = 0;
						}
						DDDDebug.debug_PICnum.text = "圖片名稱：" + savePICname;
						DDDDebug.debug_10.text = "排序完成，待排序的分數scores_num [10]：" + scores_num [10];
					}//else
					//	Sorting.SetActive (false);
				}//else
				//I =10;
			} else {
				File.WriteAllText (ImgNamePath, "");
				ImgName =savePICname= "";
				ishaveImg = isPICTime = false;
			}
		}
			
		for(int i=0;i<PicName.Length-1;i++){
			DDDDebug.debug_PICnumS [i].text =PIC [i].GetComponent<Image> ().sprite.name;
			DDDDebug.debug_PICnumG [i].text =PIC [i].name;
		}

	}
		
	IEnumerator	PICTime ()
	{
		WWW wimg = new WWW ("file://" + ImgPath + ImgName);
		yield return wimg;

		imgT2 = wimg.texture;

		Sprite S = Sprite.Create (imgT2, new Rect (0, 0, imgT2.width, imgT2.height), Vector2.zero);
		S.name=saveScoresI.ToString();
		//把照片儲存起來
		savePIC.GetComponent<Image> ().sprite = S;
		//savePIC.name =savePICname;

		isPICTime=true;

	}

}
