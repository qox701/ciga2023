using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour
{
    private enum Dir
    {
        None,
        Left,
        Right,
        Forward,
        Backward,
    }

    //获取鼠标输入所需
    private Dir nowMouseDir;
    private Vector2 startPos;
    private Vector2 offset;
    private RaycastHit hitInfo;
    
    //控制遥感旋转所需
    private Dir nowStickDir;
    private Vector3 stickStartRot;
    public int RotValue;

    private Camera _camera;

    public float inputThreshField;

    //为offset添加阈值
    public Vector2 Offset
    {
        get
        {
            if (Mathf.Abs(offset.x) < inputThreshField && Mathf.Abs(offset.y) < inputThreshField)
                return Vector2.zero;
            else
                return offset;
        }
    }
    
    private void Start()
    {
        _camera = Camera.main;
        nowStickDir= Dir.None;
        nowMouseDir = Dir.None;

        stickStartRot = this.transform.rotation.eulerAngles;
    }

    private bool _isSel;
    private void Update()
    {
        //检测到点击
        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition),out hitInfo,
                   1000,
                   1<<LayerMask.NameToLayer("Button&Joystick")))
            {
                if (hitInfo.collider.gameObject == this.gameObject)
                {
                    _isSel = true;
                    startPos = Input.mousePosition;
                }
            }
        }

        //松开鼠标按钮
        if (Input.GetMouseButtonUp(0))
        {
            _isSel = false;
            nowMouseDir = Dir.None;
            nowStickDir= Dir.None;
            offset= Vector2.zero;
            this.transform.rotation=Quaternion.Euler(stickStartRot);
        }

        //点击不动
        if (_isSel)
        {
            GetVecDir();
            JoyStickRotate();
           
        }
    }

    //判断鼠标方向
    private void GetVecDir()
    {
        if(nowMouseDir!=Dir.None)
            return;
        offset=(Vector2)Input.mousePosition-startPos;
        if(Mathf.Abs(Offset.x)>Mathf.Abs(Offset.y))
                nowMouseDir = Offset.x > 0 ? Dir.Right : Dir.Left;
        else if(Mathf.Abs(Offset.x)<Mathf.Abs(Offset.y))
                nowMouseDir = Offset.y > 0 ? Dir.Forward : Dir.Backward;
        else
        {
            nowMouseDir = Dir.None;
        }
    }
    
    //旋转摇杆
    private void JoyStickRotate()
    {
        if(nowStickDir!=Dir.None)
            return;
        switch (nowMouseDir)
        {
            case Dir.Forward:
                this.transform.rotation=Quaternion.Euler(stickStartRot)*Quaternion.AngleAxis(RotValue,Vector3.right);
                nowStickDir= Dir.Forward;
                break;
            case Dir.Backward:
                this.transform.rotation=Quaternion.Euler(stickStartRot)*Quaternion.AngleAxis(-RotValue,Vector3.right);
                nowStickDir= Dir.Backward;
                break;
            case Dir.Left:
                this.transform.rotation=Quaternion.Euler(stickStartRot)*Quaternion.AngleAxis(RotValue,Vector3.forward);
                nowStickDir= Dir.Left;
                break;
            case Dir.Right:
                this.transform.rotation=Quaternion.Euler(stickStartRot)*Quaternion.AngleAxis(-RotValue,Vector3.forward);
                nowStickDir= Dir.Right;
                break;
        }
    }
    
}
