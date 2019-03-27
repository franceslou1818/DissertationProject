using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// behaviour of the canvases in the map scene.
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


	// array of all the buttons in the map scene are populated every visit to the map scene
	void Start () {

		CreateButtonArray ();

		DeckListButtons buttonScript = btnWeatherDeckMap[0].GetComponent<DeckListButtons>();

		// checking playerprefs what information is shown last time. if there isnt any then button of 
		// factsNfigures is shown. this is the default.
		string savedButtonSelected = PlayerPrefs.GetString ("selectBtnSelected", "Btn-factsNfigures");
		foreach (GameObject[] objArr in allButtons) {
			if (savedButtonSelected.Equals(objArr[0].name) ) {
				buttonScript.SetObjsActive( objArr[0] );
				buttonScript.swapImgToArrow( objArr[0] );
				break;
			}
		}
	}

	// populating the button array
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
