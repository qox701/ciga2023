using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayJoyStrick : JoyStick
{
    protected override void StickForward()
    {
        EventCenter.GetInstance().EventTrigger("RayUp");
    }

    protected override void StickBackward()
    {
        EventCenter.GetInstance().EventTrigger("RayDown");
    }

    protected override void StickLeft()
    {
        EventCenter.GetInstance().EventTrigger("RayLeft");
    }

    protected override void StickRight()
    {
        EventCenter.GetInstance().EventTrigger("RayRight");
    }

    protected override void StickStop()
    {
        EventCenter.GetInstance().EventTrigger("RayStop");
    }
}

