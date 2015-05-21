using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

    public KeyCode pauseKey;

    private bool paused = false;


	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(pauseKey)) {
            paused = !paused;
            Pause(paused);
        }
	}

    void Pause(bool pause) {
        Time.timeScale = pause ? 0 : 1;
    }
}
