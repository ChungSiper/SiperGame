using UnityEngine;

public class HurtMonsterState : MonterStateBase
{
    public HurtMonsterState(MonsterController monster) : base(monster)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("isHurt",true);
        _rb.linearVelocity = Vector2.zero;
    }
    public override void Exit()
    {
        base.Exit();
        _anim.SetBool("isHurt", false);
    }
    public override void Update()
    {
        base.Update();
        if (_animationEventTrigger)
        {
            _stateMachine.ChangeState(_monsterController.BattleMonsterState);
        }
    }
}
