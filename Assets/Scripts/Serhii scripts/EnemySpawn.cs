using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRadius = 5f;

    public int minEnemies = 1;
    public int maxEnemies = 4;

    public float spawnDelay = 0.7f;   
    public float waveDelay = 3f;      

    private int aliveEnemies = 0;

    private void Start()
    {
        StartWave();
    }

    void StartWave()
    {
        int enemiesThisWave = Random.Range(minEnemies, maxEnemies + 1);
        aliveEnemies = enemiesThisWave;

        StartCoroutine(SpawnEnemiesOneByOne(enemiesThisWave));
    }

    IEnumerator SpawnEnemiesOneByOne(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void SpawnEnemy()
    {
        Vector2 randomPos = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
        Instantiate(enemyPrefab, randomPos, Quaternion.identity);
    }

    public void OnEnemyKilled()
    {
        aliveEnemies--;

        if (aliveEnemies <= 0)
        {
            StartCoroutine(NextWaveAfterDelay());
        }
    }

    IEnumerator NextWaveAfterDelay()
    {
        yield return new WaitForSeconds(waveDelay);
        StartWave();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
