using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Animator))]
public class MovementAnimation : MonoBehaviour
{
    private readonly int _isRunningHash = Animator.StringToHash("IsRunning");

    private Animator _animator;    
    private Movement _movement;
    
    private void Start()
    {
        _movement = GetComponent<Movement>();
        _animator = GetComponent<Animator>();
    }
             
    private void Update()
    {  
        _animator.SetBool(_isRunningHash, _movement.IsRunning);
    }
}
