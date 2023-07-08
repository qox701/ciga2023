using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Data/StateMachine/RobotStates/Turn"), fileName = ("RobotState_Turn"))]
public class RobotState_Turn : RobotState
{

   
   public override void Enter()
   {
      base.Enter();
      //Debug.Log("Robot enter Turn");
     
   }

   public override void FrameUpdate(float dt)
   {
      
      
      if (!InputSource.IsTurn)
      {
         ThisStateMachine.SwitchState(typeof(RobotState_Idle));
      }
      
      ThisController.RotateY(InputSource.TurnAxis);
   }

   public override void PhysicsUpdate()
   {
     
   }
}
