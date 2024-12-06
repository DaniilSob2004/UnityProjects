using UnityEngine;

namespace Weapon.MeleeWeapon
{
    public class MeleeWeapon : Weapon
    {
        [SerializeField] private float _attackRadius;
        
        protected override void Attack()
        {
            if (PlayerInput.AttackInput)
            {
                var colliders = Physics.OverlapSphere(transform.position, _attackRadius);  // создаёт воображаемую сферу с заданным центром и радиусом
                // проверяет, какие объекты с физическими коллайдерами пересекают эту сферу, и возвращает массив таких коллайдеров

                foreach (var collider in colliders)
                {
                    if (collider.TryGetComponent(out Enemy.Enemy enemy))
                    {
                        print(enemy.name);
                    }
                }
            }
        }

        // для визуализации объектов или данных в редакторе сцены, даже когда игра не запущена
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _attackRadius);  // рисует сферу вокруг персонажа (для визуального показа где будет урон, радиус урона)
        }
    }
}