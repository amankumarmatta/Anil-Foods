using UnityEngine;

public class ProductItem : MonoBehaviour
{
    public int scoreValue = 1;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
