using UnityEngine;
using System.Collections.Generic;
public class WorldGenerator : MonoBehaviour
{
    public Transform player;
    public List<GameObject> chunkPrefabs;
    public Transform chunkContainer;
    public ItemSpawner itemSpawner;
    public float spawnDistance = 20f;
    private int chunkCount = 0;
    private Transform lastExit;
    private List<GameObject> activeChunks = new List<GameObject>();
    public void StartWorld(Transform arAnchor)
    {
        chunkContainer.SetParent(arAnchor, false);
        SpawnChunk(arAnchor.position, arAnchor.rotation);
    }
    void Update()
    {
        if (Vector3.Distance(player.position, lastExit.position) < spawnDistance)
        {
            SpawnChunk(lastExit.position, lastExit.rotation);
        }
    }
    void SpawnChunk(Vector3 pos, Quaternion rot)
    {
        GameObject prefab = chunkPrefabs[Random.Range(0, chunkPrefabs.Count)];
        GameObject newChunk = Instantiate(prefab, pos, rot, chunkContainer);
        activeChunks.Add(newChunk);
        Chunk chunk = newChunk.GetComponent<Chunk>();
        lastExit = chunk.exitPoint;
        chunkCount++;
        if (chunkCount > 1)
        {
            itemSpawner.SpawnInChunk(chunk);
        }
        if (activeChunks.Count > 3)
        {
            Destroy(activeChunks[0]);
            activeChunks.RemoveAt(0);
        }
    }
}
