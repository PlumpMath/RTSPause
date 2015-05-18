using UnityEngine;
using System.Collections;

public class ClickTerrain : MonoBehaviour, IClickable {

    public void Clicked(Click button, Vector3 pos) {
        if (button == Click.Right) {
            UnitManager.instance.OrderSelected(new MoveOrder(pos));
        }
    }
}
