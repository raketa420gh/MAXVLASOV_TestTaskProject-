using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour, IPlayerController
{
    [SerializeField] private PlayerUnit _playerUnit;
    private IPlayerAnimator _playerAnimator;
    private IUnitMovement _playerMovement;
    private IAttackHandler _playerAttackHandler;
    private IInputHandler _inputHandler;
    private bool _isControlsActive = true;

    [Inject]
    public void Construct(IInputHandler inputHandler)
    {
        _inputHandler = inputHandler;
    }

    private void Awake()
    {
        _playerMovement = _playerUnit.Movement;
        _playerAnimator = _playerUnit.Animator;
        _playerAttackHandler = _playerUnit.AttackHandler;
    }

    private void OnEnable()
    {
        _playerAnimator.OnAttack += HandlePlayerAttackEvent;
    }

    private void OnDisable()
    {
        _playerAnimator.OnAttack -= HandlePlayerAttackEvent;
    }

    private void Update()
    {
        if (!_isControlsActive) 
            return;

        var moveDirection = GetConvertedMoveDirection();
        
        _playerAnimator.SetMoveSpeedParameter(moveDirection.magnitude);

        if (moveDirection == Vector3.zero)
            return;

        MoveToDirectionIgnoreY(moveDirection);
    }

    public void Enable()
    {
        _isControlsActive = true;
    }

    public void Disable()
    {
        _isControlsActive = false;
    }

    private void MoveToDirectionIgnoreY(Vector3 moveDirection)
    {
        _playerMovement.Move(moveDirection);

        var playerTransform = _playerUnit.transform;
        var playerPosition = playerTransform.position;
        playerTransform.forward = moveDirection;
        playerTransform.position = new Vector3(playerPosition.x, 0, playerPosition.z);
    }

    private Vector3 GetConvertedMoveDirection()
    {
        return new Vector3(_inputHandler.MoveAxis.x, 0, _inputHandler.MoveAxis.y);
    }

    private void HandlePlayerAttackEvent()
    {
        _playerAttackHandler.Attack(1);
    }
}