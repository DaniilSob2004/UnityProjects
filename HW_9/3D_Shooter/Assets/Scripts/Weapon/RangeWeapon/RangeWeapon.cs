using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Weapon.RangeWeapon
{
    public abstract class RangeWeapon : Weapon
    {
        [SerializeField] private RangeWeaponData data;
        [SerializeField] private Camera _camera;

        private readonly Vector3 rayPosition = new Vector3(0.5f, 0.5f, 0f);

        private float damage;
        private float range;
        private int maxAmmo;
        private int totalAmmo;
        private float reloadTime;

        private bool isReloading;
        private int currentAmmo;

        public event UnityAction<int, int> OnAmmoChanged;
        public event UnityAction<float> OnReload;

        private void Awake()
        {
            damage = data.Damage;
            range = data.Range;
            maxAmmo = data.MaxAmmo;
            totalAmmo = data.TotalAmmo;
            reloadTime = data.ReloadTime;
        }

        private void Start()
        {
            currentAmmo = maxAmmo;
            OnAmmoChanged?.Invoke(currentAmmo, totalAmmo);
        }

        protected override void Attack()
        {
            if (PlayerInput.AttackInput)
            {
                Shoot();
            }
            else if (PlayerInput.ReloadInput)
            {
                Reload();
            }
        }

        private void Shoot()
        {
            if (isReloading || currentAmmo <= 0)
            {
                return;
            }

            // преобразует координату во viewport-пространстве в луч в мировом пространстве
            var ray = _camera.ViewportPointToRay(rayPosition);

            // для проверки пересечения луча с физическими объектами, hit - объект, range - макс. расстояние, на которое проверяется пересечение
            if (Physics.Raycast(ray, out var hit, range))
            {
                if (hit.transform.TryGetComponent(out Enemy.Enemy enemy))
                {
                    print(enemy.name);
                }
            }

            currentAmmo--;
            OnAmmoChanged?.Invoke(currentAmmo, totalAmmo);
        }

        private void Reload()
        {
            if (currentAmmo < maxAmmo && totalAmmo > 0 && !isReloading)
            {
                StartCoroutine(ReloadDelay());
            }
        }

        private IEnumerator ReloadDelay()
        {
            isReloading = true;
            OnReload?.Invoke(reloadTime);

            yield return new WaitForSeconds(reloadTime);

            var ammoToReload = maxAmmo - currentAmmo;
            var minAmmoToReload = Mathf.Min(ammoToReload, totalAmmo);

            currentAmmo += minAmmoToReload;
            totalAmmo -= minAmmoToReload;

            OnAmmoChanged?.Invoke(currentAmmo, totalAmmo);

            isReloading = false;
        }

        // для визуализации объектов или данных в редакторе сцены, даже когда игра не запущена
        private void OnDrawGizmos()
        {
            var ray = _camera.ViewportPointToRay(rayPosition);
            Debug.DrawRay(ray.origin, ray.direction * range, Color.red);  // рисует луч
        }
    }
}