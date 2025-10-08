using UnityEngine;
public class RunPlayer1State : StateBase
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
        else
        {
            _stateMachine.ChangeState(new IdlePlayer1State(_player));
        }
    }
}
