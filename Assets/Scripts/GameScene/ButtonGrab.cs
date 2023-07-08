using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGrab : Button
{
    protected override void ButtonDown()
    {
        EventCenter.GetInstance().EventTrigger("Grab");
    }
}
