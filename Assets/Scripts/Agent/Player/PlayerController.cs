using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : AgentController, IDamageable
{
    #region Input
    private Vector2 _moveInput;
    private float _jumpInput;
    private float _attackInput;
    #endregion

    #region Properties
    public Vector2 MoveInput => _moveInput;
    public float JumpInput { get => _jumpInput; set => _jumpInput = value; }
    public float AttackInput { get => _attackInput; set => _attackInput = value; }
    public Vector2 AttackPushForce => _attackPushForce;


    #endregion


    #region Serialized fields
    
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private Vector2 _attackPushForce;
    #endregion
    public float moveSpeed => _moveSpeed;
    public float jumpForce => _jumpForce;
    #region Detected Ground

    #endregion


    #region States
    public Player1StateBase IdlePlayer1State;
    public Player1StateBase RunPlayer1State;
    public Player1StateBase FallPlayer1State;
    public Player1StateBase JumpPlayer1State;
    public Player1StateBase AttackPlayer1State;
    public Player1StateBase HurtPlayer1State;
    public Player1StateBase DeathPlayer1State;
    #endregion
    protected override void Awake()
    {
        base.Awake();
        IdlePlayer1State = new IdlePlayer1State(this);
        RunPlayer1State = new RunPlayer1State(this);
        FallPlayer1State = new FallPlayer1State(this);
        JumpPlayer1State = new JumpPlayer1State(this);
        AttackPlayer1State = new AttackPlayer1State(this);
        HurtPlayer1State = new HurtPlayer1State(this);
        DeathPlayer1State = new DeathPlayer1State(this);
        _stateMachine.ChangeState(IdlePlayer1State);

    }
    public void Move(InputAction.CallbackContext ctx)
    {
        _moveInput = ctx.ReadValue<Vector2>();
    }
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            _jumpInput = ctx.ReadValue<float>();
        }
        
    }
    
    public void BasicAttack(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            _attackInput = ctx.ReadValue<float>();
        }
    }
    public void OnDamage(float damage)
    {
        _health -= damage;
        _healthBar.SetValue(_health);
        //_stateMachine.ChangeState(HurtPlayer1State);
        if (_health <= 0)
        {
            Die();
        }
    }
    public void ChangeHealth(float healthPercent)
    {
        _health += _maxHealth * healthPercent;
        _health = Mathf.Clamp(_health, 0, _maxHealth);
        _healthBar.SetValue(_health);
    }
    public void Die()
    {
        _stateMachine.ChangeState(DeathPlayer1State);
    }
}
