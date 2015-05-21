using UnityEngine;
using System.Collections;

public class UnitOrder : MonoBehaviour {

    private Order currentOrder;
    private UnitMovement thisUnit;

    public void SetOrder(Order order) {
        currentOrder = order;
        thisUnit = GetComponent<UnitMovement>();
        Execute();
    }

    private void Execute() {
        if (currentOrder.type == "move") {
            MoveOrder moveOrder = currentOrder as MoveOrder;
            thisUnit.MoveTo(moveOrder.target);
        }
    }
}
