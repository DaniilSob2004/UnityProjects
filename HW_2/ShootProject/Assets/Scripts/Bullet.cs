using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        collision.gameObject.SetActive(false);  // ����. �� ����� ������ � ������� ������ ����
        gameObject.SetActive(false);  // ����. �� ����� ����
    }
}