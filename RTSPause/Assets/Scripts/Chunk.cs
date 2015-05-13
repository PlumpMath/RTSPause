using UnityEngine;
using System.Collections;

public struct WorldPos{
    public int x;
    public int y;

    public WorldPos(int x, int y) {
        this.x = x;
        this.y = y;
    }
}
/// <summary>
/// Holds information about the current chunk/Map
/// </summary>
public class Chunk : MonoBehaviour {

    int size = 10;
    public Block[,] blocks;

    void Start() {
        blocks = new Block[size, size];
    }

    public void SetTerrain(Block[,] blocksIN) {
        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++) {
                SetBlock(new WorldPos(i, j), blocksIN[i, j]);
            }
        }
    }

    void SetBlock(WorldPos pos, Block block) {
        blocks[pos.x, pos.y] = block;
        block.Instantiate(pos);
    }
}
