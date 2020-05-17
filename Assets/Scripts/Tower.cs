using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 10f;
    private ParticleSystem projectileParticle;
    private Transform targetEnemy;

    public Waypoint baseWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        projectileParticle = GetComponentInChildren<ParticleSystem>();
    }

    private void SetTargetEnemy() {
        EnemyMovement[] enemies = GameObject.FindObjectsOfType<EnemyMovement>();
        if(enemies.Length == 0) {
            targetEnemy = null;
            return;
        }

        EnemyMovement currentTarget = enemies[0];
        float minDist = Vector3.Distance(currentTarget.transform.position, transform.position);
        for(int i = 1; i < enemies.Length; i++) {
            float newDist = Vector3.Distance(enemies[i].transform.position, transform.position);
            if (newDist <= minDist) { // accept equal because later enemies are farther in path
                minDist = newDist;
                currentTarget = enemies[i];
            }
        }
        targetEnemy = currentTarget.transform;
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy) {
            objectToPan.LookAt(targetEnemy, Vector3.up);
            FireAtEnemy();
        }
        else {
            Shoot(false);
        }
    }

    private void FireAtEnemy() {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, transform.position);

        bool isClose = distanceToEnemy <= attackRange;
        Shoot(isClose);
    }

    private void Shoot(bool isActive) {
        ParticleSystem.EmissionModule emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
