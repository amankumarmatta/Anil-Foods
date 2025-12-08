using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public float moveSpeed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 input = new Vector3(joystick.Horizontal, 0, joystick.Vertical);

        rb.MovePosition(transform.position + input * moveSpeed * Time.fixedDeltaTime);

        if (input != Vector3.zero)
            transform.forward = input;
    }
}
