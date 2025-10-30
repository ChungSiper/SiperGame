using System.Collections;
using UnityEngine;

public class DeathPlayer1State : Player1StateBase
{
    private float _deathTime = 5f;
    public DeathPlayer1State(PlayerController playerController) : base(playerController)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("isDeath", true);
    }
    public override void Exit()
    {
        base.Exit();
        _anim.SetBool("isDeath", false);
    }
    public override void Update()
    {
        base.Update();
        _deathTime -= Time.deltaTime;
        _stateMachine.ChangeState(_player.IdlePlayer1State);

    }


}