using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class testImgS : MonoBehaviour {

	public int[] PICNameInt;
	public string[] PicName;

	public LoadScores LoadScores;

	// Use this for initialization
	void Start () {
		
		////////////////////////  test 交換圖片  //////////////////////////////////////////////////////////////
		//Sprite s = LoadScores.PIC [8].GetComponent<Image> ().sprite;										 //
		//LoadScores.PIC [8].GetComponent<Image> ().sprite= LoadScores.PIC [4].GetComponent<Image> ().sprite;//
		//LoadScores.PIC [4].GetComponent<Image> ().sprite = s;												 //
		///////////////////////////////////////////////////////////////////////////////////////////////////////

		for (int i = 0; i < PicName.Length; i++) {
//			PicName [i] = LoadScores.PIC [i].GetComponent<Image>().sprite.name;
			PICNameInt [i] = int.Parse (PicName [i].ToString ());
		}

		InsertSort (PICNameInt);

//		for (int i = 0; i < PICNameInt.Length; i++) {
			//print ("1");
//			for (int j =0; j < PicName.Length; j++) {
				//print ("2");
//				if (LoadScores.PIC [i].GetComponent<Image>().sprite.name == PICNameInt [j].ToString()) {
					//print (i+"="+j);
//					Sprite ss = LoadScores.PIC [i].GetComponent<Image> ().sprite;
//					LoadScores.PIC [i].GetComponent<Image> ().sprite = LoadScores.PIC [j].GetComponent<Image> ().sprite;
//					LoadScores.PIC [j].GetComponent<Image> ().sprite=ss;

//				}
//			}
//		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
}
