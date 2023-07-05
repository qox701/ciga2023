using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Data/StateMachine/RobotStates/Turn"), fileName = ("RobotState_Turn"))]
public class RobotState_Turn : RobotState
{
   [SerializeField] private float rotateSpeed = 10f;
   public override void Enter()
   {
      base.Enter();
      Debug.Log("Robot enter Turn");
      
   }

   public override void FrameUpdate()
   {
      
   }
}
