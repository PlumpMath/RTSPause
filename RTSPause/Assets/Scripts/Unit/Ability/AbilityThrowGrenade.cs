using UnityEngine;
using System.Collections;

public class AbilityThrowGrenade: IAbility {

    float range = 100f;
    float sqrRange;
    Transform myUnit;
    static GameObject grenade;

    public static void AssignPrefabs(GameObject prefab) {
        AbilityThrowGrenade.grenade = prefab;
    }

    public AbilityThrowGrenade() {
        sqrRange = range * range;
        this.myUnit = UnitManager.instance.Selected.transform;
    }

    public bool Cast(Vector3 castTo) {
        if (!InRange(castTo)) {
            return false;
        }
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
