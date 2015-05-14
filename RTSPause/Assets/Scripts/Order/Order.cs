using UnityEngine;
using System.Collections;

public abstract class Order {

    public string type { get; private set; }
    public GameObject unit { get; private set; }
    public bool isComplete { get; set; }

    public Order(string type, GameObject unit) {
        this.type = type;
        this.unit = unit;
        this.isComplete = false;
    }

    public abstract void Execute();
}
