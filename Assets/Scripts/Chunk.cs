using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] float[] lanes = new float[] { -2.5f, 0f, 2.5f };

    void Start()
    {
        SpawnFence();
    }

    void SpawnFence()
    {
        int randomLaneIndex = Random.Range(0, lanes.Length);
        float randomLaneX = lanes[randomLaneIndex];

        Vector3 spawnPosition = transform.position;
        spawnPosition.x = randomLaneX;

        Instantiate(fencePrefab, spawnPosition, transform.rotation, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
