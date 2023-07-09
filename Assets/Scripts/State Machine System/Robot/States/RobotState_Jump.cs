using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Data/StateMachine/RobotStates/Jump"), fileName = ("RobotState_Jump"))]
public class RobotState_Jump : RobotState
{
   private float _timer = 0f;
   private Vector3 _jumpMove;
   private float _gravity;
   private Vector3 forward;
   public override void Enter()
   {
      base.Enter();
      //Debug.Log("Robot Enter Jump");
      EventCenter.GetInstance().EventTrigger(stateName);
      MusicMgr.GetInstance().PlaySound("机器人跳跃",false);
      forward = ThisController.transform.forward;
      _jumpMove = forward;
      _jumpMove *= ThisController.jumpMoveSpeed;
      _jumpMove.y = ThisController.jumpPower;
      _gravity = ThisController.gravity;
   }

   public override void FrameUpdate(float dt)
   {
      _timer += dt;
      if (_timer > 0.2f && ThisController.IsGrounded)
      {
         ThisStateMachine.SwitchState(typeof(RobotState_Idle));
      }

      _jumpMove.y -= _gravity * dt;
      
      ThisController.JumpMove(_jumpMove);
   }

   public override void Exit()
   {
      _timer = 0f;
      EventCenter.GetInstance().EventTrigger("end"+stateName);
   }
}
