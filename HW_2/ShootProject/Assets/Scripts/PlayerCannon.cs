using UnityEngine;

public class PlayerCannon : MonoBehaviour
{
    // Префаб — это заранее настроенный объект, который можно создать и повторно использовать
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform spawnPoint;  // точка (место) откуда будет вылетать пуля
    [SerializeField] private float bulletSpeed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // создание пули в точке spawnPoint с использованием префаба bulletPrefab
            Bullet bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);

            var bulletRigitBody = bullet.GetComponent<Rigidbody>();
            if (bulletRigitBody != null)
            {
                bulletRigitBody.AddForce(spawnPoint.forward * bulletSpeed, ForceMode.VelocityChange);
            }
        }
    }
}
