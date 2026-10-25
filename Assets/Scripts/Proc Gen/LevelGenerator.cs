using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CameraController cameraController;
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] Transform chunkParent;
    [SerializeField] ScoreManager scoreManager;

    [Header("Level Settings")]
    [Tooltip("Amount of chunks to spawn at the start of the game")]
    [SerializeField] int startingChunksAmount = 12;
    [Tooltip("Do not change chunk legth unless chunk prefab size reflects the change")]
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float minMoveSpeed = 2f;
    [SerializeField] float maxMoveSpeed = 20f;
    [SerializeField] float minGravityZ = -22f;
    [SerializeField] float maxGravityZ = -2f;


    List<GameObject> chunks = new List<GameObject>();

    void Start()
    {
        SpawnChunks();
    }

    void Update()
    {
        MoveChunks();
    }

    public void ChangeChunkMoveSpeed(float speedAmount)
    {
        float newMoveSpeed = moveSpeed + speedAmount;
        newMoveSpeed = Mathf.Clamp(newMoveSpeed, minMoveSpeed, maxMoveSpeed);

        if (moveSpeed != newMoveSpeed)
        {
            moveSpeed = newMoveSpeed;

            float newGravityZ = Physics.gravity.z - speedAmount;
            newGravityZ = Mathf.Clamp(newGravityZ, minGravityZ, maxGravityZ);

            Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, newGravityZ);
            cameraController.ChangeCameraFOV(speedAmount);
        }
    }

    void SpawnChunks()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            SpawnChunk();
        }
    }

    void MoveChunks()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunk.transform.Translate(Vector3.back * (moveSpeed * Time.deltaTime));

            if (chunk.transform.position.z < Camera.main.transform.position.z - chunkLength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
            }
        }
    }

    void SpawnChunk()
    {
        if (chunks.Count > 0)
        {
            GameObject lastChunk = chunks[chunks.Count - 1];
            Vector3 newPosition = lastChunk.transform.position + Vector3.forward * chunkLength;
            GameObject newChunkGO = Instantiate(chunkPrefab, newPosition, Quaternion.identity, chunkParent);
            newChunkGO.GetComponent<Chunk>().Init(this, scoreManager);
            chunks.Add(newChunkGO);
        }
        else
        {
            GameObject newChunk = Instantiate(chunkPrefab, transform.position, Quaternion.identity, chunkParent);
            newChunk.GetComponent<Chunk>().Init(this, scoreManager);
            chunks.Add(newChunk);
        }
    }
}
