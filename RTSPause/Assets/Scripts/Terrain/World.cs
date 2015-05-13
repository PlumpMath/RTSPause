using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Holds the data about the entire map
/// </summary>
public class World : MonoBehaviour {

    public Dictionary<WorldPos, ITerrainDetails> terrainGrid;
    public GameObject rock;

	// Use this for initialization
	void Start () {
        terrainGrid = new Dictionary<WorldPos, ITerrainDetails>();
        GenerateTerrain();
	}

    void GenerateTerrain() {
        float rockFrequency = 0.5f; // 0.05f

        for (int i = 0; i < 1000; i++) {
            if (Random.Range(0f, 1f) <= rockFrequency) {
                PlaceRock();
            }
        }
    }

    void PlaceRock() {
        bool placed = false;
        WorldPos temp = new WorldPos(0,0,0);
        while(!placed){
            temp = new WorldPos(Random.Range(-49, 50), 0, Random.Range(-49, 50));
            if (!terrainGrid.ContainsKey(temp)) {
                placed = true;
            }
        }
        
        Instantiate(rock, temp.ToVector(), Quaternion.identity);
        
    }
}
