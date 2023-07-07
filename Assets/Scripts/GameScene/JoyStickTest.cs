using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickTest : JoyStick
{
    protected override void StickForward()
    {
        EventCenter.GetInstance().EventTrigger("MoveForward");
    }

    protected override void StickBackward()
    {
        EventCenter.GetInstance().EventTrigger("MoveBackward");
    }

    protected override void StickLeft()
    {
        EventCenter.GetInstance().EventTrigger("MoveLeft");
    }

    protected override void StickRight()
    {
        EventCenter.GetInstance().EventTrigger("MoveRight");
    }
    
    protected override void StickStop()
    {
        EventCenter.GetInstance().EventTrigger("StopMove");
    }
}
