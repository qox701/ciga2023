using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private bool _isSel;
    private Vector3 startPos;
    private Camera _camera;

    private Vector3 selPos;
    private RaycastHit hitInfo;

    public float DownValue;
    
    private void Start()
    {
        startPos = this.transform.position;
        _camera = Camera.main;
        selPos=startPos-Vector3.up*DownValue;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition),out hitInfo,
                   1000,
                   1<<LayerMask.NameToLayer("Button&Joystick")))
            {
                if (hitInfo.collider.gameObject == this.gameObject)
                {
                    _isSel = true;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isSel = false;
            this.transform.position = startPos;
        }

        if (_isSel)
        {
            this.transform.position=selPos;
        }
    }
}
