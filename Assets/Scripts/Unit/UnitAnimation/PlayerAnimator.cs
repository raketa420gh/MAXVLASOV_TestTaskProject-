using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour, IPlayerAnimator
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _attackTriggerName = "Attack";
    [SerializeField] private string _moveSpeedParameterName = "MoveSpeed";

    public event Action OnAttack;

    public void SetMoveSpeedParameter(float moveSpeed) => 
        SetAnimationFloat(_moveSpeedParameterName, moveSpeed);

    private void SetAnimationFloat(string parameterName, float value) => 
        _animator.SetFloat(parameterName, value);

    public void SetAttackLayerWeight(float weight) => 
        _animator.SetLayerWeight(1, weight);

    private void HandleAttackEvent()
    {
        OnAttack?.Invoke();
    }
}