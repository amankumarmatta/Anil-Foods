using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] productPrefabs;
    public float spawnInterval = 1.2f;
    public Vector2 spawnYRange;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, spawnInterval);
    }

    void Spawn()
    {
        float y = Random.Range(spawnYRange.x, spawnYRange.y);
        Vector3 pos = new Vector3(transform.position.x, y, 0);
        Instantiate(productPrefabs[Random.Range(0, productPrefabs.Length)], pos, Quaternion.identity);
    }
}
