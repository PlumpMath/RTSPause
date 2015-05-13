using UnityEngine;
using System.Collections;

/// <summary>
/// Randomly places terrain
/// </summary>
public class DistributeTerrain {

    public float rockFrequency = 0.5f;

    public void CreateTerrain(int length, int height, Chunk chunk) {
        Block[,] blocks = new Block[length, height];

        for (int i = 0; i < length; i++) {
            for (int j = 0; j < height; j++) {
                blocks[i,j] = GenerateBlock();
            }
        }
        chunk.SetTerrain(blocks);
    }

    private Block GenerateBlock() {
        if (Random.Range(0, 1) < rockFrequency) {
            Debug.Log("Rock Created");
            return new BlockRock();
        }
        return new BlockAir();
    }

}
