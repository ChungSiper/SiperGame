using UnityEngine;

public class FallPlayer1State : StateBase
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
        if (_player.isGroundDetect)
        {
            _stateMachine.ChangeState(_player.IdlePlayer1State);
        }
    }
}
