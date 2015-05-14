using UnityEngine;
using System.Collections;

public struct WorldPos {
    public int x;
    public int y;
    public int z;

    public WorldPos(int x, int y, int z) {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public Vector3 ToVector() {
        return new Vector3(x, y, z);
    }

    public static bool operator ==(WorldPos a, WorldPos b) {
        return ((a.x == b.x) && (a.y == b.y) && (a.z == b.z));
    }
    public static bool operator !=(WorldPos a, WorldPos b) {
        return !(a == b);
    }
    // This'll get the warnings to shut up
    public override bool Equals(object obj) {
        return base.Equals(obj);
    }
    public override int GetHashCode() {
        return base.GetHashCode();
    }

    public override string ToString() {
        return x.ToString() + ", " + y.ToString() + ", " + z.ToString();
    }
}
