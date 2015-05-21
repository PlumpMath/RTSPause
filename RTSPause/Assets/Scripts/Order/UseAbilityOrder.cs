using UnityEngine;
using System.Collections;

public class UseAbilityOrder : Order {

    private IAbility ability;
    private Vector3 castTo;

    public UseAbilityOrder(IAbility ability, Vector3 castTo):base("useAbility") {
        this.ability = ability;
        this.castTo = castTo;
    }

    public override void Execute() {
        bool success = ability.Cast(castTo);
    }
}
