using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] items;

    public void SpawnInChunk(Chunk chunk)
    {
        foreach (Transform point in chunk.spawnPoints)
        {
            if (Random.value < 0.4f)
            {
                Instantiate(
                    items[Random.Range(0, items.Length)],
                    point.position,
                    Quaternion.identity
                );
            }
        }
    }
}
