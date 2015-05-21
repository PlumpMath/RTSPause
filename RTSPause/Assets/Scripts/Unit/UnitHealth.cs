using UnityEngine;
using System.Collections;

public class UnitHealth : MonoBehaviour, IDamageable {

    IUnitStats stats;
    int health;

	// Use this for initialization
	void Start () {
        stats = gameObject.GetInterface<IUnitStats>();
        health = stats.maxHealth;
	}
	
    public int GetHealth() {
        return health;
    }

    public int GetMaxHealth() {
        return stats.maxHealth;
    }

    public void TakeDamage(int damage) {
        health -= damage;
        BoundHealth();
    }

    public void RestoreHealth(int restore) {
        health += restore;
        BoundHealth();
    }

    void BoundHealth() {
        if (health > stats.maxHealth) {
            health = stats.maxHealth;
        } else if (health < 0) {
            health = 0;
            Die();
        }
    }

    void Die() {
        // TODO: Do nothing for the moment
    }
}
