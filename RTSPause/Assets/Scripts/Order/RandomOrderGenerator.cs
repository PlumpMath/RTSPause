using UnityEngine;
using System.Collections;

public class RandomOrderGenerator : MonoBehaviour {

    public bool generateOrders = false;

	// Use this for initialization
	void Start () {
        if (generateOrders)
            Invoke("ThrowGrenadeAtRandomLocation", 5.0f);
	}

    void ThrowGrenadeAtRandomLocation() {
        Debug.Log("Order Generated");
        Vector3 randomLocation = new Vector3(Random.Range(-49, 49), 1, Random.Range(-49, 49));
        UnitManager.instance.OrderSelected(new UseAbilityOrder(new AbilityThrowGrenade(), randomLocation));
        Invoke("ThrowGrenadeAtRandomLocation", 5.0f);
    }
}
