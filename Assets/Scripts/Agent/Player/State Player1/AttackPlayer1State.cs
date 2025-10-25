using UnityEngine;

public class AttackPlayer1State : Player1StateBase
{
    private int _comboAttackIndex = 1;
    private const int MAX_COMBO_INDEX = 2;
    private float _lastAttackTimer;
    private float _comboChainTime = 1f;

    public AttackPlayer1State(PlayerController player) : base(player)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("IsAttack", true);
        _comboAttackIndex++;
        if (Time.time > _lastAttackTimer + _comboChainTime
            || _comboAttackIndex > MAX_COMBO_INDEX)
        {
            _comboAttackIndex = 1;
        }
        _anim.SetInteger("BasicAttack", _comboAttackIndex);
        _player.SetFacingDiretion(_player.MoveInput.x);
        _lastAttackTimer = Time.time;
        
    }
    public override void Exit()
    {
        base.Exit();
        _anim.SetBool("IsAttack", false);
    }
    public override void Update()
    {
        base.Update();
        _rb.linearVelocity = new Vector2(_player.AttackPushForce.x * _player.FacingDirection, _player.AttackPushForce.y);
        if (_animationEventTrigger)
        {
            _stateMachine.ChangeState(_player.IdlePlayer1State);
        }
        if(!_player.isGroundDetect && _rb.linearVelocity.y < 0)
        {
            _stateMachine.ChangeState(_player.FallPlayer1State);
        }

    }
}
