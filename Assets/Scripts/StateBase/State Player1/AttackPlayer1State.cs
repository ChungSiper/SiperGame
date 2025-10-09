using UnityEngine;

public class AttackPlayer1State : StateBase
{
    private int _currentAttackIndex = 0;
    private const int MAX_INDEX = 2;
    private float _lastAttackTimer;
    private float _comboChainTime = 1f;

    public AttackPlayer1State(PlayerController player) : base(player)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("IsAttack", true);
        if(Time.time > _lastAttackTimer + _comboChainTime)
        {
            _currentAttackIndex = 0;
        }
        if(_currentAttackIndex >= MAX_INDEX)
        {
            _currentAttackIndex = 0;
        }
        _currentAttackIndex++;
        _lastAttackTimer = Time.time;
        _anim.SetInteger("BasicAttack", _currentAttackIndex);
        _rb.linearVelocity = new Vector2(_player.AttackPushForce.x * _player.FacingDirection, _player.AttackPushForce.y);

    }
    public override void Exit()
    {
        base.Exit();
        _anim.SetBool("IsAttack", false);
    }
    public override void Update()
    {
        base.Update();
        if(_triggerEvent)
        {
            _stateMachine.ChangeState(_player.IdlePlayer1State);
        }

    }
}
