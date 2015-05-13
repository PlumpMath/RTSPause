using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour, ITerrainDetails {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    public int cost {
        get { return 10000; }
    }

    public bool impassible {
        get { return true; }
    }
}
