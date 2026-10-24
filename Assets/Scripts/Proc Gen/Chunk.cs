using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinPrefab;

    [SerializeField] float appleSpawnChance = 0.3f;
    [SerializeField] float coinSpawnChance = 0.5f;

    [SerializeField] float coinSeparationLength = 2.0f;
    [SerializeField] float[] lanes = new float[] { -2.5f, 0f, 2.5f };

    private List<int> availableLanes = new List<int> { 0, 1, 2 };

    void Start()
    {
        SpawnFences();
        SpawnApple();
        SpawnCoins();
    }

    void SpawnFences()
    {
        int fencesToSpawn = Random.Range(0, availableLanes.Count);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count <= 0)
                break;

            int selectedLane = SelectLane();

            Vector3 spawnPosition = transform.position;
            spawnPosition.x = lanes[selectedLane];

            Instantiate(fencePrefab, spawnPosition, transform.rotation, this.transform);
        }
    }

    private int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }

    void SpawnApple()
    {
        if (Random.value > appleSpawnChance || availableLanes.Count <= 0)
            return;

        int selectedLane = SelectLane();

        Vector3 spawnPosition = transform.position;
        spawnPosition.x = lanes[selectedLane];

        Instantiate(applePrefab, spawnPosition, transform.rotation, this.transform);
    }

    void SpawnCoins()
    {
        if (Random.value > coinSpawnChance || availableLanes.Count <= 0)
            return;

        int selectedLane = SelectLane();
        int maxCoinsToSpawn = 5;
        int coinsToSpawn = Random.Range(1, maxCoinsToSpawn + 1);

        float topOfChunkZPos = transform.position.z + (coinSeparationLength * 2);

        for (int i = 0; i < coinsToSpawn; i++)
        {
            float spawnPositionZ = topOfChunkZPos - (i * coinSeparationLength);
            Vector3 spawnPosition = transform.position;
            spawnPosition.x = lanes[selectedLane];
            spawnPosition.z = spawnPositionZ;

            Instantiate(coinPrefab, spawnPosition, transform.rotation, this.transform);
        }
    }
}
