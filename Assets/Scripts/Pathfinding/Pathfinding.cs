using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinding : MonoBehaviour {

    public Transform pathfinder, target;

    private Grid grid;

    void Awake() {
        grid = GetComponent<Grid>();
    }

    void Update() {
        FindPath(pathfinder.position, target.position);
    }

    void FindPath(Vector3 startPos, Vector3 targetPos) {
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        if (!targetNode.walkable)
            return;

        List<Node> queue = new List<Node>();
        List<Node> visited = new List<Node>();
        queue.Add(startNode);

        while (queue.Count > 0) {
            Node node = queue[0];
            for (int i = 1; i < queue.Count; i++) {
                if (queue[i].fCost < node.fCost || queue[i].fCost == node.fCost) {
                    if (queue[i].hCost < node.hCost)
                        node = queue[i];
                }
            }

            queue.Remove(node);
            visited.Add(node);

            if (node == targetNode) {
                RetracePath(startNode, targetNode);
                return;
            }

            foreach (Node neighbour in grid.GetNeighbours(node)) {
                if (!neighbour.walkable || visited.Contains(neighbour)) {
                    continue;
                }

                int newCostToNeighbour = node.gCost + GetDistance(node, neighbour);
                if (newCostToNeighbour < neighbour.gCost || !queue.Contains(neighbour)) {
                    neighbour.gCost = newCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, targetNode);
                    neighbour.parent = node;

                    if (!queue.Contains(neighbour))
                        queue.Add(neighbour);
                }
            }
        }
    }

    void RetracePath(Node startNode, Node endNode) {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode) {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }

        path.Reverse();
        grid.path = path;

    }

    int GetDistance(Node nodeA, Node nodeB) {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (dstX > dstY)
            return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }
}