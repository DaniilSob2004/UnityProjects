using UnityEngine;

namespace Weapon.RangeWeapon
{
    public abstract class RangeWeapon : Weapon
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _weaponPoint;
        [SerializeField] private float _range;
        
        protected override void Attack()
        {
            if (PlayerInput.AttackInput)
            {
                // преобразует координату во viewport-пространстве в луч в мировом пространстве
                var ray = _camera.ViewportPointToRay(_weaponPoint.position);

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
            Debug.DrawRay(_weaponPoint.position, _weaponPoint.forward * _range, Color.red);  // рисует луч
        }
    }
}