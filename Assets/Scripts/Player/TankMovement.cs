using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TankMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float reverseSpeed = 4f;
    [SerializeField] private float turnSpeed = 90f;

    [Header("Handling")]
    [SerializeField] private float acceleration = 12f;
    [SerializeField] private float deceleration = 16f;
    [SerializeField] private bool allowTurningInPlace = true;

    private Rigidbody body;
    private float moveInput;
    private float turnInput;
    private float currentSpeed;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        body.interpolation = RigidbodyInterpolation.Interpolate;
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        UpdateSpeed();
        MoveTank();
        TurnTank();
    }

    private void UpdateSpeed()
    {
        float targetSpeed = moveInput >= 0f
            ? moveInput * moveSpeed
            : moveInput * reverseSpeed;

        float rate = Mathf.Abs(targetSpeed) > Mathf.Abs(currentSpeed)
            ? acceleration
            : deceleration;

        currentSpeed = Mathf.MoveTowards(
            currentSpeed,
            targetSpeed,
            rate * Time.fixedDeltaTime);
    }

    private void MoveTank()
    {
        Vector3 movement = transform.forward * currentSpeed * Time.fixedDeltaTime;
        body.MovePosition(body.position + movement);
    }

    private void TurnTank()
    {
        if (!allowTurningInPlace && Mathf.Abs(currentSpeed) < 0.01f)
            return;

        float direction = currentSpeed < -0.01f ? -1f : 1f;
        float turnAmount = turnInput * turnSpeed * direction * Time.fixedDeltaTime;
        Quaternion rotation = Quaternion.Euler(0f, turnAmount, 0f);

        body.MoveRotation(body.rotation * rotation);
    }
}
