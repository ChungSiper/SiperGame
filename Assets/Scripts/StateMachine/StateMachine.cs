using UnityEngine;

public class StateMachine 
{
    private AgentStateBase _currentState;
    public AgentStateBase CurrentState
    {
        get => _currentState;
    }
    public void ChangeState(AgentStateBase newState)
    {
        if (newState == null)
        {
            return;
        }
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
}
