using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(PlayerAttackTarget))]
[RequireComponent(typeof(Health))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    private IPlayerAttackTarget _playerAttackTarget;
    private IHealth _health;

    private void Awake()
    {
        _playerAttackTarget = GetComponent<IPlayerAttackTarget>();
        _health = GetComponent<IHealth>();
        _health.Initialize(_maxHealth);
    }

    private void OnEnable()
    {
        _playerAttackTarget.OnAttacked += HandleAttackedEvent;
        _health.OnOver += HandleDieEvent;
    }

    private void OnDisable()
    {
        _playerAttackTarget.OnAttacked -= HandleAttackedEvent;
        _health.OnOver -= HandleDieEvent;
    }

    private void HandleAttackedEvent(int damage)
    {
        _health.ChangeHealth(-damage);
    }

    private void HandleDieEvent()
    {
        _playerAttackTarget.Kill(_playerAttackTarget);
        Destroy(gameObject);
    }
}