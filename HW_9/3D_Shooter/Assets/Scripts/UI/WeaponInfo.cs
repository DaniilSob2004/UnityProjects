using System.Collections;
using TMPro;
using UnityEngine;
using Weapon.RangeWeapon;

public class WeaponInfo : MonoBehaviour
{
    [SerializeField] private RangeWeapon rangeWeapon;
    [SerializeField] private CanvasGroup weaponInfo;
    [SerializeField] private TMP_Text ammoInfo;
    [SerializeField] private TMP_Text reloadInfo;

    private void OnEnable()
    {
        rangeWeapon.OnAmmoChanged += OnAmmoChanged;
        rangeWeapon.OnReload += OnReload;
    }

    private void OnDisable()
    {
        rangeWeapon.OnAmmoChanged -= OnAmmoChanged;
        rangeWeapon.OnReload -= OnReload;
    }

    private void OnAmmoChanged(int currentAmmo, int totalAmmo)
    {
        ammoInfo.text = $"{currentAmmo} / {totalAmmo}";
    }

    private void OnReload(float reloadTime)
    {
        StartCoroutine(ReloadInfo(reloadTime));
    }

    private IEnumerator ReloadInfo(float reloadTime)
    {
        reloadInfo.gameObject.SetActive(true);
        yield return new WaitForSeconds(reloadTime);
        reloadInfo.gameObject.SetActive(false);
    }
}
