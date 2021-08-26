using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwitchStage : MonoBehaviour {

	public GameObject Stage_on;
	public GameObject Stage_off;
	public LoadScores LoadScores;

	public int WaitTime;

	// Use this for initialization

	void OnEnable () {
		for (int i = 0; i < LoadScores.PICNameInt.Length-1; i++) {
			LoadScores.SCORES [i].text = LoadScores.scores_num [i].ToString ();
			LoadScores.PicName [i]=LoadScores.PIC[i].name=LoadScores.PICNameInt [i].ToString ();


			//print ("1");
			for (int j =0; j < LoadScores.PicName.Length-1; j++) {
				//print ("2");

				if (LoadScores.PIC [i].GetComponent<Image>().sprite.name == LoadScores.PICNameInt [j].ToString()) {
					Sprite ss = LoadScores.PIC [i].GetComponent<Image> ().sprite;
					LoadScores.PIC [i].GetComponent<Image> ().sprite = LoadScores.PIC [j].GetComponent<Image> ().sprite;
					LoadScores.PIC [j].GetComponent<Image> ().sprite=ss;
				}
			}
		}

		StartCoroutine ("SetTime");
	}

	IEnumerator	SetTime()
	{
		yield return new WaitForSeconds (WaitTime);

		Stage_on.SetActive (true);
		Stage_off.SetActive (false);
	}
}
