using UnityEngine;
using System.Collections;

public class UnitOrder : MonoBehaviour {

    private Order currentOrder;

    public void SetOrder(Order order) {
        currentOrder = order;
        Execute();
    }

    private void Execute() {
        currentOrder.Execute();
    }

    public void OrderFinished() {
        currentOrder = null;
    }
}
