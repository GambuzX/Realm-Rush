using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;

    private List<Waypoint> path = new List<Waypoint>();

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    private bool Pathfind() {
        ResetWaypoints();

        queue.Enqueue(startWaypoint);
        while(queue.Count > 0 && isRunning) {
            Waypoint curr = queue.Dequeue();
            curr.isExplored = true;

            if (curr == endWaypoint) {
                isRunning = false;
                return true;
            }

            foreach(Vector2Int dir in directions) {
                Vector2Int nextCoords = curr.getGridPos() + dir;
                if (!grid.ContainsKey(nextCoords)) continue;

                Waypoint neighbour = grid[nextCoords];
                if(!neighbour.isExplored && !queue.Contains(neighbour)) {
                    queue.Enqueue(neighbour);
                    neighbour.exploredFrom = curr;
                }
            }
        }
        return false;
    }

    private void BuildPath() {
        Waypoint curr = endWaypoint;
        while(curr != null) {
            path.Add(curr);
            curr = curr.exploredFrom;
        }
        path.Reverse();
    }

    public List<Waypoint> GetPath() {
        LoadBlocks();
        ColorStartAndEnd();

        bool foundPath = Pathfind();
        if(!foundPath) return new List<Waypoint>();
        
        BuildPath();
        return path;
    }

    private void ResetWaypoints() {
        foreach(KeyValuePair<Vector2Int, Waypoint> p in grid) {
            p.Value.Reset();
        }
    }
    
    private void ColorStartAndEnd() {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks() {

        Object[] waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints) {
            if (grid.ContainsKey(waypoint.getGridPos())) {
                Debug.LogWarning("Skipping overlapping block " + waypoint);
                continue;
            }
        
            grid.Add(waypoint.getGridPos(), waypoint);
            waypoint.SetTopColor(Color.black);
        }
    }
}
