using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(RobotStateMachine))]
public class RobotController : MonoBehaviour
{


    private Collider _collider;
    
    private Rigidbody _rigidbody;
    public Vector3 CurrentVelocity => _rigidbody.velocity;

    public AudioSource audioPlayer;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        if (audioPlayer == null)
        {
            audioPlayer = GetComponent<AudioSource>();
        }

        audioPlayer.playOnAwake = false;
    }

    //Functions used for moving
    public void SetVelocity(Vector3 velocity)
    {
        _rigidbody.velocity = velocity;
    }

    /// <summary>
    /// We just need to walk in one direction
    /// </summary>
    /// <param name="speed"></param>
    public void MoveForward(float speed)
    {
        _rigidbody.velocity = new Vector3(0, 0, speed);
    }

    /// <summary>
    /// Call this when jump up
    /// </summary>
    /// <param name="jumpPower"></param>
    public void SetJumpForce(float jumpPower)
    {
        _rigidbody.AddForce(0,jumpPower,0);
    }

    /// <summary>
    /// Call when turning
    /// </summary>
    /// <param name="rotate"></param>
    public void RotateY(float rotate)
    {
        //transform.Rotate(0,rotate,0);
        transform.Rotate(Vector3.up,rotate);
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
