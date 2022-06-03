using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerFinal : MonoBehaviour
{
    public GameObject enemy;                // The enemy prefab to be spawned.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Touched");
            StartCoroutine(EnemySpawn());

        }
    }
    IEnumerator EnemySpawn() {

        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < spawnPoints.Length; i++) {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        }
    }
}
