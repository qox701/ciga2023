using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private enum MoveDir
    {
        forward,
        backward,
        right,
        left,
    }
    private bool isMoving = false;
    private MoveDir moveDir;
    
    public float speed = 1;
    public float rotateSpeed = 1;
    private void Start()
    {
        EventCenter.GetInstance().AddEventListener("MoveForward",MoveForward);
        EventCenter.GetInstance().AddEventListener("MoveBackward",MoveBackward);
        EventCenter.GetInstance().AddEventListener("MoveLeft",MoveLeft);
        EventCenter.GetInstance().AddEventListener("MoveRight",MoveRight);
        EventCenter.GetInstance().AddEventListener("StopMove",StopMove);
    }

    private void Update()
    {
        if (isMoving)
        {
            switch (moveDir)
            {
                case MoveDir.forward:
                    this.transform.position += Vector3.forward * Time.deltaTime*speed;
                    break;
                case MoveDir.backward:
                    this.transform.position += Vector3.back * Time.deltaTime*speed;
                    break;
                case MoveDir.left:
                    this.transform.Rotate(Vector3.up,-rotateSpeed*Time.deltaTime);
                    break;
                case MoveDir.right:
                    this.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
                    break;
            }
        }
    }

    private void MoveForward()
    {
        isMoving = true;
        moveDir = MoveDir.forward;
    }
    
    private void MoveBackward()
    {
        isMoving = true;
        moveDir = MoveDir.backward;
    }
    private void MoveLeft()
    {
        isMoving = true;
        moveDir = MoveDir.left;
    }
    private void MoveRight()
    {
        isMoving = true;
        moveDir = MoveDir.right;
    }

    private void StopMove()
    {
        isMoving= false;
    }
}
