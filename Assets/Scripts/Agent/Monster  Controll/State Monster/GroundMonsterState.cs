using System.Collections;
using UnityEngine;

public class GroundMonsterState : MonterStateBase
{
    protected float timer;
    public GroundMonsterState(MonsterController monsterController) : base(monsterController)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("IsGround", true);
        timer = _monsterController.IdleTime;
    }
    public override void Exit()
    {
        base.Exit();
        _anim.SetBool("IsGround", false);
    }
    public override void Update()
    {
        base.Update();
        if (_monsterController.PlayerDetected())
        {
            _stateMachine.ChangeState(_monsterController.MonsterBattleState);
        }
    }
}