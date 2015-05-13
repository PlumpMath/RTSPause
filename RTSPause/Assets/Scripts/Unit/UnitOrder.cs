using UnityEngine;
using System.Collections;

public class UnitOrder : MonoBehaviour, IOrderReceiver {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MoveOrder(WorldPos pos) {
        throw new System.NotImplementedException();
    }

    public void AttackOrder(IDamageable unit) {
        throw new System.NotImplementedException();
    }
}
