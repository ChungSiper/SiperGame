using UnityEngine;

public class AttackMonsterState : MonterStateBase
{
    public AttackMonsterState(MonsterController monster) : base(monster)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("isAttack", true);
        _rb.linearVelocity = new Vector2(0f, _rb.linearVelocity.y);
    }
    public override void Exit()
    {
        base.Exit();
        _anim.SetBool("isAttack", false);
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
