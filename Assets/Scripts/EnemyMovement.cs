using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Pathfinder pathfinder;

    void Start()
    {   
        pathfinder = GameObject.FindObjectOfType<Pathfinder>();
        List<Waypoint> path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }
    
    IEnumerator FollowPath(List<Waypoint> path) {
        foreach(Waypoint w in path) {
            transform.position = w.transform.position;
            yield return new WaitForSeconds(2f);
        }
    }
}
