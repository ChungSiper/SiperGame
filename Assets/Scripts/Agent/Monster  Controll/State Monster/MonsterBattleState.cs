using System.Collections;
using UnityEngine;

public class MonsterBattleState : MonterStateBase
{
    private Transform _Player;
    public MonsterBattleState(MonsterController monsterController) : base(monsterController)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("isBattle", true);
        if(_Player == null)
        {
            _Player = _monsterController.PlayerDetected().transform;
        }
    }
    public override void Exit()
    {
        base.Exit();
        _anim.SetBool("isBattle", false);
    }
    public override void Update()
    {
        base.Update();
        if(IsInAttackRange())
        {
            _stateMachine.ChangeState(_monsterController.AttackMonsterState);
        }
        else
        {
            _stateMachine.ChangeState(_monsterController.RunMonsterState);
        }
    }
    private bool IsInAttackRange()
    {
        return Mathf.Abs(_monsterController.transform.position.x - _Player.position.x) <= _monsterController.AttackRange;
    }
    private void Chase()
    {
        _monsterController.SetFacingDiretion(ChasingDirection());
        _rb.linearVelocity = new Vector2(_monsterController.RunSpeed * ChasingDirection(), _rb.linearVelocity.y);
    }
    private float ChasingDirection()
    {
        return _monsterController.transform.position.x > _Player.position.x 
            ? 1 
            : -1;
    }

}