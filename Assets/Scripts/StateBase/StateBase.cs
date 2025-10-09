using UnityEditor;
using UnityEngine;
[SerializeField]
public class StateBase 
{
    protected PlayerController _player;
    protected StateMachine _stateMachine;
    protected Animator _anim;
    protected Rigidbody2D _rb;
    protected bool _triggerEvent;
    public bool TriggerEvent { get => _triggerEvent; set => _triggerEvent = value;}
    public StateBase(PlayerController player)
    {
        _player = player;
        _stateMachine = player.stateMachine;
        _anim = player.anim;
        _rb = player.rb;
    }
    public virtual void Enter() 
    {
        _triggerEvent = false;
    }
    public virtual void Exit() 
    {
    }
    public virtual void Update() 
    {
        HandleAnimation();
    }
    private void HandleAnimation()
    {
        _anim.SetFloat("xInput", _rb.linearVelocity.x);
        _anim.SetFloat("yInput", _rb.linearVelocity.y);
    }
}
