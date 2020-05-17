using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip deathSFX;

    void ProcessHit() {
        health--;
        hitParticlePrefab.Play();
        if (health <= 0) {
            Die();
        }
        else {
            GetComponent<AudioSource>().PlayOneShot(hitSFX);
        }
    }

    private void Die() {
        ParticleSystem vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx, vfx.main.duration);

        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);

        Destroy(gameObject);
    }

    private void OnParticleCollision(GameObject other) {
        ProcessHit();
    }
}
