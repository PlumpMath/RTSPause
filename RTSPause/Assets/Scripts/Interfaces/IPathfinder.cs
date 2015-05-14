using UnityEngine;
using System.Collections;

public interface IPathfinder{
    //Properties
    bool isMoving { get; }
    //Methods
    bool SetGoal(WorldPos pos);
    void MoveUnit();
    int StepsAwayFromGoal();
    bool IsAtGoal();
    bool BuildPathTo(WorldPos pos); // Build the full path
    bool GetNextStep(); // Get the next step goal
}
