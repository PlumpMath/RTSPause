using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    public bool debug;
    public static bool isDebug;

    public GameObject unitTemplate;
    public GameObject sphereTemplate;
    public ClickTerrain terrain;
    GameObject unit;
    static Transform sphere;
    IOrderReceiver orderReceiver;
	// Use this for initialization
	void Start () {
        unit = Instantiate(unitTemplate, Vector3.zero, Quaternion.identity) as GameObject;
        GameObject temp = Instantiate(sphereTemplate, new Vector3(0, -10, 0), Quaternion.identity) as GameObject;
        sphere = temp.transform;
        orderReceiver = unit.GetComponent(typeof(IOrderReceiver)) as IOrderReceiver;
        terrain.SetUnit(unit);
        isDebug = debug;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F1)) {
            WorldPos newPos = new WorldPos(Random.Range(-49, 50), 0, Random.Range(-49, 50));
            orderReceiver.MoveOrder(newPos);
            MoveSphere(newPos.ToVector());
        }
	}

    public static void MoveSphere(Vector3 pos) {
        sphere.position = pos;
    }
}
