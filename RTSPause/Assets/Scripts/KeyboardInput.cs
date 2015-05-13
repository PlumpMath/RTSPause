using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class KeyboardInput : MonoBehaviour, IInputReceiver {

    private List<float> axes;
	// Use this for initialization
	void Start () {
        axes = new List<float>();
        for (int i = 0; i < System.Enum.GetNames(typeof(InputAxis)).Length; i++) {
            axes.Add(0f);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public float GetAxis(InputAxis axis) {
        return GetAxis((int)axis);
    }
    private float GetAxis(int axis) {
        return axes[axis];
    }
}
