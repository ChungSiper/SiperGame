using UnityEngine;

public class WalkMonsterState : GroundMonsterState
{
    public WalkMonsterState(MonsterController monster) : base(monster)
    {
    }
    public override void Update()
    {
        base.Update();
        _monsterController.Walk();
        
        if (!_monsterController.isGroundDetect || _monsterController.isWallDetect)
        {
            _rb.linearVelocity = Vector2.zero;
            _stateMachine.ChangeState(_monsterController.IdleMonsterState);
        }
    }
}
