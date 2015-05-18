using UnityEngine;
using System.Collections;

public class SelectUnit : MonoBehaviour, IClickable {
    UnitOrder unitOrder;
	// Use this for initialization
	void Start () {
        unitOrder = GetComponent<UnitOrder>();
	}

    public void Clicked(Click button, Vector3 pos) {
        if (button == Click.Left) {
            UnitManager.instance.Selected = unitOrder;
        }
    }
}
