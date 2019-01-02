using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour, IPointerClickHandler {

//	public float[] default_CargoModel_Position = new float[3]{ 1f, 4.15f, 70.3f };
//	public float[] default_FrontDeckhouse_Position = new float[3]{ -3.62f, 2.13f, 0f };
//	public float[] default_OfficersDeckhouse_Position = new float[3]{ -8.17f, 1.34f, 7.56f };


	public float nextScenePositionX;
	public float nextScenePositionY;
	public float nextScenePositionZ;

	public float nextSceneRotationX;
	public float nextSceneRotationY;
	public float nextSceneRotationZ;

	public string sceneName;
	public Scene activeScene;

	GameObject thePlayer;
	PlayerScript playerScript;

	void Start() {
		thePlayer = GameObject.Find("Player");
		playerScript = thePlayer.GetComponent<PlayerScript>();
	}

	public void OnPointerClick(PointerEventData pointerEventData) {
		
//		PlayerPrefs.SetString ("savedScene", sceneName);


		activeScene = SceneManager.GetActiveScene ();

		if (!activeScene.name.Equals( "Map") ) {
			//			print("else change scene");
			PlayerPrefs.SetFloat("positionX", nextScenePositionX);
			PlayerPrefs.SetFloat("positionY", nextScenePositionY);
			PlayerPrefs.SetFloat("positionZ", nextScenePositionZ);

			PlayerPrefs.SetFloat("rotationX", nextSceneRotationX);
			PlayerPrefs.SetFloat("rotationY", nextSceneRotationY);
			PlayerPrefs.SetFloat("rotationZ", nextSceneRotationZ);

			SceneManager.LoadScene(sceneName);

		} else { //if (activeScene.name.Equals( "Map") ) {
			
			float[] posAtNextScene = new float[3];
			float[] rotAtNextScene = new float[3];
			if (sceneName.Equals ("WeatherDeck")) {
				posAtNextScene = playerScript.default_WeatherDeck_Position;
				rotAtNextScene = playerScript.default_WeatherDeck_Rotation;
			}
			else if (sceneName.Equals ("MainDeckhouse")) {
				posAtNextScene = playerScript.default_MainDeckhouse_Position;
				rotAtNextScene = playerScript.default_MainDeckhouse_Rotation;

			}
			else if (sceneName.Equals ("OfficersDeckhouse")) {
				posAtNextScene = playerScript.default_OfficersDeckhouse_Position;
				rotAtNextScene = playerScript.default_OfficersDeckhouse_Rotation;
			}

			PlayerPrefs.SetFloat ("positionX", posAtNextScene [0]);
			PlayerPrefs.SetFloat ("positionY", posAtNextScene [1]);
			PlayerPrefs.SetFloat ("positionZ", posAtNextScene [2]);

			PlayerPrefs.SetFloat ("rotationX", rotAtNextScene [0]);
			PlayerPrefs.SetFloat ("rotationY", rotAtNextScene [1]);
			PlayerPrefs.SetFloat ("rotationZ", rotAtNextScene [2]);

			SceneManager.LoadScene (sceneName);

		} 


	}



}
