using UnityEngine;
using System.Collections;

public class PrefabAssigner : MonoBehaviour {

    public GameObject grenade;

	// Use this for initialization
	void Start () {
        AbilityThrowGrenade.AssignPrefabs(grenade);
	}
}
