using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public void OnMouseDown() {
		Debug.Log ("OnMouseDown() in ChangeScene.cs was called!");
		SceneManager.LoadScene("FrontDeckhouse");
	}

//	public void GotoScene(string sceneName) {
//		print ("test print");
//		Debug.Log ("My go to scene method was called!");
//		SceneManager.LoadScene (sceneName);
//	}
}
