using System.Threading;
using UnityEngine;

public class IdleMonsterState : MonterStateBase
{
    private float _timer;
    private object monsterController;

    public IdleMonsterState(MonsterController monsterController) : base(monsterController)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("isGround", true);
        _timer = _monsterController.IdleTime;
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _monsterController.SetFacingDiretion(_monsterController.FacingDirection * -1);
            _stateMachine.ChangeState(_monsterController.WalkMonsterState);
        }
    }
}
