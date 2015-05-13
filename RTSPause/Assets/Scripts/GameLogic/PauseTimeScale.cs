using UnityEngine;
using System.Collections;

public class PauseTimeScale : MonoBehaviour {
    public bool isPaused { get; private set; }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            TogglePause();
        }
	}

    private void TogglePause() {
        if (Time.timeScale > 0) {
            Pause();
        } else {
            FullSpeed();
        }
        GameController.uiPauseIcon.ChangeIcon(Time.timeScale);
    }

    private void Pause() {
        Time.timeScale = 0;
    }
    private void FullSpeed() {
        Time.timeScale = 1f;
    }

}
