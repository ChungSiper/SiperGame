using UnityEngine;

public class FallPlayer1State : Player1StateBase
{
    public FallPlayer1State(PlayerController player) : base(player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("isJump", true);
    }
    public override void Exit()
    {
        base.Exit();
        _anim.SetBool("isJump", false);
    }
    public override void Update()
    {
        base.Update();
        if (_player.isGroundDetect || _rb.linearVelocity.y == 0)
        {
            _stateMachine.ChangeState(_player.IdlePlayer1State);
        }
        if (_player.isWallDetect)
        {
            //_stateMachine.ChangeState(_player.WallSlidePlayer1State);
        }
    }
}
