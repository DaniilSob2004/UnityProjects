using UnityEngine;

namespace Weapon.RangeWeapon
{
    public abstract class RangeWeapon : Weapon
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _range;

        private readonly Vector3 rayPosition = new Vector3(0.5f, 0.5f, 0f);
        
        protected override void Attack()
        {
            if (PlayerInput.AttackInput)
            {
                // преобразует координату во viewport-пространстве в луч в мировом пространстве
                var ray = _camera.ViewportPointToRay(rayPosition);

                // для проверки пересечения луча с физическими объектами, hit - объект, range - макс. расстояние, на которое проверяется пересечение
                if (Physics.Raycast(ray, out var hit, _range))
                {
                    if (hit.transform.TryGetComponent(out Enemy.Enemy enemy))
                    {
                        print(enemy.name);
                    }
                }
            }
        }

        // для визуализации объектов или данных в редакторе сцены, даже когда игра не запущена
        private void OnDrawGizmos()
        {
            var ray = _camera.ViewportPointToRay(rayPosition);
            Debug.DrawRay(ray.origin, ray.direction * _range, Color.red);  // рисует луч
        }
    }
}