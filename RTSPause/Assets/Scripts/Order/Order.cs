using UnityEngine;
using System.Collections;

public abstract class Order {

    public string type { get; private set; }
    public bool isComplete { get; set; }

    public Order(string type) {
        this.type = type;
        isComplete = false;
    }

    public abstract void Execute();
}
