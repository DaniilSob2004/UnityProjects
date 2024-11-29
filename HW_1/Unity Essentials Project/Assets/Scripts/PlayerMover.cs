using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float Speed;

    // Start is called before the first frame update (Start ���������� ����� ����������� ������� �����)
    private void Start()
    {
        print($"Start player speed: {Speed}");
    }

    // Update is called once per frame (���������� ���������� ���� ��� ��� ������� �����)
    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");  // ������� �����/���� � W/S
        var movementVector = new Vector3(0f, 0f, verticalInput * Speed * Time.deltaTime);

        transform.Translate(movementVector);
    }
}
