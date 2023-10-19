using UnityEngine;

public class MeleeWeapon : MonoBehaviour, IWeapon
{
    private bool _isEquipped;
    private Transform _selfTransform;

    public bool IsEquipped => _isEquipped;

    private void Awake()
    {
        _selfTransform = transform;
    }

    public void Equip(IWeaponUser weaponUser)
    {
        _selfTransform.parent = weaponUser.HandleTransform;
        _selfTransform.forward = weaponUser.HandleTransform.forward;
        _selfTransform.localPosition = Vector3.zero;
        _isEquipped = true;
    }

    public void Drop()
    {
        _selfTransform.parent = null;
        _isEquipped = false;
    }
}