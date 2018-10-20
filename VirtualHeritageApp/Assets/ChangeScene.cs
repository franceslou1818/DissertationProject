using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	//	public void GotoScene() {
	//		//print ("test print");
	//		Debug.Log ("My method was called!");
	//		SceneManager.LoadScene ("00-FallingCoconut");
	//	}

	// or use this instead of above
	public void GotoScene(string sceneName) {
		//print ("test print");
		Debug.Log ("My method was called!");
		SceneManager.LoadScene (sceneName);
	}
}
