using UnityEngine;

public class JumpPlayer1State : Player1StateBase
{
    public JumpPlayer1State(PlayerController player) : base(player)
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
        if(_rb.linearVelocity.y < 0)
        {
            _stateMachine.ChangeState(_player.FallPlayer1State);
        }
        if(_player.isGroundDetect)
        {
            _stateMachine.ChangeState(_player.IdlePlayer1State);
        }
    }
}
