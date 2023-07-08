using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(RobotStateMachine))]
[RequireComponent(typeof(CharacterController))]
public class RobotController : MonoBehaviour
{
    //I don't know why the value should be as this large when moving on ground, but small when moving in air.
    //Perhaps this is how character controller component works
    // Strange, but keep in mind.
    [SerializeField] public float moveSpeed = 5f;//ground move
    [SerializeField] public float turnSpeed = 5f;//ground turn
    [SerializeField] public float jumpPower = 5f;//jump force
    [SerializeField] public float jumpMoveSpeed = 5f;//air move
    [SerializeField] public float gravity = 9.8f;//simulating gravity, working when jumping


    private Collider _collider;
    
    private Rigidbody _rigidbody;
    //public Vector3 CurrentVelocity => _rigidbody.velocity;

    public bool IsGrounded => _characterController.isGrounded;
    public AudioSource audioPlayer;

   

    private CharacterController _characterController;

    private void Awake()
    {
        //_collider = GetComponent<Collider>();
        //_rigidbody = GetComponent<Rigidbody>();
        if (audioPlayer == null)
        {
            audioPlayer = GetComponent<AudioSource>();
        }
        
        _characterController = GetComponent<CharacterController>();
        

        audioPlayer.playOnAwake = false;
    }

    private void Update()
    {
        //transform.Rotate(Vector3.up,turnSpeed * Time.deltaTime);
    }

    //Functions used for moving
    public void SetVelocity(Vector3 velocity)
    {
        //_rigidbody.velocity = velocity;
    }

    /// <summary>
    /// We just need to walk in one direction
    /// </summary>
    /// <param name="speed"></param>
    public void MoveForward(float dir)
    {
        //_rigidbody.velocity = new Vector3(0, 0, speed);
        _characterController.SimpleMove(moveSpeed*dir*Time.deltaTime*transform.forward);
        
    }

    public void JumpMove(Vector3 jumpMove)
    {
        
        _characterController.Move(jumpMove * Time.deltaTime);
    }

    

    /// <summary>
    /// Call this when jump up
    /// </summary>
    /// <param name="jumpPower"></param>
    public void SetJumpForce(float jumpPower)
    {
        //_rigidbody.AddForce(0,jumpPower,0);
    }

    /// <summary>
    /// Call when turning
    /// </summary>
    /// <param name="rotate"></param>
    public void RotateY(float dir)
    {
        //transform.Rotate(0,rotate,0);
        
        transform.Rotate(Vector3.up,dir * Time.deltaTime * turnSpeed);
    }

    //Functions used for sound effects
    public void PlaySoundOnce(AudioClip clip, float volume)
    {
        audioPlayer.PlayOneShot(clip,volume);
    }

    public void PlaySoundLoop(AudioClip clip, float volume)
    {
        audioPlayer.clip = clip;
        audioPlayer.loop = true;
        audioPlayer.volume = volume;
        audioPlayer.Play();
    }
    /// <summary>
    /// Call this when exiting each function if you used PlaySoundLoop
    /// </summary>
    public void ResetSoundPlayer()
    {
        audioPlayer.clip = null;
        audioPlayer.loop = false;
        audioPlayer.volume = 1.0f;
    }

    
    
}
