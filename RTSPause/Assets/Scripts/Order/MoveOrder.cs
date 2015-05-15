using UnityEngine;
using System.Collections;

public class MoveOrder : Order {

    public WorldPos goalPos { get; set; }

    private IPathfinder pathfinder;

    public MoveOrder(GameObject unit, WorldPos pos)
        : base("move", unit) {

        //goalPos = pos;
        //pathfinder = unit.GetComponent(typeof(IPathfinder)) as IPathfinder;

        //if (!pathfinder.SetGoal(pos)) {
        //    isComplete = true; // Can't do it, throw it away
        //}

    }

    public override void Execute() {
    //    if (pathfinder.isMoving) {
    //        pathfinder.MoveUnit();
    //    }else if (pathfinder.IsAtGoal()) {
    //        if (Test.isDebug) Debug.Log("Finished Move!");
    //        this.isComplete = true;
    //    } else {
    //        if (Test.isDebug) Debug.Log("Get Next Step");
    //        pathfinder.GetNextStep();
    //    }
    }

}
