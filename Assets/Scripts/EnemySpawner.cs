using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)] [SerializeField] float secondsBetweenSpawns = 2f;

    [SerializeField] EnemyMovement enemyPrefab;

    [SerializeField] Text score;
    [SerializeField] AudioClip spawnedEnemySFX;

    private GameObject enemiesParent;
    private int enemyCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemiesParent = GameObject.Find("Enemies");
        score.text = "0";
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies() {

        while(true) {
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            Instantiate(enemyPrefab, transform.position, Quaternion.identity, enemiesParent.transform);
            enemyCounter++;
            score.text = enemyCounter.ToString();
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
