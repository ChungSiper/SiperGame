using UnityEngine;

public class AttackState : MonterStateBase
{
    public AttackState(MonsterController monster) : base(monster)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _monsterController.BasicAttack();
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        
    }
}
