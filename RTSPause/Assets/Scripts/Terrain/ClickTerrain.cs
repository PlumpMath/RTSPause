using UnityEngine;
using System.Collections;

public class ClickTerrain : MonoBehaviour {
    IOrderReceiver order;
    public void SetUnit(GameObject unit) {
        order = unit.GetComponent(typeof(IOrderReceiver)) as IOrderReceiver;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            FireRay();
        }
	}

    void FireRay() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            WorldPos newPos = new WorldPos(Mathf.RoundToInt(hit.point.x), 0, Mathf.RoundToInt(hit.point.z));
            order.MoveOrder(newPos);
            Test.MoveSphere(newPos.ToVector());
        }
    }
}
