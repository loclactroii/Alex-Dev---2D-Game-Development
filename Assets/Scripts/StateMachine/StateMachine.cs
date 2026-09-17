using UnityEngine;

public class StateMachine 
{
    public EnityState currentState { get; private set; }
    public bool canChangeState;

    public void Initialize(EnityState startState)
    {
        canChangeState = true;
        currentState = startState;
        currentState.Enter();
    }

    public void ChangeState(EnityState newState)
    {
        if (!canChangeState)
            return;

        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void UpdateActiveState()
    {
        currentState.Update();        
    }

    public void SwitchOffStateachine() => canChangeState = false; 
}
