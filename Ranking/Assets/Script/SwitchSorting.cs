using UnityEngine;
using System.Collections;

public class SwitchSorting : MonoBehaviour {

	public GameObject Sorting_on;
	public GameObject Sorting_off;

	public int WaitTime;

	void OnEnable () 
	{
		StartCoroutine ("SetTime");
	}
	// Use this for initialization

	IEnumerator	SetTime()
	{
		yield return new WaitForSeconds (WaitTime);

		//print (1);
		yield return new WaitForSeconds (1);
		//print (2);
		yield return new WaitForSeconds (1);
		//print (3);
		yield return new WaitForSeconds (1);
		//print (4);
		yield return new WaitForSeconds (1);
		//print (5);
		yield return new WaitForSeconds (1);
		print (this.gameObject.name+"...END，已排序完成");

		Sorting_on.SetActive (true);
		Sorting_off.SetActive (false);
	}

}

