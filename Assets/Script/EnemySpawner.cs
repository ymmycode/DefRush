using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]float secondsBetweenSpawn = 2f;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] public TMP_Text spawnedEnemies;
    [SerializeField] AudioClip spawnSFX;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawningEnemies());
        spawnedEnemies.text = score.ToString();
    }

    IEnumerator SpawningEnemies()
    {
        while (true)
        {
            AddToScore();
            GetComponent<AudioSource>().PlayOneShot(spawnSFX);
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = this.transform;
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }

    private void AddToScore()
    {
        score++;
        spawnedEnemies.text = score.ToString();
    }
}
