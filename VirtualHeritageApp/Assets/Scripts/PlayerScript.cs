using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

//namespace Tengio {
public class PlayerScript : MonoBehaviour {


	private Scene activeScene;

	public SceneLoader sceneLoader;

	public GameObject thePlayer;


	void Start() {
		

//		print ("start at scene: " + SceneManager.GetActiveScene ().name);

//		activeScene = SceneManager.GetActiveScene ();
//		sceneLoader = GameObject.Find ("Player").GetComponent<SceneLoader> ();
//		justChangedScene = true;

//		CreateButtonArray ();
		/*
		if(activeScene.name.Equals("Map") && !PlayerPrefs.HasKey("savedScene")) { // first time opened. nothing in playerpreds

			print ("if1");

			PlayerPrefs.SetString ("savedScene", "WeatherDeck");
//			PlayerPrefs.SetFloat ("positionX", default_WeatherDeck_Position[0]);
//			PlayerPrefs.SetFloat ("positionY", default_WeatherDeck_Position[1]);
//			PlayerPrefs.SetFloat ("positionZ", default_WeatherDeck_Position[2]);
//
//			PlayerPrefs.SetFloat ("rotationX", default_WeatherDeck_Rotation[0]);
//			PlayerPrefs.SetFloat ("rotationY", default_WeatherDeck_Rotation[1]);
//			PlayerPrefs.SetFloat ("rotationZ", default_WeatherDeck_Rotation[2]);
			PlayerPrefs.SetFloat ("positionX", 0f);
			PlayerPrefs.SetFloat ("positionY", 0f);
			PlayerPrefs.SetFloat ("positionZ", 0f);

			PlayerPrefs.SetFloat ("rotationX", 0f);
			PlayerPrefs.SetFloat ("rotationY", 0f);
			PlayerPrefs.SetFloat ("rotationZ", 0f);

		} else if ( !activeScene.name.Equals("Map") ) {
			print ("if2");
//			transform.position = new Vector3 (PlayerPrefs.GetFloat ("positionX"), 
//												PlayerPrefs.GetFloat ("positionY"), 
//												PlayerPrefs.GetFloat ("positionZ"));
//			transform.transform.eulerAngles = new Vector3 (PlayerPrefs.GetFloat ("rotationX"), 
//															PlayerPrefs.GetFloat ("rotationY"), 
//															PlayerPrefs.GetFloat ("rotationZ"));
			transform.position = new Vector3 (0,0,0);
			transform.transform.eulerAngles = new Vector3 (0,0,0);
		
		} 

		else { // active scene is map
			print ("if3");
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
		*/
	}




	void Update () {
		
		activeScene = SceneManager.GetActiveScene ();


		if (Gvr.Internal.ControllerUtils.AnyButton(GvrControllerButton.App)) {

			if (activeScene.name == "Map") {
				print ("update if");

				GoToScene (PlayerPrefs.GetString("savedScene", "WeatherDeck")); // load savedScene but if null, load WeatherDeck

			} else {
				print ("update else");
				PlayerPrefs.SetString ("savedScene", activeScene.name);

				PlayerPrefs.SetFloat("positionX", thePlayer.transform.position.x);
				PlayerPrefs.SetFloat("positionY", thePlayer.transform.position.y);
				PlayerPrefs.SetFloat("positionZ", thePlayer.transform.position.z);

				PlayerPrefs.SetFloat("rotationX", thePlayer.transform.eulerAngles.x);
				PlayerPrefs.SetFloat("rotationY", thePlayer.transform.eulerAngles.y);
				PlayerPrefs.SetFloat("rotationZ", thePlayer.transform.eulerAngles.z);


				GoToScene ("Map");

			}

		}
	
	}

	public void GoToScene(string sceneName) {

//		print ("sceneName: " + sceneName);
//		print ("sceneloader: " + sceneLoader);

//		sceneLoader = GameObject.Find ("Player").GetComponent<SceneLoader> ();

		sceneLoader.LoadScene(sceneName);

		if (sceneName == "Map") {
//			print ("gotoscene if Map");
			thePlayer.transform.position = new Vector3 (0f,0f,0f);
			thePlayer.transform.transform.eulerAngles = new Vector3 (0f,0f,0f);
		} else {
//			print("gotosceneElse in pp: " + PlayerPrefs.GetFloat ("positionX",0f) + ","+ 
//											PlayerPrefs.GetFloat ("positionY",0f) + ","+ 
//											PlayerPrefs.GetFloat ("positionZ",0f));
			thePlayer.transform.position = new Vector3 (PlayerPrefs.GetFloat ("positionX",0f), 
														PlayerPrefs.GetFloat ("positionY",0f), 
														PlayerPrefs.GetFloat ("positionZ",0f));
			thePlayer.transform.transform.eulerAngles = new Vector3 (PlayerPrefs.GetFloat ("rotationX",0f), 
																	PlayerPrefs.GetFloat ("rotationY",0f), 
																	PlayerPrefs.GetFloat ("rotationZ",0f));
		}

	}


	void OnApplicationQuit() {
		PlayerPrefs.DeleteAll ();
	}



}
