using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 10f;
    private ParticleSystem projectileParticle;

    // Start is called before the first frame update
    void Start()
    {
        projectileParticle = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
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
