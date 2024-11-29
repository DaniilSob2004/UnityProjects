using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover2D : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float torqueForce;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Rotate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        var rotationVector = new Vector3(0f, 0f, horizontalInput) * (torqueForce * Time.deltaTime);

        transform.Rotate(-rotationVector);
    }

    private void Move()
    {
        float verticalInput = Input.GetAxis("Vertical");
        var movementVector = new Vector2(verticalInput, 0f) * (speed * Time.deltaTime);

        // TransformDirection - преобразует Vector из локальных координат объекта в мировые, чтобы движение оставалось относительно направления объекта
        rigidbody.velocity = transform.TransformDirection(movementVector);
    }
}
