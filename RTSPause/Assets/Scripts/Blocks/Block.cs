using UnityEngine;
using System.Collections;

/// <summary>
/// Holds information about a current terrain space
/// </summary>
public abstract class Block {

    bool isSolid;
    public GameObject template;
    protected GameObject instance;

    public Block(bool solid) {
        isSolid = solid;
    }

    public virtual bool IsSolid() {
        return isSolid;
    }

    public virtual void Instantiate(WorldPos pos) {
        return;
    }
    public virtual void Delete() {
        return;
    }
}
