using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;

    public bool isExplored;
    public Waypoint exploredFrom;

    public bool isPlaceable = true;

    private TowerFactory towerFactory;

    const int gridSize = 10;
    // Start is called before the first frame update
    void Start()
    {
        towerFactory = GameObject.FindObjectOfType<TowerFactory>();
        Reset();
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
            towerFactory.AddTower(this);
        }
    }
}
