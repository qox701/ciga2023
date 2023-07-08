using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotGrabPoint : MonoBehaviour
{
    public GrabState grabState = GrabState.None;

    private Collider _collider;
    private Rigidbody _rigidbody;

    private static RobotGrabPoint _instance;

    public static RobotGrabPoint Instance => _instance;
    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
        _collider.enabled = false;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;

        _instance = this;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var itemControl = other.GetComponent<GrabItem>();
        if (!ReferenceEquals(itemControl, null))
        {
            grabState = GrabState.Grabbed;
            itemControl.grabState = GrabState.Grabbed;
            MonoSingleton<InputListener>.Instance.canGrab = false;
            
            //Item moving to hand
            other.transform.position = Vector3.Lerp(other.transform.position, this.transform.position, 1f);
            other.transform.rotation = Quaternion.Lerp(other.transform.rotation,this.transform.rotation,1f);
            
            other.transform.localScale *= itemControl.inHandScale;
            
            other.transform.SetParent(this.transform);
        }
    }
    
}
/// <summary>
/// Used to describe the grab point state and item state
/// It is possible we need to adjust item transform(especially scale) based on item state
/// if in the game scene, then item is bigger; or(in hand) it shall be small
/// </summary>
public enum GrabState
{
    None,
    Grabbed
}
