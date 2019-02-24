using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour {

	public GameObject[] btnfactsNfigures = new GameObject[2];

	public GameObject[] btnWeatherDeckMap = new GameObject[2];
	public GameObject[] btnTweenDeckMap = new GameObject[2];
	public GameObject[] btnCargoHoldMap = new GameObject[2];
	public GameObject[] btnLowerDeckMap = new GameObject[2];

	public GameObject[] btnWeatherDeckScene = new GameObject[3];
	public GameObject[] btnMainDeckhouseScene = new GameObject[3];
	public GameObject[] btnOfficersDeckhouseScene = new GameObject[3];

	public List<GameObject[]> allButtons = new List<GameObject[]> ();

	public GameObject[] popUpInfos = new GameObject[13];



	void Start () {

		CreateButtonArray ();

		DeckListButtons buttonScript = btnWeatherDeckMap[0].GetComponent<DeckListButtons>();

		string savedButtonSelected = PlayerPrefs.GetString ("selectBtnSelected", "Btn-factsNfigures");
		foreach (GameObject[] objArr in allButtons) {
			if (savedButtonSelected.Equals(objArr[0].name) ) {
				buttonScript.SetObjsActive( objArr[0] );
				buttonScript.swapImgToArrow( objArr[0] );
				break;
			}
		}
	}
	
	void CreateButtonArray (){

		allButtons.Add(btnfactsNfigures);

		allButtons.Add(btnWeatherDeckMap);
		allButtons.Add(btnTweenDeckMap);
		allButtons.Add(btnCargoHoldMap);
		allButtons.Add(btnLowerDeckMap);

		allButtons.Add(btnWeatherDeckScene);
		allButtons.Add(btnMainDeckhouseScene);
		allButtons.Add(btnOfficersDeckhouseScene);
	}
}
