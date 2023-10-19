using UnityEngine;

public class PlayerUnit : MovableUnit
{
    [SerializeField] private WeaponUser _weaponUser;
    [SerializeField] private WeaponCollector _weaponCollector;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private PlayerAttackHandler _attackHandler;

    public IPlayerAnimator Animator => _animator;
    public IAttackHandler AttackHandler => _attackHandler;

    protected override void Awake()
    {
        _weaponCollector.Initialize(_weaponUser);
        _attackHandler.Initialize(_animator);
        
        base.Awake();
    }
}