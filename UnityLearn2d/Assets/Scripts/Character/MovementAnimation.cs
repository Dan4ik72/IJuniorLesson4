using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimation : MonoBehaviour
{
    private Animator _animator;    
    private Movement _movement;

    private void Start()
    {
        _movement = GetComponent<Movement>();
        _animator = GetComponent<Animator>();        
    }
             
    private void Update()
    {  
        _animator.SetBool("IsRunning", _movement.IsRunning);
    }
}
