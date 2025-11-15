using UnityEngine;

public class BattleMonsterState : MonterStateBase
{
    private Transform _player;
    public BattleMonsterState(MonsterController monsterController) : base(monsterController)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _anim.SetBool("isBattle", true);
        if(_player == null)
        {
            _player = _monsterController.PlayerDetected().transform;
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
        else if (_monsterController.PlayerDetected().collider == null)
        {
            _stateMachine.ChangeState(_monsterController.IdleMonsterState);
        }
        else
        {
            Chase();
        }
    }
    private bool IsInAttackRange()
    {
        return Mathf.Abs(_monsterController.transform.position.x - _player.position.x) < _monsterController.AttackRange;
    }
    private void Chase()
    {
        _monsterController.SetFacingDiretion(ChasingDirection());
        _rb.linearVelocity = new Vector2(_monsterController.RunSpeed * ChasingDirection(), _rb.linearVelocity.y);
    }
    private float ChasingDirection()
    {
        return _monsterController.transform.position.x > _player.position.x 
            ? -1f 
            : 1f;
    }

}