using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMaster : MonoBehaviour {


    private SceneLoader sceneLoader;

    private FadeScreen fadeScreen;

	Scene activeScene;

    private void Update() {

		activeScene = SceneManager.GetActiveScene ();
		if (activeScene.name.Equals("S1") && Gvr.Internal.ControllerUtils.AnyButton(GvrControllerButton.App)) {
			sceneLoader.LoadScene("S2");
		}
		else if (activeScene.name.Equals("S2") && Gvr.Internal.ControllerUtils.AnyButton(GvrControllerButton.App)) {
			sceneLoader.LoadScene("S1");
		}

        if (Input.GetKeyDown(KeyCode.O)) {
            fadeScreen.FadeOut();
        }
        if (Input.GetKeyDown(KeyCode.I)) {
            fadeScreen.FadeIn();
        }
    }
}

