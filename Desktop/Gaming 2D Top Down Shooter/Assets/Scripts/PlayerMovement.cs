using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float smoothTime = 0.08f;
    private Vector2 currentVelocity;
    private Rigidbody2D rb;
    private Vector2 inputDirection;

    void Awake() { rb = GetComponent<Rigidbody2D>(); }

    void Update()
    {
        inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (inputDirection.sqrMagnitude > 0.001f)
        {
            float angle = Mathf.Atan2(inputDirection.y, inputDirection.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0,0,angle);
        }
    }

    void FixedUpdate()
    {
        Vector2 target = inputDirection * moveSpeed;
        rb.velocity = Vector2.SmoothDamp(rb.velocity, target, ref currentVelocity, smoothTime);
    }
}
