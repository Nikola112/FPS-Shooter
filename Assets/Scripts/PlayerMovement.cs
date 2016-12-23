using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float maxVelocityChange = 10f;

    private Rigidbody rb;
    private Vector3 moveDirection = Vector3.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (moveDirection != Vector3.zero)
        {
            var velocityChange = (moveDirection * speed - rb.velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0f;

            rb.AddForce(velocityChange * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }

    public void SetMoveDirection(float horizontal, float vertical)
    {
        var vecHorizontal = transform.right * horizontal;
        var vecVertical = transform.forward * vertical;

        moveDirection = (vecHorizontal + vecVertical).normalized;
    }
}
