using UnityEngine;
using System.Collections;

public interface IPathfinder{
    //Methods
    void SetGoal(int x, int y);
    void Step();
    int StepsAwayFromGoal();
    bool BuildPathTo(int x, int y); // Build the full path
    bool GetGoal(); // Get the next step goal
}
