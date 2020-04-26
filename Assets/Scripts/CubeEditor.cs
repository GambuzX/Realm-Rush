using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    private TextMesh cubeText;
    private Pathfinder pathfinder;
    Waypoint waypoint;

    // Start is called before the first frame update
    void Awake()
    {
        cubeText = GetComponentInChildren<TextMesh>();
        waypoint = GetComponent<Waypoint>();
        pathfinder = GameObject.FindObjectOfType<Pathfinder>();
    }

    // Update is called once per frame
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid() {
        int gridSize = waypoint.getGridSize();
        Vector2Int gridPos = waypoint.getGridPos();
        this.transform.position = new Vector3(
            gridPos.x * gridSize, 
            this.transform.position.y, 
            gridPos.y * gridSize);
    }

    private void UpdateLabel() {
        int gridSize = waypoint.getGridSize();
        Vector2Int gridPos = waypoint.getGridPos();
        string labelText = gridPos.x + "," + gridPos.y;
        cubeText.text = labelText;
        gameObject.name = "Cube " + labelText;
    }
}
