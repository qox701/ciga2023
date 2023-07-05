using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoSingleton<InputListener>
{
    

    //For now, without a virtual joystick, I test state machine with keyboard input
    public float WalkAxis { get; private set; }
    public bool IsWalk => WalkAxis != 0;
    public float TurnAxis { get; private set; }
    public bool IsTurn => TurnAxis != 0;
    public bool Jump { get; private set; }
    private void Update()
    {
        WalkAxis = Input.GetAxis("Vertical");
        TurnAxis = Input.GetAxis("Horizontal");
        Jump = Input.GetButtonDown("Jump");
    }
}
