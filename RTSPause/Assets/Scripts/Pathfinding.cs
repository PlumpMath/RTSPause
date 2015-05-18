using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;

public class Pathfinding : MonoBehaviour {
	

	PathRequestManager requestManager;
	Grid grid;

	void Awake() {
		requestManager = GetComponent<PathRequestManager>();
		grid = GetComponent<Grid>();
	}
	

	public void StartFindPath(Vector3 startPos, Vector3 targetPos) {
		StartCoroutine(FindPath(startPos,targetPos));
	}

	IEnumerator FindPath(Vector3 startPos, Vector3 targetPos) {

		Stopwatch sw = new Stopwatch();
		sw.Start();

		Vector3[] waypoints = new Vector3[0];
		bool pathSuccess = false;

		Node startNode = grid.NodeFromWorldPoint(startPos);
		Node targetNode = grid.NodeFromWorldPoint(targetPos);

		if (startNode.walkable && targetNode.walkable) {
			Heap<Node> openSet = new Heap<Node>(grid.MaxSize);
			HashSet<Node> closedSet = new HashSet<Node>();
			openSet.Add(startNode);

			while (openSet.Count > 0) {
				Node currentNode = openSet.RemoveFirst();
				closedSet.Add(currentNode);

				if (currentNode == targetNode) { // If target found
					sw.Stop();
					print ("Path found: " + sw.ElapsedMilliseconds + " ms");
					pathSuccess = true;
					break;
				}

                List<int> BadXDirs = new List<int>();
                List<int> BadYDirs = new List<int>();
                
				foreach (Node neighbour in grid.GetNeighbours(currentNode)) {
                    if( closedSet.Contains(neighbour)){
                        continue;
                    }
					if (!neighbour.walkable) {
                        // If the unwalkable neighbour is a cardinal direction, block off the two diagonals on it's side as well
                        int[] diff = currentNode.NeighbourDir(neighbour);

                        // If either number = 0, then it's a cardinal direction
                        if (diff[0] == 0) { // If X=0 then it's a y direction
                            BadYDirs.Add(diff[1]);
                        }
                        if(diff[1] == 0){
                            BadXDirs.Add(diff[0]);
                        }
						continue;
					}
                    int[] neighbourDiff = currentNode.NeighbourDir(neighbour);
                    if (BadXDirs.Contains(neighbourDiff[0]) || BadYDirs.Contains(neighbourDiff[1])) {
                        continue;
                    }

					int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
					if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour)) {
						neighbour.gCost = newMovementCostToNeighbour;
						neighbour.hCost = GetDistance(neighbour, targetNode);
						neighbour.parent = currentNode;

                        if (!openSet.Contains(neighbour)) {
                            openSet.Add(neighbour);
                            openSet.UpdateItem(neighbour);
                        }
					}
				}
			}
		}
		yield return null;
		if (pathSuccess) {
			waypoints = RetracePath(startNode,targetNode);
		}
		requestManager.FinishedProcessingPath(waypoints,pathSuccess);

	}

	Vector3[] RetracePath(Node startNode, Node endNode) {
		List<Node> path = new List<Node>();
		Node currentNode = endNode;

		while (currentNode != startNode) {
			path.Add(currentNode);
			currentNode = currentNode.parent;
		}
		Vector3[] waypoints = SimplifyPath(path);
        //Vector3[] waypoints = VectorfyPath(path);
		Array.Reverse(waypoints);
		return waypoints;

	}

	Vector3[] SimplifyPath(List<Node> path) {
		List<Vector3> waypoints = new List<Vector3>();
		Vector2 directionOld = Vector2.zero;

        //waypoints.Add(path[0].worldPosition);
        //for (int i = 1; i < path.Count; i ++) {
        //    Vector2 directionNew = new Vector2(path[i-1].gridX - path[i].gridX,path[i-1].gridY - path[i].gridY);
        //    if (directionNew != directionOld) {
        //        waypoints.Add(path[i].worldPosition);
        //    }
        //    directionOld = directionNew;
        //}
        for (int i = 0; i < path.Count-1; i++) {
            Vector2 directionNew = new Vector2(path[i].gridX - path[i+1].gridX, path[i].gridY - path[i+1].gridY);
            if (directionNew != directionOld) {
                waypoints.Add(path[i].worldPosition);
            }
            directionOld = directionNew;
        }
		return waypoints.ToArray();
	}
    Vector3[] VectorfyPath(List<Node> path) {
        List<Vector3> waypoints = new List<Vector3>();
        foreach (Node point in path) {
            waypoints.Add(point.worldPosition);
        }
        return waypoints.ToArray();
    }

	int GetDistance(Node nodeA, Node nodeB) {
		int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
		int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

		if (dstX > dstY)
			return 14*dstY + 10* (dstX-dstY);
		return 14*dstX + 10 * (dstY-dstX);
	}


}
