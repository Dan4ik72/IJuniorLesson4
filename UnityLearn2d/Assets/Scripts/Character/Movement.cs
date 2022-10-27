using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;
    
    private float _currentPositionChanging;

    public bool IsRunning => _currentPositionChanging != 0;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();      
    }

    private void Update()
    {
        float startXPosition = transform.position.x;

        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;

            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;

            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        }

        _currentPositionChanging = startXPosition - transform.position.x;
    }   
}
