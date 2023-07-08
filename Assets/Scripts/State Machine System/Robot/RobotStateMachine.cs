using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotStateMachine : StateMachine
{
    [SerializeField] private RobotState[] states;

    private Animator _animator;
    //private Rigidbody _rigidbody;
    private RobotController _robotController;

    private void Awake()
    {
        StateTable = new Dictionary<Type, IState>(states.Length);
        _robotController = GetComponent<RobotController>();
        _animator = GetComponent<Animator>();

        foreach (RobotState state in states)
        {
            state.Initialize(this,_robotController,_animator);
            StateTable.Add(state.GetType(),state);
        }
    }
    //Enter first state in Start
    private void Start()
    {
        SwitchOn(StateTable[typeof(RobotState_Idle)]);
    }
}
