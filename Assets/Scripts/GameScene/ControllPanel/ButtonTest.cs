using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : Button
{
    protected override void ButtonDown()
    {
        EventCenter.GetInstance().EventTrigger("Jump");
        Debug.Log(1);
    }

    protected override void ButtonUp()
    {
        Debug.Log("Button up");
    }
}

    

