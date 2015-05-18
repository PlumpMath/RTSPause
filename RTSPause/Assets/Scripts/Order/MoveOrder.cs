using UnityEngine;
using System.Collections;

public class MoveOrder : Order {

    public Vector3 target { get; private set; }

    public MoveOrder(Vector3 target):base("move") {
        this.target = target;
    }

    public override void Execute() {
        throw new System.NotImplementedException();
    }
}
