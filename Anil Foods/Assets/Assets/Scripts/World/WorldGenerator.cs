using UnityEngine;
using System.Collections.Generic;

public class WorldGenerator : MonoBehaviour
{
    public Transform player;
    public List<GameObject> chunkPrefabs;
    public Transform chunkContainer;

    public float spawnDistance = 20f;

    private Transform lastExit;

    public ItemSpawner itemSpawner;


    void Start()
    {
        // Spawn the first chunk
        SpawnChunk(Vector3.zero, Quaternion.identity);
    }

    void Update()
    {
        // If player moves close to the last exit, spawn another chunk
        if (Vector3.Distance(player.position, lastExit.position) < spawnDistance)
        {
            SpawnChunk(lastExit.position, lastExit.rotation);
        }
    }

    void SpawnChunk(Vector3 pos, Quaternion rot)
    {
        GameObject prefab = chunkPrefabs[Random.Range(0, chunkPrefabs.Count)];
        GameObject newChunk = Instantiate(prefab, pos, rot, chunkContainer);

        Chunk chunk = newChunk.GetComponent<Chunk>();
        itemSpawner.SpawnInChunk(chunk);
        lastExit = chunk.exitPoint;
    }
}
