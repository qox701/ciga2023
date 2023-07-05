using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    /// <summary>
    /// Called when entering a state
    /// </summary>
    void Enter();
    /// <summary>
    /// Called when exiting a state
    /// </summary>
    void Exit();

    /// <summary>
    /// Called each rendering frame(in update)
    /// </summary>
    void FrameUpdate();
    /// <summary>
    /// Called in FixedUpdate
    /// </summary>
    void PhysicsUpdate();
}
