using UnityEngine;

public class IdlePlayer1State : Player1StateBase
{

    public IdlePlayer1State(PlayerController player) : base(player)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("isGround", true);
    }
    public override void Exit()
    {
        base.Exit();
        _anim.SetBool("isGround", false);
    }

    public override void Update()
    {
        base.Update();
        if (_player.MoveInput.x != 0)
        {
            _stateMachine.ChangeState(_player.RunPlayer1State);
        }
        if(_player.JumpInput != 0)
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _player.jumpForce * _player.JumpInput);
            _player.JumpInput = 0f;
            _stateMachine.ChangeState(_player.JumpPlayer1State);
        }
        if (_player.AttackInput != 0)
        {
            _player.AttackInput = 0f;
            _stateMachine.ChangeState(_player.AttackPlayer1State);
        }  
    }
}
