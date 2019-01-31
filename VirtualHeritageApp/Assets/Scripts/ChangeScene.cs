using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

		if (!activeScene.name.Equals( "Map") ) {
			//			print("else change scene");
			PlayerPrefs.SetFloat("positionX", nextScenePositionX);
			PlayerPrefs.SetFloat("positionY", nextScenePositionY);
			PlayerPrefs.SetFloat("positionZ", nextScenePositionZ);

			PlayerPrefs.SetFloat("rotationX", nextSceneRotationX);
			PlayerPrefs.SetFloat("rotationY", nextSceneRotationY);
			PlayerPrefs.SetFloat("rotationZ", nextSceneRotationZ);

//			SceneManager.LoadScene(sceneName);

		} else { //if (activeScene.name.Equals( "Map") ) 

			//defaults 0f
			float[] posAtNextScene = new float[3]{ 0f, 0f, 0f };
			float[] rotAtNextScene = new float[3]{ 0f, 0f, 0f };

			PlayerPrefs.SetFloat ("positionX", posAtNextScene [0]);
			PlayerPrefs.SetFloat ("positionY", posAtNextScene [1]);
			PlayerPrefs.SetFloat ("positionZ", posAtNextScene [2]);

			PlayerPrefs.SetFloat ("rotationX", rotAtNextScene [0]);
			PlayerPrefs.SetFloat ("rotationY", rotAtNextScene [1]);
			PlayerPrefs.SetFloat ("rotationZ", rotAtNextScene [2]);

//			SceneManager.LoadScene (sceneName);

		} 

		playerScript.GoToScene(sceneName);


	}





}
