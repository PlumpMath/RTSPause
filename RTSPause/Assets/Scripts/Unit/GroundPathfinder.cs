using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroundPathfinder : MonoBehaviour, IPathfinder {

    Vector3 stepGoalPos;
    float speed = 1f; //TODO: Should get this from unit stats
    public bool isMoving { get; private set; }

    private int STEP_COST = 1;
    public Dictionary<WorldPos, int> PathGrid;

    private WorldPos grid;
    private WorldPos goal;
    private WorldPos lastNav;

    private int numOfCellsChecked = 0;
    private int numOfCellsChanged = 0;

	// Use this for initialization
	void Start () {
        PathGrid = new Dictionary<WorldPos, int>();
        UpdatePathGrid();
        stepGoalPos = transform.position;
	}

    void UpdatePathGrid() {
        PathGrid.Clear();
        PathGrid = new Dictionary<WorldPos, int>(GameController.world.terrainGrid);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    WorldPos MyGridPos() {
        return new WorldPos(
            Mathf.RoundToInt(transform.position.x),
            Mathf.RoundToInt(transform.position.y),
            Mathf.RoundToInt(transform.position.z)
            );
    }

    public bool SetGoal(WorldPos pos) {
        goal = pos;
        bool canDo = BuildPathTo(pos);
        if (!canDo) {
            Debug.Log("Can't set goal properly.");
        }
        return canDo;
    }
    #region BuildPath
    public bool BuildPathTo(WorldPos pos) {
        numOfCellsChanged = 1;
        numOfCellsChecked = 0;

        List<WorldPos> openCells = new List<WorldPos>();
        UpdatePathGrid();

        PathGrid[pos] = STEP_COST;

        AddOpenCells(pos, ref openCells);
        
        bool foundMe = false;


        while ((openCells.Count > 0) && (!foundMe)) {

            WorldPos checkCell = openCells[0];
            openCells.RemoveAt(0);

            numOfCellsChecked++;
            if (!PathGrid.ContainsKey(checkCell)) {
                numOfCellsChanged++;
                //if (Test.isDebug) Debug.Log("Pathgrid didn't contain: " + checkCell.ToString());
                PathGrid.Add(checkCell, CostCell(ref openCells, checkCell));
            } else {
                //if (Test.isDebug) Debug.Log("Pathgrid contains: " + checkCell.ToString());
            }
            if (checkCell == grid) foundMe = true;
        }

        if (Test.isDebug) Debug.Log("Cells Checked: "+numOfCellsChecked.ToString());
        if (Test.isDebug) Debug.Log("Cells Changed: " + numOfCellsChanged.ToString());

        return foundMe;
    }

    private int CostCell(ref List<WorldPos> openCells, WorldPos pos) {
        int bestCost = int.MaxValue;
        WorldPos newPos;

        newPos = new WorldPos(pos.x - 1, pos.y, pos.z);
        GetBestCost(ref openCells, ref bestCost, newPos);

        newPos = new WorldPos(pos.x + 1, pos.y, pos.z);
        GetBestCost(ref openCells, ref bestCost, newPos);

        newPos = new WorldPos(pos.x, pos.y, pos.z - 1);
        GetBestCost(ref openCells, ref bestCost, newPos);

        newPos = new WorldPos(pos.x, pos.y, pos.z + 1);
        GetBestCost(ref openCells, ref bestCost, newPos);

        return (bestCost + STEP_COST);
    }

    private void GetBestCost(ref List<WorldPos> openCells, ref int bestCost, WorldPos pos) {
        if (PathGrid.ContainsKey(pos)) {
            if (PathGrid[pos] < bestCost) {
                bestCost = PathGrid[pos];
            }
        } else {
            openCells.Add(pos);
        }
    }

    private void AddOpenCells(WorldPos pos, ref List<WorldPos> openCells) {
        if (!PathGrid.ContainsKey(new WorldPos(pos.x - 1, pos.y, pos.z))) {
            openCells.Add(new WorldPos(pos.x - 1, pos.y, pos.z));
        }
        if (!PathGrid.ContainsKey(new WorldPos(pos.x + 1, pos.y, pos.z))) {
            openCells.Add(new WorldPos(pos.x + 1, pos.y, pos.z));
        }
        if (!PathGrid.ContainsKey(new WorldPos(pos.x, pos.y, pos.z - 1))) {
            openCells.Add(new WorldPos(pos.x, pos.y, pos.z - 1));
        }
        if (!PathGrid.ContainsKey(new WorldPos(pos.x, pos.y, pos.z + 1))) {
            openCells.Add(new WorldPos(pos.x, pos.y, pos.z + 1));
        }
    }
    #endregion

    public void MoveUnit() {
        Vector3 dir = stepGoalPos - transform.position;
        Vector3 path = dir.normalized * speed * Time.deltaTime;
        Vector3 move;
        // Pick smaller,
        // path or normalised path * speed * deltaTime
        if (dir.sqrMagnitude > path.sqrMagnitude) {
            move = path;
        } else {
            move = dir;
        }
        transform.Translate(move);

        if (transform.position == stepGoalPos) {
            isMoving = false;
        }

    }

    public int StepsAwayFromGoal() {
        return (PathGrid[grid] - 1);
    }

    public bool IsAtGoal() {
        return (this.StepsAwayFromGoal() == 0);
    }

    public bool GetNextStep() {
        isMoving = true;
        bool foundGoal = true;
        grid = MyGridPos();
        WorldPos nav = grid;
        WorldPos newPos;

        if (Test.isDebug) Debug.Log("My position is: " + PathGrid[grid].ToString());

        // Set Nav cardinal
        newPos = new WorldPos(grid.x - 1, grid.y, grid.z);
        LowerCostCardinal(newPos, ref nav);
        newPos = new WorldPos(grid.x + 1, grid.y, grid.z);
        LowerCostCardinal(newPos, ref nav);
        newPos = new WorldPos(grid.x, grid.y, grid.z - 1);
        LowerCostCardinal(newPos, ref nav);
        newPos = new WorldPos(grid.x, grid.y, grid.z + 1);
        LowerCostCardinal(newPos, ref nav);

        //Set nav diagonal
        newPos = new WorldPos(grid.x - 1, grid.y, grid.z - 1);
        LowerCostDiagonal(newPos, ref nav);
        newPos = new WorldPos(grid.x + 1, grid.y, grid.z - 1);
        LowerCostDiagonal(newPos, ref nav);
        newPos = new WorldPos(grid.x - 1, grid.y, grid.z + 1);
        LowerCostDiagonal(newPos, ref nav);
        newPos = new WorldPos(grid.x + 1, grid.y, grid.z + 1);
        LowerCostDiagonal(newPos, ref nav);

        if((goal != grid) && (lastNav == nav)){
            foundGoal = BuildPathTo(goal);
        } else {
            lastNav = nav;
            stepGoalPos = new Vector3(nav.x, nav.y, nav.z);
            isMoving = true;
        }

        return foundGoal;
    }

    // Is lower cost and pathable in cardinal direction ( Up, down, left, right)
    void LowerCostCardinal(WorldPos pos, ref WorldPos nav) {
        if (PathGrid.ContainsKey(pos)) {
            if (Test.isDebug) Debug.Log("Position checked is: " + PathGrid[pos].ToString());
            if ((PathGrid[pos] < PathGrid[grid]) && (PathGrid[pos] > 0)) {
                if (!GameController.world.terrainGrid.ContainsKey(pos)) {
                    nav = pos;
                }
            }
        }
    }
    // Is lower cost and pathable in diagonal direction
    // Does more checks for obstructions in a corner
    // Not allowed to cut corners
    void LowerCostDiagonal(WorldPos pos, ref WorldPos nav) {
        if (PathGrid.ContainsKey(pos)) {
            if ((PathGrid[pos] < PathGrid[grid]) &&
                (PathGrid[pos] > 0) &&
                (PathGrid.ContainsKey(new WorldPos(grid.x, grid.y, pos.z))) &&
                (PathGrid.ContainsKey(new WorldPos(pos.x, grid.y, grid.z)))) 
            {
                if (!GameController.world.terrainGrid.ContainsKey(pos)) {
                    nav = pos;
                }
            }
        }
    }
}
