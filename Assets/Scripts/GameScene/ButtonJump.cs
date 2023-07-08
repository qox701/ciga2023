using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonJump : Button
{
    protected override void ButtonDown()
    {
        EventCenter.GetInstance().EventTrigger("Jump");
    }
    
}