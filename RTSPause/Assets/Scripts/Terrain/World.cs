using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Holds the data about the entire map
/// </summary>
public class World : MonoBehaviour {

    public Dictionary<WorldPos, int> terrainGrid;
    public GameObject rock;

    const int IMPASSIBLE = -1;

	// Use this for initialization
	void Awake () {
        terrainGrid = new Dictionary<WorldPos, int>();
        //GenerateTerrain();
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
        terrainGrid[temp] = IMPASSIBLE;
    }
}
