using UnityEngine;
public class RunPlayer1State : Player1StateBase
{
    public RunPlayer1State(PlayerController player) : base(player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("isGround", true);
        _player.SetFacingDiretion(_player.MoveInput.x);
    }
    public override void Exit()
    {
        base.Exit();
        _anim.SetBool("isGround", false);
    }

    public override void Update()
    {
        base.Update();
        _rb.linearVelocity = new Vector2(_player.MoveInput.x * _player.moveSpeed, _rb.linearVelocity.y);
        if (_player.MoveInput.x == 0)
        {
            _stateMachine.ChangeState(_player.IdlePlayer1State);
        }
        if(_player.JumpInput != 0)
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _player.jumpForce * _player.JumpInput);
            _player.JumpInput = 0f;
            _stateMachine.ChangeState(_player.JumpPlayer1State);
        }
        if(!_player.isGroundDetect)
        {
            _stateMachine.ChangeState(_player.FallPlayer1State);
        }
        if(_player.AttackInput != 0)
        {
            _player.AttackInput = 0f;
            _stateMachine.ChangeState(_player.AttackPlayer1State);
        }
    }
}
