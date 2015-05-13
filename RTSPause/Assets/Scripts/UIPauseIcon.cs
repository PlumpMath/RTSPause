using UnityEngine;
using System.Collections;

public class UIPauseIcon : MonoBehaviour {

    public GameObject icon;
    public GameObject canvas;

    void Start() {
        canvas.SetActive(true);
    }
    public void ChangeIcon(float currentScale) {
        if (currentScale > 0) {
            icon.SetActive(false);
        } else {
            icon.SetActive(true);
        }
        
    }
}
