using UnityEngine;
using System.Collections;

public interface IAbility {

    bool Cast(Vector3 castTo);
    bool InRange(Vector3 castTo);
}
