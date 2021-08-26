using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class DDDDebug : MonoBehaviour {

	public Text debug_10;
	public Text debug_Sorting;
	public Text debug_ImgName;
	public Text debug_TheGame;
	public Text debug_readScores;
	public Text debug_OScores;
	public Text debug_PICnum;

	public Text debug_dataPath;

	public Text[] debug_PICnumS;
	public Text[] debug_PICnumG;

	public  LoadScores LoadScores;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.P)) {
			this.GetComponent<Image> ().enabled = true;
			debug_10.color = debug_Sorting.color = debug_ImgName.color =  debug_TheGame.color = debug_readScores.color = debug_OScores.color = debug_PICnum.color = debug_dataPath.color = Color.black; 
			debug_PICnumS[0].color = debug_PICnumS[1].color = debug_PICnumS[2].color = debug_PICnumS[3].color = debug_PICnumS[4].color = debug_PICnumS[5].color = debug_PICnumS[6].color = debug_PICnumS[7].color = debug_PICnumS[8].color = Color.red; 
			debug_PICnumG[0].color = debug_PICnumG[1].color = debug_PICnumG[2].color = debug_PICnumG[3].color = debug_PICnumG[4].color = debug_PICnumG[5].color = debug_PICnumG[6].color = debug_PICnumG[7].color = debug_PICnumG[8].color = Color.yellow;
			debug_PICnumS[9].color = new Color(1,0,0,0.5f); 
			debug_PICnumG[8].color = debug_PICnumG[9].color = new Color(1,0.92f,0.016f,0.5f); 
		}

		if (Input.GetKey (KeyCode.H)) {
			this.GetComponent<Image> ().enabled = false;
			debug_10.color = debug_Sorting.color = debug_ImgName.color =  debug_TheGame.color = debug_readScores.color = debug_OScores.color = debug_PICnum.color = debug_dataPath.color = new Color(0,0,0,0);
			debug_PICnumS[0].color = debug_PICnumS[1].color = debug_PICnumS[2].color = debug_PICnumS[3].color = debug_PICnumS[4].color = debug_PICnumS[5].color = debug_PICnumS[6].color = debug_PICnumS[7].color = debug_PICnumS[8].color = new Color(0,0,0,0);
			debug_PICnumG[0].color = debug_PICnumG[1].color = debug_PICnumG[2].color = debug_PICnumG[3].color = debug_PICnumG[4].color = debug_PICnumG[5].color = debug_PICnumG[6].color = debug_PICnumG[7].color = debug_PICnumG[8].color = new Color(0,0,0,0);
			debug_PICnumS[9].color = debug_PICnumG[9].color = new Color(0,0,0,0);
		}
	}
}
