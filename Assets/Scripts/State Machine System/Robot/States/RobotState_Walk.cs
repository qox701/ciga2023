using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Data/StateMachine/RobotStates/Walk"), fileName = ("RobotState_Walk"))]
public class RobotState_Walk : RobotState
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float acceleration = 2f;
    
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Robot Enter Walk");
        CurrentWalkSpeed = ThisController.CurrentVelocity.z;
    }

    public override void FrameUpdate()
    {
        if (!InputSource.IsWalk)
        {
            ThisStateMachine.SwitchState(typeof(RobotState_Idle));
        }

        CurrentWalkSpeed = Mathf.MoveTowards(CurrentWalkSpeed, walkSpeed*InputSource.WalkAxis, acceleration * Time.deltaTime);
    }

    public override void PhysicsUpdate()
    {
        ThisController.MoveForward(CurrentWalkSpeed);
    }
}
