using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class AgentStateBase
{
    protected StateMachine _stateMachine;
    protected Rigidbody2D _rb;
    protected Animator _anim;
    protected bool _animationEventTrigger;

    public AgentStateBase(AgentController playerController)
    {
        _stateMachine = playerController.StateMachine;
        _rb = playerController.RB;
        _anim = playerController.anim;
    }
    public virtual void Enter()
    {
        _animationEventTrigger = false;
    }
    public virtual void Exit()
    {
    }
    public virtual void Update()
    {
        HandleAnimationEvent();
    }
    protected virtual void HandleAnimationEvent()
    {
        _anim.SetFloat("xInput", _rb.linearVelocity.x);
        _anim.SetFloat("yInput", _rb.linearVelocity.y);
    }
    public void TriggerAnimationEvent()
    {
        _animationEventTrigger = true;
    }
}