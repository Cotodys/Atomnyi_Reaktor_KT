using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(PlayerInput))]
public class PlayerConroller : MonoBehaviour
{
    private Vector2 _moveInput;
    private Rigidbody _rigidbody;
    [SerializeField] private float _moveSpeed = 5.0f;
    [SerializeField] private float _jumpPlayer = 5.0f;

    public float Speed
    {
        get => _moveSpeed;
        set => _moveSpeed = value;
    }

    public float JumpPlayer
    {
        get => _jumpPlayer; 
        set => _jumpPlayer = value;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnWASD(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    private void OnJump()
    {
        if (_rigidbody != null)
        {
            _rigidbody.AddForce(Vector3.up * _jumpPlayer, ForceMode.Impulse);
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = new Vector3(_moveInput.x, 0f, _moveInput.y);
        transform.Translate(direction * _moveSpeed * Time.deltaTime, Space.World);
    }



}
