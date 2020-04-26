using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

     [SerializeField] List<Waypoint> path;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
    }
    
    IEnumerator FollowPath() {
        foreach(Waypoint w in path) {
            transform.position = w.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }
}
