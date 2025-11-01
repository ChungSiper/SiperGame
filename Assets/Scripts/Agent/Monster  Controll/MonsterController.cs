using UnityEngine;
public class MonsterController : AgentController, IDamageable
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
    public MonterStateBase BattleMonsterState;
    public MonterStateBase AttackMonsterState;
    public MonterStateBase HurtMonterState;
    public MonterStateBase DeathMonterState;

    protected override void Awake()
    {
        base.Awake();
        IdleMonsterState = new IdleMonsterState(this);
        WalkMonsterState = new WalkMonsterState(this);
        RunMonsterState = new RunMonsterState(this);
        BattleMonsterState = new BattleMonsterState(this);
        AttackMonsterState = new AttackMonsterState(this);
        HurtMonterState = new HurtMonsterState(this);
        DeathMonterState = new DeathMonsterState(this);
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
            Debug.Log("Player detected");
            return hit;
        }
        return default;
    }
    public void OnDamage(float damage)
    {
        _health -= damage;
        _healthBar.SetValue(_health);
        _stateMachine.ChangeState(HurtMonterState);
        if (_health <= 0)
        {
            Die();
            Destroy(gameObject, 0.1f);
        }
    }
    public void Die()
    {
        _stateMachine.ChangeState(DeathMonterState);
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.green;
        Gizmos.DrawLine(_detectGameObject.position, _detectGameObject.position + Vector3.right * FacingDirection * _detectRange);
    }

}
