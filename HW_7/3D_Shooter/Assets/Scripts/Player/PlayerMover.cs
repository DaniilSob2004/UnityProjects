using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody), typeof(PlayerInput))]
    public class PlayerMover : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _walkSpeed;
        [SerializeField] private float _sprintSpeed;
        
        [Header("Jump Settings")]
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _maxGroundAngle;  // максимальный угол поверхности, при котором объект всЄ ещЄ считаетс€ "сто€щим на земле"

        [Header("Rotation Settings")]
        [SerializeField] private Camera _camera;
        [SerializeField] private float _mouseSensitivity;  // коэффициент, определ€ющий чувствительность мыши
        [SerializeField] private float _yRotationRange;  // значение, ограничивающее угол наклона

        private float _verticalRotation;
        private bool _isGrounded;  // стоит ли на полу персонаж
        
        private void FixedUpdate()
        {
            Move();
        }

        private void Update()
        {
            Rotate();
            Jump();
        }

        // вызываетс€ в каждом кадре, пока объект продолжает соприкасатьс€ с другим объектом, имеющим коллайдер
        private void OnCollisionStay(Collision other)
        {
            var minYNormal = _maxGroundAngle * Mathf.Deg2Rad;  // из градусов в радианы

            foreach (var contact in other.contacts)  // массив точек контакта между двум€ объектами
            {
                // normal Ч это нормаль поверхности в точке контакта, она указывает перпендикул€рное направление от поверхности
                // если normal.y = 1, поверхность строго горизонтальна€, если normal.y = 0, поверхность строго вертикальна€
                if (contact.normal.y <= minYNormal)
                {
                    _isGrounded = false;
                    return;
                }   
            }
            
            _isGrounded = true;
        }

        // вызываетс€, когда объект с этим скриптом перестает касатьс€ другого объекта с коллайдером
        private void OnCollisionExit(Collision other)
        {
            _isGrounded = false;
        }

        private void Jump()
        {
            if (_playerInput.JumpInput && _isGrounded)
            {
                _rigidbody.AddForce(_jumpForce * Vector3.up, ForceMode.Impulse);
            }
        }

        private void Rotate()
        {
            // вычисл€етс€ угол горизонтального вращени€ объекта
            var horizontalRotation = _playerInput.MouseX * _mouseSensitivity;
            transform.Rotate(0f, horizontalRotation, 0f);

            // вычисл€етс€ угол вертикального вращени€ объекта
            _verticalRotation -= _playerInput.MouseY * _mouseSensitivity;
            _verticalRotation = Mathf.Clamp(_verticalRotation, -_yRotationRange, _yRotationRange);  // ограничивает угол наклона
            _camera.transform.localRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);
        }

        private void Move()
        {
            var speed = _playerInput.SprintInput ? _sprintSpeed : _walkSpeed;

            var movementVector = new Vector3(_playerInput.HorizontalInput, 0f, _playerInput.VerticalInput) * (speed * Time.fixedDeltaTime);

            _rigidbody.MovePosition(_rigidbody.position + transform.TransformDirection(movementVector));  // TransformDirection - из глобальных в локал. координаты
        }
    }
}
