using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
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
