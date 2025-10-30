using UnityEngine;

public class DeathMonsterState : MonterStateBase
{
    public DeathMonsterState(MonsterController monster) : base(monster)
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

    }
}
