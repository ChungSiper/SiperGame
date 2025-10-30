using UnityEngine;

public class HurtPlayer1State : Player1StateBase
{
    public HurtPlayer1State(PlayerController playerController) : base(playerController)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("isHurt", true);
        _rb.linearVelocity = new Vector2(0f, _rb.linearVelocity.y);
    }
    public override void Exit()
    {
        base.Exit();
        _anim.SetBool("isHurt", false);
    }
}
