using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoSingleton<InputListener>
{
    private void Start()
    {
        EventCenter.GetInstance().AddEventListener("MoveForward",MoveForward);
        EventCenter.GetInstance().AddEventListener("MoveBackward",MoveBackward);
        EventCenter.GetInstance().AddEventListener("MoveLeft",MoveLeft);
        EventCenter.GetInstance().AddEventListener("MoveRight",MoveRight);
        EventCenter.GetInstance().AddEventListener("StopMove",StopMove);
        EventCenter.GetInstance().AddEventListener("Jump",JumpAction);
        canJump = true;
    }

    //For now, without a virtual joystick, I test state machine with keyboard input
    public float WalkAxis { get; private set; }
    public bool IsWalk => WalkAxis != 0;
    public float TurnAxis { get; private set; }
    public bool IsTurn => TurnAxis != 0;
    public bool Jump { get; private set; }

    private bool canJump;
    
    private enum MoveDir
    {
        none,
        forward,
        backward,
        right,
        left,
    }
    
    private MoveDir moveDir;

    private float GetVMove;
    private float GetHMove;
    private bool ismoving = false;
    private void Update()
    {
        //WalkAxis = Input.GetAxis("Vertical");
        //WalkAxis= GetVMove;
        //TurnAxis = Input.GetAxis("Horizontal");
        //TurnAxis = GetHMove;
        //Jump = Input.GetButtonDown("Jump");
        
            switch (moveDir)
            {
                case MoveDir.forward:
                    WalkAxis = 1;
                    break;
                case MoveDir.backward:
                    WalkAxis = -1;
                    break;
                case MoveDir.left:
                    TurnAxis = -1;
                    break;
                case MoveDir.right:
                    TurnAxis = 1;
                    break;
                case MoveDir.none:
                    WalkAxis = 0;
                    TurnAxis = 0;
                    break;
            }
        
    }
    
    private void MoveForward()
    {
        moveDir = MoveDir.forward;
    }
    
    private void MoveBackward()
    {
        moveDir = MoveDir.backward;
    }
    private void MoveLeft()
    {
        moveDir = MoveDir.left;
    }
    private void MoveRight()
    {
        moveDir = MoveDir.right;
    }

    private void StopMove()
    {
        moveDir = MoveDir.none;
    }
    
    private void JumpAction()
    {
        if(canJump)
            Jump = true;
        StartCoroutine(JumpCoroutine());
        StartCoroutine(JumpCoolDown());
    }
    
    IEnumerator JumpCoroutine()
    {
        yield return new WaitForSeconds(0.01f);
        Jump = false;
    }
    
    IEnumerator JumpCoolDown()
    {
        canJump=false;
        yield return new WaitForSeconds(2f);
        canJump = true;
    }
}
