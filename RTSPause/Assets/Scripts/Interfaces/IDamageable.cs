using UnityEngine;
using System.Collections;

public interface IDamageable  {

    int GetHealth();
    int GetMaxHealth();
    void TakeDamage(int damage);
    void RestoreHealth(int restore);

}
