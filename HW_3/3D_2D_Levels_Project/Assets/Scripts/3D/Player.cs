using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction OnDirtPickUp;

    // вызывается когда объект с этим скриптом сталкивается с другим объектом, у которого настроен триггер
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Dirt dirt))  // если это объект у которого есть компонент "Dirt" (скрипт)
        {
            dirt.gameObject.SetActive(false);  // полностью выкл. объект из сцены, делая его невидимым и отключая все его компоненты
            OnDirtPickUp?.Invoke();
        }
    }
}
