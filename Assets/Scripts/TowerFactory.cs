using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit = 3;
    private GameObject towersParent;

    private Queue<Tower> towers = new Queue<Tower>();

    void Start() {        
        towersParent = GameObject.Find("Towers");
    }
    
    public void AddTower(Waypoint baseWaypoint) {   
        baseWaypoint.isPlaceable = false;
        if (towers.Count == towerLimit) {
            Tower toMove = towers.Dequeue();
            towers.Enqueue(toMove);
            toMove.transform.position = baseWaypoint.transform.position; // update pos
            toMove.baseWaypoint.isPlaceable = true; // previous position is placeable
            toMove.baseWaypoint = baseWaypoint;
        }
        else {
            Tower newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity, towersParent.transform);
            newTower.baseWaypoint = baseWaypoint;
            towers.Enqueue(newTower);
        }  
    }
}
