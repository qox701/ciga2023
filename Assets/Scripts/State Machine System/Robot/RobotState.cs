using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Base class for robot states
/// </summary>
public class RobotState : ScriptableObject,IState
{
    //Used to change current animation clip
    public string stateName;
    //anim clip transition
    [SerializeField, Range(0f, 1f)] protected float transitionDuration = 0.1f;
    //Used to find animation quicker
    private int _stateHash;
    
    //Needed Components are declared here 
    protected Animator ThisAnimator;
    protected RobotStateMachine ThisStateMachine;
    protected RobotController ThisController;
    protected InputListener InputSource => MonoSingleton<InputListener>.Instance;
    [SerializeField] protected AudioClip stateSFX;
    
    //Needed variables are declared here
    protected float CurrentWalkSpeed;
    
    //check if animation finished and measure the state duration
    private float _stateStartTime;
    protected float StateDuration => Time.time - _stateStartTime;
    // I suppose we won't need to use more than ONE animator layer
    protected bool IsAnimationFinished => StateDuration >= ThisAnimator.GetCurrentAnimatorStateInfo(0).length;
    protected float AnimationSpeed => ThisAnimator.GetCurrentAnimatorStateInfo(0).speed;

    /// <summary>
    /// Set all needed components as parameters
    /// </summary>
    public void Initialize(RobotStateMachine stateMachine,RobotController controller,Animator animator)
    {
        //Here I dont have an animator
        ThisStateMachine = stateMachine;
        ThisController = controller;
        ThisAnimator = animator;
    }
    
    private void OnEnable()
    {
        _stateHash = Animator.StringToHash(stateName);
    }

    public virtual void Enter()
    {
        //No Animator
        ThisAnimator.CrossFade(_stateHash,transitionDuration);
        _stateStartTime = Time.time;
    }

    public virtual void Exit()
    {
        
    }

    public virtual void FrameUpdate(float dt)
    {
        
    }

    public virtual void PhysicsUpdate()
    {
        
    }
}
