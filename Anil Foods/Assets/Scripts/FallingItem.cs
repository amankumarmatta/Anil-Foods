using UnityEngine;

public class FallingItem : MonoBehaviour
{
    public int scoreValue = 50;

    void Update()
    {
        if (transform.position.x < -10f)
            Destroy(gameObject);
    }
}
