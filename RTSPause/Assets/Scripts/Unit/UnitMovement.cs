﻿using UnityEngine;
using System.Collections;

public class UnitMovement : MonoBehaviour, IUnitMovement {


	Vector3[] path;
	int targetIndex;

    IUnitStats stats;

    void Start() {
        stats = gameObject.GetInterface<IUnitStats>();
    }

    public void MoveTo(Vector3 target) {
        PathRequestManager.RequestPath(transform.position, target, OnPathFound);
    }

	public void OnPathFound(Vector3[] newPath, bool pathSuccessful) {
		if (pathSuccessful) {
            targetIndex = 0;
			path = newPath;
			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}

	IEnumerator FollowPath() {
		Vector3 currentWaypoint = path[0];

		while (true) {
			if (transform.position == currentWaypoint) {
				targetIndex ++;
				if (targetIndex >= path.Length) {
					break;
				}
				currentWaypoint = path[targetIndex];
			}

			transform.position = Vector3.MoveTowards(transform.position,currentWaypoint, stats.speed * Time.deltaTime);
			yield return null;

		}
        // Finished!
        gameObject.GetComponent<UnitOrder>().OrderFinished();
	}

	public void OnDrawGizmos() {
		if (path != null) {
			for (int i = targetIndex; i < path.Length; i ++) {
				Gizmos.color = Color.black;
				Gizmos.DrawCube(path[i], Vector3.one);

				if (i == targetIndex) {
					Gizmos.DrawLine(transform.position, path[i]);
				}
				else {
					Gizmos.DrawLine(path[i-1],path[i]);
				}
			}
		}
	}
}
