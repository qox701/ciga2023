using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : Button
{
    protected override void ButtonDown()
    {
        Debug.Log("Button down");
    }

    protected override void ButtonUp()
    {
        Debug.Log("Button up");
    }
}

    

