using UnityEngine;

public class PlayerAttackHandler : MonoBehaviour, IAttackHandler
{
    private IPlayerAttackTarget _attackTarget;
    private IPlayerAnimator _animator;
    private bool _isActive;

    private void OnTriggerEnter(Collider other)
    {
        if (!_isActive)
            return;

        IPlayerAttackTarget playerAttackTarget = other.GetComponent<IPlayerAttackTarget>();

        if (playerAttackTarget == null)
            return;

        _attackTarget = playerAttackTarget;
        _attackTarget.OnKill += OnKillEvent;
        
        _animator.SetAttackLayerWeight(1);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_isActive)
            return;
        
        IPlayerAttackTarget playerAttackTarget = other.GetComponent<IPlayerAttackTarget>();
        
        if (playerAttackTarget == null)
            return;

        if (_attackTarget == playerAttackTarget)
            _attackTarget = null;

        _animator.SetAttackLayerWeight(0);
    }

    public void Initialize(IPlayerAnimator playerAnimator)
    {
        _animator = playerAnimator;
        Activate();
    }

    public void Activate()
    {
        _isActive = true;
    }

    public void Deactivate()
    {
        _animator.SetAttackLayerWeight(0);
        _isActive = false;
    }

    public void Attack(int damage)
    {
        _attackTarget?.Attack(damage);
    }

    private void OnKillEvent(IPlayerAttackTarget playerAttackTarget)
    {
        if (playerAttackTarget == null)
            return;

        if (playerAttackTarget != _attackTarget) 
            return;
        
        _animator.SetAttackLayerWeight(0);
        
        _attackTarget.OnKill -= OnKillEvent;
        _attackTarget = null;
    }
}