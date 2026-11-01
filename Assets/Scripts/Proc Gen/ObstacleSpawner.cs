using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] float spawnInterval = 2f;
    [SerializeField] Transform obstacleParent;
    [SerializeField] float spawnWidth = 4f;

    private float minSpawnInterval = 1f;

    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    public void DecreaseSpawnTime(float amount)
    {
        if (spawnInterval - amount < minSpawnInterval)
        {
            spawnInterval = minSpawnInterval;
        }
        else
        {
            spawnInterval -= amount;
        }
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

            Vector3 spawnPosition = transform.position;
            spawnPosition.x += Random.Range(-spawnWidth / 2, spawnWidth / 2);
            
            Instantiate(obstaclePrefab, spawnPosition, Random.rotation, obstacleParent);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
