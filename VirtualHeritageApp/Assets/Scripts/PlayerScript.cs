using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


//behaviour of the player throughout their experience.
public class PlayerScript : MonoBehaviour {

	private Scene activeScene;


	public SceneLoader sceneLoader;

	public GameObject thePlayer;

	private string prevScene = "Boot";

	void Start() {

	}

	void Update () {
		
		activeScene = SceneManager.GetActiveScene ();

		// when the app button is clicked, scene is changed.
		if ( Gvr.Internal.ControllerUtils.AnyButton(GvrControllerButton.App) && activeScene.name != prevScene) {
			
			// if the player is in the map scene, get the scene thep player selected to go to, which is in the PlayerPrefs
			if (activeScene.name == "Map") {

				GoToScene (PlayerPrefs.GetString("savedScene", "WeatherDeck")); // load savedScene but if null, load WeatherDeck
			
			// if the player is in the virtual museums, save the current position in the current scene then go to the map scene. 
			} else {
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

	// change scene.
	public void GoToScene(string sceneName) {

		prevScene = activeScene.name;
		sceneLoader.LoadScene(sceneName);


		if (sceneName == "Map") {
			thePlayer.transform.position = new Vector3 (0f,0f,0f);
			thePlayer.transform.transform.eulerAngles = new Vector3 (0f,180f,0f);
		} else {
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
