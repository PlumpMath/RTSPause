using UnityEngine;
using System.Collections;

public class UnitStats : MonoBehaviour, IUnitStats {

    void Awake() {
        GenerateBasicStats();
    }

    void GenerateBasicStats() {
        maxHealth = 100;
        speed = 5;
        accuracy = 65;
    }

    public int maxHealth {
        get;
        set;
    }

    public float speed {
        get;
        set;
    }

    public int accuracy {
        get;
        set;
    }
}
