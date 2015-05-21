using UnityEngine;
using System.Collections;

public class GrenadeDetonation : MonoBehaviour {

    public GameObject explosion;

    private Vector3 destination;
    private float speed = 10;
    private float radius = 5;
    private int damage = 100;

	// Update is called once per frame
	void Update () {
        MoveGrenade();
        if (destination == transform.position) {
            Detonate();
        }
	}

    private void Detonate() {
        // Sphere to find objects hit
        Collider[] hits = Physics.OverlapSphere(transform.position, radius);
        // Damage them all
        foreach (Collider hit in hits) {
            IDamageable damageable = hit.gameObject.GetInterface<IDamageable>();
            if (damageable != null) {
                damageable.TakeDamage(damage);
            }
        }
        // Spawn cosmetic explosion
        Instantiate(explosion, transform.position, Quaternion.Euler(new Vector3(270, 0, 0)));
        
        // Delete self
        Destroy(gameObject);
    }

    private void MoveGrenade() {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }

    public void SetDestination(Vector3 castTo) {
        destination = castTo;
    }
}
