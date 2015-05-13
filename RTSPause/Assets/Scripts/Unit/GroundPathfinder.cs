using UnityEngine;
using System.Collections;

public class GroundPathfinder : MonoBehaviour, IPathfinder {

    Vector3 goalPos;
    float speed = 0.02f; //TODO: Should get this from unit stats

    private int STEP_COST = 1;
    public int[,] PathGrid;

    private int x_grid;
    private int y_grid;

    private int x_goal;
    private int y_goal;

    private int lastXNav;
    private int lastYNav;

    private int numOfCellsChecked = 0;
    private int numOfCellsChanged = 0;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetGoal(int x, int y) {
        throw new System.NotImplementedException();
    }

    public void Step() {
        throw new System.NotImplementedException();
    }

    public int StepsAwayFromGoal() {
        throw new System.NotImplementedException();
    }

    public bool BuildPathTo(int x, int y) {
        throw new System.NotImplementedException();
    }

    public bool GetGoal() {
        throw new System.NotImplementedException();
    }
}
