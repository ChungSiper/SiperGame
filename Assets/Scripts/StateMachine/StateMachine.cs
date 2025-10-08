using UnityEngine;

public class StateMachine 
{
    private StateBase _currentState;
    public StateBase CurrentState
    {
        get => _currentState;
    } 

    public void ChangeState(StateBase newState)
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
