using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Data/StateMachine/RobotStates/Grab"), fileName = ("RobotState_Grab"))]
public class RobotState_Grab : RobotState
{
   public override void Enter()
   {
      base.Enter();
      //Debug.Log("Robot Enter Grab");
      EventCenter.GetInstance().EventTrigger(stateName);
      MusicMgr.GetInstance().PlaySound("机器人抓取",false);
   }

   public override void FrameUpdate(float dt)
   {
      if (IsAnimationFinished)
      {
         ThisStateMachine.SwitchState(typeof(RobotState_Idle));
      }
   }

   public override void Exit()
   {
      //Debug.Log("Robot Exit Grab");
      EventCenter.GetInstance().EventTrigger("end"+stateName);
   }
}
