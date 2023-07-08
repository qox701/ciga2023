using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GrabItem : MonoBehaviour
{
    [HideInInspector]public GrabState grabState = GrabState.None;
    public ItemType type = ItemType.Battery;

    private Collider _collider;
    private Rigidbody _rigidbody;

    /// <summary>
    /// It is possible that we need to adjust the scale of an item when grab it
    /// Or it will look too large in hand
    /// </summary>
    public float inHandScale = 0.5f; 
    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
        _collider.enabled = true;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
        
    }
    /// <summary>
    /// Call this when hand in an item
    /// </summary>
    public void HandInItem()
    {
        grabState = GrabState.None;
        RobotGrabPoint.Instance.grabState = GrabState.None;
        MonoSingleton<InputListener>.Instance.canGrab = true;

        Destroy(gameObject);
    }
}

public enum ItemType
{
    Battery,
    Mission //Collect this to complete a stage
}
