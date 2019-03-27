using UnityEngine;

// when changing scenes, we must not destroy the objects that are constant throughout. e.g. the audio
public class DontDestroyOnNewScene : MonoBehaviour {

    public static DontDestroyOnNewScene Instance;

    void Awake() {
        if (Instance == null) {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        } 
	else if (Instance != this) {
            Destroy(gameObject);
        }
    }
}

