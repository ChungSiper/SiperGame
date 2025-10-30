using System.Collections;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    private AgentController _controller;
    void Awake()
    {
        _controller = GetComponent<AgentController>();
    }
    public void AttackFinish()
    {
        _controller.TriggerAnimationEvent();
    }
}