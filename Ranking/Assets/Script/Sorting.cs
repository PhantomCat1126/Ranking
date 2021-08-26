using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;

public class Sorting : MonoBehaviour {

	public LoadScores LoadScores;
	public DDDDebug DDDDebug;
	public bool isSorting=false;
	string Move_toC_Path=@"";

	// Use this for initialization
	void OnEnable () 
	{
		Move_toC_Path=File.ReadAllText(Application.streamingAssetsPath+"/MovetoC.txt");
		File.WriteAllText(Move_toC_Path+"Scores.txt", "0");
		LoadScores.readScores = 0;
		InsertSort (LoadScores.scores_num);
		InsertSort (LoadScores.PICNameInt);
//		LoadScores.saveScores = 0;
		DDDDebug.debug_10.text="已排序完，scores_num [10]："+ LoadScores.scores_num[10];
		isSorting = true;
		LoadScores.scores_num [10] =LoadScores.readScores= 0;
		LoadScores.savePICname="";
//		LoadScores.imgT2 = null;

		for (int i = 1; i < LoadScores.PICNameInt.Length; i++) {
			LoadScores.SCORES [i].text = LoadScores.scores_num [i].ToString ();
			LoadScores.PicName [i]=LoadScores.PIC[i].name=LoadScores.PICNameInt [i].ToString ();

			Sprite ss = LoadScores.PIC [i].GetComponent<Image> ().sprite;
			//print ("1");
			for (int j =i-1; j >=0 ; j--) {
				print ("2");

				if (int.Parse(LoadScores.PIC [j].GetComponent<Image>().sprite.name) < int.Parse(ss.name)) {
					
					//print (i+"="+j);
					LoadScores.PIC [j+1].GetComponent<Image> ().sprite = LoadScores.PIC [j].GetComponent<Image> ().sprite;
					LoadScores.PIC [j].GetComponent<Image> ().sprite=ss;
				}
			}
		}
		StartCoroutine ("SetTime");
	}
		
	//插入排序，由大到小
	public static void InsertSort(int[] array)
	{
		for(int i = 1;i < array.Length;i++)
		{
			int temp = array[i];
			//大
			for(int j = i - 1;j >= 0;j--)
			{
				if(array[j]< temp)
				{
					array[j + 1] = array[j];
					array[j] = temp;
				}else
					break;
			}

		}
	}

	//氣泡排序，由大到小
	static void BubbleSort(int[] intArray) {
		int temp = 0;
		bool swapped;
		for (int i = 0; i < intArray.Length; i++)
		{
			swapped = false;
			for (int j = 0; j < intArray.Length - 1 - i; j++)
				//大
				if (intArray[j] < intArray[j + 1])
				{
					temp = intArray[j];
					intArray[j] = intArray[j + 1];
					intArray[j + 1] = temp;
					if (!swapped)
						swapped = true;
				}
			if (!swapped)
				return;
		}
	}

	IEnumerator	SetTime()
	{
		yield return new WaitForSeconds (5);
		this.gameObject.SetActive (false);
	}
		
}
