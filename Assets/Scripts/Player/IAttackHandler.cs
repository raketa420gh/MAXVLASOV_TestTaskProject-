public interface IAttackHandler
{
    void Initialize(IPlayerAnimator playerAnimator);
    void Activate();
    void Deactivate();
    void Attack(int damage);
}