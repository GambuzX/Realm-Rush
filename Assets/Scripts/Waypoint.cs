using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored;
    public Waypoint exploredFrom;

    public bool isPlaceable = true;

    const int gridSize = 10;
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getGridSize() {
        return gridSize;
    }

    public Vector2Int getGridPos() {
        return new Vector2Int(
             Mathf.RoundToInt(transform.position.x / gridSize),
             Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    public void SetTopColor(Color color) {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }

    public void Reset() {
        this.isExplored = false;
        this.exploredFrom = null;
    }

    private void OnMouseOver() {
        if(Input.GetMouseButtonDown(0) && this.isPlaceable) { //left click
            print(transform.name + " clicked");
        }
    }
}
