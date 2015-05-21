using UnityEngine;
using System.Collections;

public class MoveOrder : Order {

    public Vector3 target { get; private set; }
    public GameObject myUnit { get; private set; }


    public MoveOrder(Vector3 target)
        : base("move") {
        this.target = target;
        this.myUnit = UnitManager.instance.Selected.gameObject;
    }

    public override void Execute() {
        myUnit.GetInterface<IUnitMovement>().MoveTo(target);
    }
}
