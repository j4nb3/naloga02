using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinding : MonoBehaviour {

    public Transform pathfinder, target;
    public Maze maze;

    private Grid grid;
    private Node oldTargetNode;

    void Awake() {
        grid = GetComponent<Grid>();
    }

    void Start() {

    }

    void Update() {

    }

    public List<Node> FindPath(Vector3 startPos, Vector3 targetPos) {
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        if (!targetNode.walkable)
            return null;

        Heap<Node> heap = new Heap<Node>(grid.MaxSize);
        List<Node> visited = new List<Node>();
        heap.Add(startNode);

        while (heap.Count > 0) {
            Node node = heap.RemoveFirst();
            visited.Add(node);

            if (node == targetNode) {
                return RetracePath(startNode, targetNode);
            }

            foreach (Node neighbour in grid.GetNeighbours(node)) {
                if (!neighbour.walkable || visited.Contains(neighbour)) {
                    continue;
                }

                int newCostToNeighbour = node.gCost + GetDistance(node, neighbour);
                if (newCostToNeighbour < neighbour.gCost || !heap.Contains(neighbour)) {
                    neighbour.gCost = newCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, targetNode);
                    neighbour.parent = node;

                    if (!heap.Contains(neighbour))
                        heap.Add(neighbour);
                    else {
                        heap.UpdateItem(neighbour);
                    }
                }
            }
        }

        return null;
    }

    List<Node> RetracePath(Node startNode, Node endNode) {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode) {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }

        path.Reverse();
        grid.path = path;

        return path;

    }

    int GetDistance(Node nodeA, Node nodeB) {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (dstX > dstY)
            return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }
}