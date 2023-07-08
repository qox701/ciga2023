using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private IState _currentState;
    public IState CurrentState => _currentState;

    protected Dictionary<System.Type, IState> StateTable;

    private void Update()
    {
        _currentState.FrameUpdate(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _currentState.PhysicsUpdate();
    }

    /// <summary>
    /// Call this to set a default state, which a character will enter once it is loaded
    /// </summary>
    /// <param name="newState"></param>
    protected void SwitchOn(IState newState)
    {
        _currentState = newState;
        _currentState.Enter();
    }

    public void SwitchState(IState newState)
    {
        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    /// <summary>
    /// Use this function when switching state
    /// </summary>
    /// <param name="newStateType"></param>
    public void SwitchState(System.Type newStateType)
    {
        SwitchState(StateTable[newStateType]);
    }
}
