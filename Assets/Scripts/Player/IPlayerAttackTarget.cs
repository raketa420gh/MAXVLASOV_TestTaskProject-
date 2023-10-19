using System;

public interface IPlayerAttackTarget
{
    event Action<int> OnAttacked;
    event Action<IPlayerAttackTarget> OnKill;

    void Attack(int damage);
    void Kill(IPlayerAttackTarget target);
}