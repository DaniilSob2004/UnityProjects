using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;  // Rigidbody - ��� ���������� ��������� � ������ ������
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    // ���������� �� ������ ������������� ���� ��������� ������
    // � ������� �� Update, ������� ���������� ������ ���� (������� ������ ������� �� FPS), FixedUpdate ���������� � ������������� ���������� �������, ������������ ����������
    // Time.fixedDeltaTime, ��� ������ ��� ��������� ��� ��������, ��������� � �������, ��� ����� ������������
    private void FixedUpdate()
    {
        Move();
    }

    // ���������� ���������� ���� ��� ��� ������� �����
    private void Update()
    {
        Rotate();
    }

    private void Move()
    {
        var verticalInput = Input.GetAxis("Vertical");  // ������� �����/���� � W/S
        var movementVector = new Vector3(0f, 0f, verticalInput) * (moveSpeed * Time.deltaTime);
        rigidBody.AddForce(transform.TransformDirection(movementVector), ForceMode.Acceleration);
        // �������� ���� � ������������ �����������, ��� ���� ����� ������� ������ � ������������ ��� ������ �� ���� � ������������ � ����������� �������� Unity
        // transform.TransformDirection - ����������� movementVector �� ��������� ��������� �������(��������� ������� ���������) � ���������� ����������
        // ForceMode ����������, ��� ������ ���� ����������� � �������
    }

    private void Rotate()
    {
        var horizontalInput = Input.GetAxis("Horizontal");  // ������� �����/������ � A/D
        var rotationVector = new Vector3(0f, horizontalInput, 0f) * (rotationSpeed * Time.deltaTime);
        transform.Rotate(rotationVector);
    }
}
