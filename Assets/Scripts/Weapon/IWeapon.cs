public interface IWeapon
{
    bool IsEquipped { get; }
    
    void Equip(IWeaponUser weaponUser);
    void Drop();
}