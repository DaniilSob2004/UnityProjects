using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        collision.gameObject.SetActive(false);  // выкл. из сцены объект в который попала пуля
        gameObject.SetActive(false);  // выкл. из сцены пулю
    }
}