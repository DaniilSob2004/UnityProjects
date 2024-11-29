using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction OnDirtPickUp;

    // ���������� ����� ������ � ���� �������� ������������ � ������ ��������, � �������� �������� �������
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Dirt dirt))  // ���� ��� ������ � �������� ���� ��������� "Dirt" (������)
        {
            dirt.gameObject.SetActive(false);  // ��������� ����. ������ �� �����, ����� ��� ��������� � �������� ��� ��� ����������
            OnDirtPickUp?.Invoke();
        }
    }
}
