using UnityEngine;
using System.Collections;
/// <summary>
/// Something that receives orders
/// </summary>
public interface IOrderReceiver {
    void MoveOrder(WorldPos pos);
    void AttackOrder(IDamageable unit); // Need to add unit stuff here
}
