using System;
using UnityEngine;

public class AttackAnimationEventHandler : MonoBehaviour
{
    public event Action OnAttack;

    public void HandleAttackEvent()
    {
        OnAttack?.Invoke();
    }
}