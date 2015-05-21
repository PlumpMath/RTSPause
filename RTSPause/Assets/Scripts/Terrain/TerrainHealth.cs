using UnityEngine;
using System.Collections;

public class TerrainHealth : MonoBehaviour, IDamageable {

    [SerializeField]
    private int maxHealth = 100;
    private int health;
    

	// Use this for initialization
	void Start () {
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int GetHealth() {
        return health;
    }

    public int GetMaxHealth() {
        return maxHealth;
    }

    public void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
        // Tell the path grid to update
        Debug.Log("Code called.");

    }

    public void RestoreHealth(int restore) {
        // Do nothing, you can't fix terrain
    }
}
