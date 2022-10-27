using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            transform.Translate(_speed * Time.deltaTime, 0, 0);

            _spriteRenderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);

            _spriteRenderer.flipX = true;
        }

        _currentPositionChanging = startXPosition - transform.position.x;
    }   
}
