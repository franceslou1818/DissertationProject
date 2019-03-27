using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//changing scene either from the virtual museums to another or from the map scene
public class ChangeScene : MonoBehaviour, IPointerClickHandler {

	public float nextScenePositionX;
	public float nextScenePositionY;
	public float nextScenePositionZ;

	public float nextSceneRotationX;
	public float nextSceneRotationY;
	public float nextSceneRotationZ;

	public string sceneName;
	public Scene activeScene;

	PlayerScript playerScript;

	void Start() {
		playerScript = GameObject.Find("DontDestroyOnLoad").GetComponent<PlayerScript>();
	}

	public void OnPointerClick(PointerEventData pointerEventData) {
		
		activeScene = SceneManager.GetActiveScene ();

		// getting the position where the user last left off
		if (!activeScene.name.Equals( "Map") ) {
			//			print("else change scene");
			PlayerPrefs.SetFloat("positionX", nextScenePositionX);
			PlayerPrefs.SetFloat("positionY", nextScenePositionY);
			PlayerPrefs.SetFloat("positionZ", nextScenePositionZ);

			PlayerPrefs.SetFloat("rotationX", nextSceneRotationX);
			PlayerPrefs.SetFloat("rotationY", nextSceneRotationY);
			PlayerPrefs.SetFloat("rotationZ", nextSceneRotationZ);
					
		// if there is no position in PlayerPref, ge default positions. e.g. due to the fact its the first time using the app.
		} else { //if (activeScene.name.Equals( "Map") ) 


			float[] posAtNextScene = new float[3]{ 0f, 0f, 0f };
			float[] rotAtNextScene = new float[3]{ 0f, 0f, 0f };

			PlayerPrefs.SetFloat ("positionX", posAtNextScene [0]);
			PlayerPrefs.SetFloat ("positionY", posAtNextScene [1]);
			PlayerPrefs.SetFloat ("positionZ", posAtNextScene [2]);

			PlayerPrefs.SetFloat ("rotationX", rotAtNextScene [0]);
			PlayerPrefs.SetFloat ("rotationY", rotAtNextScene [1]);
			PlayerPrefs.SetFloat ("rotationZ", rotAtNextScene [2]);

		} 

		playerScript.GoToScene(sceneName);


	}





}
