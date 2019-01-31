using UnityEngine;
using UnityEngine.SceneManagement;

//namespace Tengio {
	public class GameMaster : MonoBehaviour {

//        [SerializeField]
        private SceneLoader sceneLoader;

//        [SerializeField]
        private FadeScreen fadeScreen;

		Scene activeScene;

        private void Update() {
//			if (Input.GetKeyDown(KeyCode.A) || Gvr.Internal.ControllerUtils.AnyButton(GvrControllerButton.App)) {
//				print ("S1");
//                sceneLoader.LoadScene("S1");
//            }
//			if (Input.GetKeyDown(KeyCode.B) || Gvr.Internal.ControllerUtils.AnyButton(GvrControllerButton.App)) {
//				print ("S2");
//                sceneLoader.LoadScene("S2");
//            }
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
//}
