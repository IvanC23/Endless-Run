using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] int checkpointAddTimer = 6;

    const string playerTag = "Player";

    GameManager gameManager;

    void Start()
    {
        gameManager = GetComponent<Chunk>().GameManager;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            gameManager.IncreaseTime(checkpointAddTimer);
        }
    }
}
