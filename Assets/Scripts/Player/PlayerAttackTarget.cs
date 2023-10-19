using System;
using UnityEngine;

public class PlayerAttackTarget : MonoBehaviour, IPlayerAttackTarget
{
    public event Action<int> OnAttacked;
    public event Action<IPlayerAttackTarget> OnKill;

    public void Attack(int damage)
    {
        OnAttacked?.Invoke(damage);
    }

    public void Kill(IPlayerAttackTarget target)
    {
        OnKill?.Invoke(target);
    }
}