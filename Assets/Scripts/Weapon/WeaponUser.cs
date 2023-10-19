using UnityEngine;

public class WeaponUser : MonoBehaviour, IWeaponUser
{
    [SerializeField] private Transform _handleTransform;
    private IWeapon _currentWeapon;

    public Transform HandleTransform => _handleTransform;
    public bool IsWeaponized => _currentWeapon != null;

    public void EquipWeapon(IWeapon weapon)
    {
        weapon.Equip(this);
        _currentWeapon = weapon;
    }

    public void DropWeapon()
    {
        if (!IsWeaponized)
            return;

        _currentWeapon.Drop();
    }
}