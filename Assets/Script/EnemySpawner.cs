using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]float secondsBetweenSpawn = 2f;
    [SerializeField] GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawningEnemies());
    }

    IEnumerator SpawningEnemies()
    {
        while (true)
        {
            Instantiate (enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }
}
