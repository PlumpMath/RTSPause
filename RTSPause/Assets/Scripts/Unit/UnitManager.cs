using UnityEngine;
using System.Collections;

public class UnitManager : MonoBehaviour {
    private UnitOrder selected;
    public UnitOrder Selected {
        get {
            return selected;
        }
        set {
            selected = value;
            if (selected != null) {
                selectionRing.SetParent(selected.transform);
                selectionRing.localPosition = Vector3.zero;
            } else {
                selectionRing.position = new Vector3(0, -10, 0);
            }
        }
    }
    public Transform selectionRing;

    public static UnitManager instance;

    void Awake() {
        instance = this;
        Selected = null;
    }

    public void OrderSelected(Order order) {
        if (Selected == null) return;

        Selected.SetOrder(order);
    }
}
