using UnityEngine;

public interface IWeaponUser
{
    Transform HandleTransform { get; }
    bool IsWeaponized { get; }
    
    void EquipWeapon(IWeapon weapon);
    void DropWeapon();
}