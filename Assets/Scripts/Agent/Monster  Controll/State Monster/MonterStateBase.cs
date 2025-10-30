using System;
using UnityEngine;

[SerializeField]
public class MonterStateBase : AgentStateBase
{
    protected MonsterController _monsterController;
    public MonterStateBase(MonsterController monsterController) : base(monsterController)
    {
        _monsterController = monsterController;
    }
    protected override void HandleAnimationEvent()
    {
        _anim.SetFloat("xInput", _rb.linearVelocity.x );
        _anim.SetFloat("yInput", _rb.linearVelocity.y);
    }
}
