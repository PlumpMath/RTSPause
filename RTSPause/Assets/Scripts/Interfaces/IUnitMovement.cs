using UnityEngine;
using System.Collections;

public interface IUnitMovement {

    void MoveTo(Vector3 target);
    void OnPathFound(Vector3[] newPath, bool pathSuccessful);

}
