using UnityEngine;
using System.Collections;

public class newEnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector2 spawnAreaCenter;
    public Vector2 spawnAreaSize;
    public float spawnInterval = 5f;

    private void Start()
    {
        StartCoroutine(SpawnEnemyLoop());
    }

    private IEnumerator SpawnEnemyLoop()
    {
        while (true)
        {
            Vector3 spawnPos = new Vector3(
                spawnAreaCenter.x + Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
                spawnAreaCenter.y + Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f),
                0
            );

            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
