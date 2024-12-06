using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/RangeWeaponData", fileName = "NewRangeWeaponData")]
public class RangeWeaponData : ScriptableObject
{
    [SerializeField] protected float damage;
    [SerializeField] private float range;
    [SerializeField] private int maxAmmo;
    [SerializeField] private int totalAmmo;
    [SerializeField] private float reloadTime;

    public float Damage => damage;
    public float Range => range;
    public int MaxAmmo => maxAmmo;
    public int TotalAmmo => totalAmmo;
    public float ReloadTime => reloadTime;
}
