using System;
using UnityEngine;

[SerializeField]
public class MonterStateBase : AgentStateBase
{
    protected MonsterController _monster;
    public MonterStateBase(MonsterController monsterController) : base(monsterController)
    {
        _monster = monsterController;
    }
    protected override void HandleAnimationEvent()
    {
        _anim.SetFloat("xInput", _rb.linearVelocity.x / _monster.RunSpeed);
        _anim.SetFloat("yInput", _rb.linearVelocity.y);
    }
}
