using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Pathfinder pathfinder;

    [SerializeField] float movementPeriod = .5f;
    [SerializeField] ParticleSystem goalParticle;
    [SerializeField] AudioClip reachedBaseSFX;

    void Start()
    {   
        pathfinder = GameObject.FindObjectOfType<Pathfinder>();
        List<Waypoint> path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }
    
    IEnumerator FollowPath(List<Waypoint> path) {
        foreach(Waypoint w in path) {
            transform.position = w.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }
        SelfDestruct();
    }

    private void SelfDestruct() {

        ParticleSystem vfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx, vfx.main.duration);

        Destroy(gameObject);
    }
}
