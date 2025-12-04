using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 minMaxY;

    void Update()
    {
        float v = Input.GetAxis("Vertical");
        Vector3 pos = transform.position;
        pos.y += v * moveSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minMaxY.x, minMaxY.y);
        transform.position = pos;
    }
}
