using System;

public interface IPlayerAnimator
{
    event Action OnAttack;
    
    void SetMoveSpeedParameter(float moveSpeed);
    void SetAttackLayerWeight(float weight);
}