using UnityEngine;

public class IdleMonsterState : GroundMonsterState
{
    public IdleMonsterState(MonsterController monsterController) : base(monsterController)
    {
    }
    public override void Update()
    {
        base.Update();
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            _monsterController.SetFacingDiretion(_monsterController.FacingDirection * -1);
            _stateMachine.ChangeState(_monsterController.WalkMonsterState);
        }
    }
}
