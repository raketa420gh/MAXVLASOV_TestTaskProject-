using UnityEngine;

public class WeaponCollector : MonoBehaviour, IWeaponCollector
{
    private IWeaponUser _weaponUser;
    
    public void Initialize(IWeaponUser weaponUser)
    {
        _weaponUser = weaponUser;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        IWeapon weapon = other.gameObject.GetComponent<IWeapon>();

        CollectWeapon(weapon);
    }

    private void CollectWeapon(IWeapon weapon)
    {
        if (weapon == null)
            return;

        if (weapon.IsEquipped)
            return;

        if (_weaponUser.IsWeaponized)
            return;

        _weaponUser.EquipWeapon(weapon);
    }
}