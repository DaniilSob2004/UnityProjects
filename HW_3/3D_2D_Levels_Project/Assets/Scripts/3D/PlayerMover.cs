using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;  // Rigidbody - для управления движением с учетом физики
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    // Вызывается на каждом фиксированном шаге симуляции физики
    // В отличие от Update, который вызывается каждый кадр (частота вызова зависит от FPS), FixedUpdate вызывается с фиксированным интервалом времени, определяемым параметром
    // Time.fixedDeltaTime, это делает его идеальным для расчётов, связанных с физикой, где важна стабильность
    private void FixedUpdate()
    {
        Move();
    }

    // Обновление вызывается один раз для каждого кадра
    private void Update()
    {
        Rotate();
    }

    private void Move()
    {
        var verticalInput = Input.GetAxis("Vertical");  // стрелки вверх/вниз и W/S
        var movementVector = new Vector3(0f, 0f, verticalInput) * (moveSpeed * Time.deltaTime);
        rigidBody.AddForce(transform.TransformDirection(movementVector), ForceMode.Acceleration);
        // добавить силу в определенном направлении, эта сила может двигать объект в пространстве или влиять на него в соответствии с физическими законами Unity
        // transform.TransformDirection - преобразует movementVector из локальных координат объекта(локальная система координат) в глобальные координаты
        // ForceMode определяет, как именно сила применяется к объекту
    }

    private void Rotate()
    {
        var horizontalInput = Input.GetAxis("Horizontal");  // стрелки влево/вправо и A/D
        var rotationVector = new Vector3(0f, horizontalInput, 0f) * (rotationSpeed * Time.deltaTime);
        transform.Rotate(rotationVector);
    }
}
