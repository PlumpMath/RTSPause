using UnityEngine;
using System.Collections;

public class AbilityThrowGrenade: IAbility {

    float range = 15f;
    float force = 1f;
    float sqrRange;
    Transform myUnit;
    public GameObject grenade;
    public GameObject explosion;

    public AbilityThrowGrenade(Transform myUnit, GameObject prefab) {
        sqrRange = range * range;
        this.myUnit = myUnit;
        this.grenade = prefab;
    }

    public bool Cast(Vector3 castTo) {
        if (!InRange(castTo)) return false;
        // Cast the ability
        ThrowGrenade(castTo);
        return true;
    }

    private void ThrowGrenade(Vector3 toPoint) {
        GameObject temp = MonoBehaviour.Instantiate(grenade, myUnit.position, Quaternion.identity) as GameObject;
        Rigidbody newGrenade = temp.GetComponent<Rigidbody>();
        newGrenade.GetComponent<GrenadeDetonation>().SetDestination(toPoint);

        newGrenade.useGravity = false;
    }

    public bool InRange(Vector3 castTo) {
        Vector3 diff = myUnit.position - castTo;

        return sqrRange >= diff.sqrMagnitude;
    }
}
