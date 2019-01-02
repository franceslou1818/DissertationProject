using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class PlayerScript : MonoBehaviour {

	public float[] default_WeatherDeck_Position = new float[3]{ 1f, 4.15f, 70.3f };
	public float[] default_MainDeckhouse_Position = new float[3]{ -3.62f, 2.13f, 0f };
	public float[] default_OfficersDeckhouse_Position = new float[3]{ -8.17f, 1.34f, 7.56f };

	public GameObject[] btnWeatherDeckMap = new GameObject[2];
	public GameObject[] btnTweenDeckMap = new GameObject[2];
	public GameObject[] btnCargoHoldMap = new GameObject[2];
	public GameObject[] btnLowerDeckMap = new GameObject[2];

	public GameObject[] btnWeatherDeckScene = new GameObject[3];
	public GameObject[] btnMainDeckhouseScene = new GameObject[3];
	public GameObject[] btnOfficersDeckhouseScene = new GameObject[3];

	public List<GameObject[]> allButtons = new List<GameObject[]> ();

	public GameObject[] popUpInfos = new GameObject[13];

	public Scene activeScene;


	void Start() {
		
		activeScene = SceneManager.GetActiveScene ();

		CreateButtonArray ();

		print ("start");

		if(activeScene.name.Equals("Map") && !PlayerPrefs.HasKey("savedScene")) { // first time opened. nothing in playerpreds

			PlayerPrefs.SetString ("savedScene", "WeatherDeck");
			PlayerPrefs.SetFloat ("positionX", default_WeatherDeck_Position[0]);
			PlayerPrefs.SetFloat ("positionY", default_WeatherDeck_Position[1]);
			PlayerPrefs.SetFloat ("positionZ", default_WeatherDeck_Position[2]);

//			PlayerPrefs.SetString ("selectBtnSelected", "Btn-WeatherDeckScene");
//			print("GameObjects " + Resources.FindObjectsOfTypeAll(typeof(GameObject)));
		

		} else if ( !activeScene.name.Equals("Map") ) {
			transform.position = new Vector3 (PlayerPrefs.GetFloat ("positionX"), PlayerPrefs.GetFloat ("positionY"), PlayerPrefs.GetFloat ("positionZ"));
//			transform.eulerAngles = new Vector3 (PlayerPrefs.GetFloat ("rotationX"), PlayerPrefs.GetFloat ("rotationY"), PlayerPrefs.GetFloat ("rotationZ"));
		
		} else { // active scene is map

			DeckListButtons buttonScript = btnWeatherDeckMap[0].GetComponent<DeckListButtons>();

			string savedButtonSelected = PlayerPrefs.GetString ("selectBtnSelected", "Btn-WeatherDeckScene");

			foreach (GameObject[] objArr in allButtons) {
				if (savedButtonSelected.Equals(objArr[0].name) ) {
					buttonScript.SetObjsActive( objArr[0] );
					buttonScript.swapImgToArrow( objArr[0] );
					break;
				}
			}
		}
	}


	void Update () {
		/*
		 * 	`GvrControllerInput.AppButton' is obsolete: 
		 * `Replaced by GvrControllerInputDevice.GetButton(GvrControllerButton.App).'
		*/

//		GvrControllerButton buttons = new GvrControllerButton();
//		GvrControllerInputDevice btns = new GvrControllerInputDevice ();


		if (GvrControllerInput.AppButton) { // if app button clicked
			
//		if (GvrControllerInputDevice.GetButton(GvrControllerButton.App)) { 
//		if (btns.GetButton(GvrControllerButton.App)) { 

			if (activeScene.name == "Map") {
				//Resume ();
				SceneManager.LoadScene ( PlayerPrefs.GetString("savedScene") ); // load savedScene but if null, load WeatherDeck
			
			} else {
				//Pause ();
				PlayerPrefs.SetString ("savedScene", activeScene.name);

				PlayerPrefs.SetFloat("positionX", transform.position.x);
				PlayerPrefs.SetFloat("positionY", transform.position.y);
				PlayerPrefs.SetFloat("positionZ", transform.position.z);

				//		PlayerPrefs.SetFloat("rotationX", transform.rotation.x);
				//		PlayerPrefs.SetFloat("rotationY", transform.rotation.y);
				//		PlayerPrefs.SetFloat("rotationZ", transform.rotation.z);

				SceneManager.LoadScene ( "Map" );
			}

		}
	
	}

	void CreateButtonArray (){
		allButtons.Add(btnWeatherDeckMap);
		allButtons.Add(btnTweenDeckMap);
		allButtons.Add(btnCargoHoldMap);
		allButtons.Add(btnLowerDeckMap);

		allButtons.Add(btnWeatherDeckScene);
		allButtons.Add(btnMainDeckhouseScene);
		allButtons.Add(btnOfficersDeckhouseScene);

	}

	void OnApplicationQuit() {
		PlayerPrefs.DeleteAll ();
	}


}
