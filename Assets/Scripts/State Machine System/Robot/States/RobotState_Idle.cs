using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Data/StateMachine/RobotStates/Idle"), fileName = ("RobotState_Idle"))]
public class RobotState_Idle : RobotState
{
   [SerializeField] private float deceleration = 5f;

   private float _currentSpeed;
   public override void Enter()
   {
      base.Enter();
      Debug.Log("Robot enter idle");
      _currentSpeed = ThisController.CurrentVelocity.z;
   }

   public override void FrameUpdate()
   {
      if (InputSource.IsWalk)
      {
         ThisStateMachine.SwitchState(typeof(RobotState_Walk));
      }

      _currentSpeed = Mathf.MoveTowards(_currentSpeed, 0, deceleration * Time.deltaTime);
   }

   public override void PhysicsUpdate()
   {
      ThisController.MoveForward(_currentSpeed);
   }
}
