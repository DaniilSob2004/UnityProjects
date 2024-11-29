using UnityEngine;
using UnityEngine.Events;

public class Player2D : MonoBehaviour
{
    public event UnityAction OnDirtPickUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Dirt2D dirt))
        {
            dirt.gameObject.SetActive(false);
            OnDirtPickUp?.Invoke();
        }
    }
}
