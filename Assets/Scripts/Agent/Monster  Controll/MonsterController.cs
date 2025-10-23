using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
public class MonsterController : AgentController
{
    #region Serialized fields
    [SerializeField] private float _walkSpeed = 2.5f;
    [SerializeField] private float _runSpeed = 5f;
    [SerializeField] private float _idleTime = 2f;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _detectRange;
    [SerializeField] private LayerMask _playerLayer;
    #endregion
    public float WalkSpeed => _walkSpeed;
    public float RunSpeed => _runSpeed;
    public float IdleTime => _idleTime;
    public float AttackRange => _attackRange;

    public MonterStateBase IdleMonsterState;
    public MonterStateBase WalkMonsterState;
    public MonterStateBase RunMonsterState;
    public MonterStateBase MonsterBattleState;
    public MonterStateBase AttackMonsterState;


    protected override void Awake()
    {
        base.Awake();
        IdleMonsterState = new IdleMonsterState(this);
        WalkMonsterState = new WalkMonsterState(this);
        RunMonsterState = new RunMonsterState(this);
        MonsterBattleState = new MonsterBattleState(this);
        AttackMonsterState = new AttackMonsterState(this);
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
    public RaycastHit2D PlayerDetected()
    {
        RaycastHit2D hit = Physics2D.Raycast(_detectGameObject.position, Vector2.right * FacingDirection, _detectRange, _playerLayer);
        if (hit.collider != null)
        {
            Debug.Log("Player Detected");
            return hit;
        }
        return default;
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.green;
        Gizmos.DrawLine(_detectGameObject.position, _detectGameObject.position + Vector3.right * FacingDirection * _detectRange);
    }

}
