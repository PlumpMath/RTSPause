using UnityEngine;
using System.Collections;


/// <summary>
/// Displays the current fps.
/// Doesn't work with changing timescales.
/// </summary>
public class FPSDisplay : MonoBehaviour {

    public float updateRate = 4.0f;
    public bool isDisplayFPS = true;

    int frameCount = 0;
    float nextUpdate = 0.0f;
    float fps = 0.0f;

    // Use this for initialization
    void Start() {
        nextUpdate = Time.time;
    }

    // Update is called once per frame
    void Update() {
        CountFrame();
    }

    void OnGUI() {
        if (!isDisplayFPS) return;

        if (fps > 59) {
            GUI.contentColor = Color.white;
        } else if (fps > 29) {
            GUI.contentColor = Color.yellow;
        } else {
            GUI.contentColor = Color.red;
        }
        GUI.Box(new Rect(Screen.width - 100, 40, 100, 20), "FPS: " + fps.ToString());
    }

    private void CountFrame() {
        frameCount++;
        if (Time.time > nextUpdate) {
            nextUpdate += 1.0f / updateRate;
            fps = frameCount * updateRate;
            frameCount = 0;
        }
    }
}
