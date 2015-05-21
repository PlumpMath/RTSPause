using UnityEngine;
using System.Collections;

public class GrenadeDetonation : MonoBehaviour {

    private Vector3 destination;
    private float speed = 3;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        MoveGrenade();
        if (destination == transform.position) {
            Detonate();
        }
	}

    private void Detonate() {
        // Sphere to find objects hit
        // Damage them all
        // Spawn cosmetic explosion
        // Delete self
    }

    private void MoveGrenade() {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }

    public void SetDestination(Vector3 castTo) {
        destination = castTo;
    }
}
