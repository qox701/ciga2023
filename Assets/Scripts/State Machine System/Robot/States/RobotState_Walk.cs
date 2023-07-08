using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Data/StateMachine/RobotStates/Walk"), fileName = ("RobotState_Walk"))]
public class RobotState_Walk : RobotState
{

    
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Robot Enter Walk");
    }

    public override void FrameUpdate(float dt)
    {
        
        if (!InputSource.IsWalk)
        {
            ThisStateMachine.SwitchState(typeof(RobotState_Idle));
        }

        
        ThisController.MoveForward(InputSource.WalkAxis);
    }

    public override void PhysicsUpdate()
    {
        
    }
}
