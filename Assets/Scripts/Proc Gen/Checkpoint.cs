using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] int checkpointAddTimer = 6;
    [SerializeField] float obstacleSpawnTimeReduction = 0.1f;
    ObstacleSpawner obstacleSpawner;

    const string playerTag = "Player";

    GameManager gameManager;

    void Start()
    {
        gameManager = GetComponent<Chunk>().GameManager;
        obstacleSpawner = FindAnyObjectByType<ObstacleSpawner>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            gameManager.IncreaseTime(checkpointAddTimer);
            obstacleSpawner.DecreaseSpawnTime(obstacleSpawnTimeReduction);
        }
    }
}
