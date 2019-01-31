using UnityEngine;

//namespace Tengio {
    public class DontDestroyOnNewScene : MonoBehaviour {

        public static DontDestroyOnNewScene Instance;


        void Awake() {
            if (Instance == null) {
//				print ("dont destroy");
                DontDestroyOnLoad(gameObject);
                Instance = this;
            } 
		else if (Instance != this) {
//				print ("destroy");
                Destroy(gameObject);
            }
        }
    }
//}
