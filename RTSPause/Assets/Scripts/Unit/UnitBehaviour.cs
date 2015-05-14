using UnityEngine;
using System.Collections;

public class UnitBehaviour : MonoBehaviour, IOrderReceiver {

    private Order currentOrder;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(currentOrder == null) return;
        if (currentOrder.isComplete) {
            currentOrder = null;
            return;
        }
        currentOrder.Execute();
	}

    public void MoveOrder(WorldPos pos) {
        currentOrder = new MoveOrder(gameObject, pos);
    }

    public void AttackOrder(IDamageable unit) {
        throw new System.NotImplementedException();
    }
}
