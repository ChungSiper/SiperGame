using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
public class MonsterController : AgentController
{
    #region Serialized fields
    [SerializeField] private float _walkSpeed = 2.5f;
    [SerializeField] private float _runSpeed = 5f;
    [SerializeField] private float _idleTime = 2f;
    #endregion
    public float WalkSpeed => _walkSpeed;
    public float RunSpeed => _runSpeed;
    public float IdleTime => _idleTime;

    public MonterStateBase IdleMonsterState;
    public MonterStateBase WalkMonsterState;

    protected override void Awake()
    {
        base.Awake();
        IdleMonsterState = new IdleMonsterState(this);
        WalkMonsterState = new WalkMonsterState(this);
        _stateMachine.ChangeState(IdleMonsterState);
    }
    public void Walk()
    {
        _rb.linearVelocity = new Vector2(_walkSpeed * FacingDirection, _rb.linearVelocity.y);
    }
    public void Run()
    {
        _rb.linearVelocity = new Vector2(_runSpeed * FacingDirection, _rb.linearVelocity.y);
    }
    public void BasicAttack()
    {

    }

}
