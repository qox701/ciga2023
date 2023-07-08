using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotGroundDetector : MonoSingleton<RobotGroundDetector>
{
    [SerializeField]private float detectionRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    private Collider[] _colliders = new Collider[1];

    public bool IsGrounded
    {
        get
        {
            var colNum = Physics.OverlapSphereNonAlloc(transform.position, detectionRadius, _colliders, groundLayer);
            if (colNum > 0)
            {
                return true;
            }

            return false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,detectionRadius);
    }
}
