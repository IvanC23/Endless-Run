using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunksAmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;

    List<GameObject> chunks = new List<GameObject>();

    void Start()
    {
        SpawnChunks();
    }

    void Update()
    {
        MoveChunks();
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
        if(chunks.Count > 0)
        {
            GameObject lastChunk = chunks[chunks.Count - 1];
            Vector3 newPosition = lastChunk.transform.position + Vector3.forward * chunkLength;
            GameObject newChunk = Instantiate(chunkPrefab, newPosition, Quaternion.identity, chunkParent);
            chunks.Add(newChunk);
        }else
        {
            GameObject newChunk = Instantiate(chunkPrefab, transform.position, Quaternion.identity, chunkParent);
            chunks.Add(newChunk);
        }
    }
}
