using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move: MonoBehaviour
{
    [SerializeField] public float _speed = 8f; 

    private Vector2 _moveInput;
    private Vector2 _smoothMovenment;
    private Vector2 _smoothVelocity;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

   

    private void Start()
    {
        _smoothMovenment = Vector2.SmoothDamp(_smoothMovenment, _moveInput, ref _smoothVelocity, 0.3f);
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
     private void SetLookDirection()
   {
     
   }

   private void FixedUpdate()
   {
       _rigidbody.velocity = _moveInput * _speed;
       SetLookDirection();
   }

    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    
}
