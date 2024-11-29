using UnityEngine;

public class PlayerCannon : MonoBehaviour
{
    // ������ � ��� ������� ����������� ������, ������� ����� ������� � �������� ������������
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform spawnPoint;  // ����� (�����) ������ ����� �������� ����
    [SerializeField] private float bulletSpeed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // �������� ���� � ����� spawnPoint � �������������� ������� bulletPrefab
            Bullet bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);

            var bulletRigitBody = bullet.GetComponent<Rigidbody>();
            if (bulletRigitBody != null)
            {
                bulletRigitBody.AddForce(spawnPoint.forward * bulletSpeed, ForceMode.VelocityChange);
            }
        }
    }
}
