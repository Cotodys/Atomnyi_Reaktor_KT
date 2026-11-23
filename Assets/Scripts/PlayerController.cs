using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    private int _coins = 0;
    private Vector2 _moveInput;
    private Rigidbody _rigidbody;

    private bool _isGrounded;
    [SerializeField] private float _moveSpeed = 5.0f;
    [SerializeField] private float _jumpPlayer = 5.0f;
    [SerializeField] public SphereCollider TriggetSpherePlayer;

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

    private void OnEnable()
    {
        CoinCollector.CoinGet += OnCoinGet;
    }

    private void OnDisable()
    {
        CoinCollector.CoinGet -= OnCoinGet;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCoinGet(int coins)
    {
        _coins = coins;
    }

    private void OnWASD(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    private void OnJump()
    {
            _rigidbody.AddForce(Vector3.up * _jumpPlayer, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        CheckGrounded();
        Move();
        
    }
    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }

    private void Move()
    {
        Vector3 direction = new Vector3(_moveInput.x, 0f, _moveInput.y);
        transform.Translate(direction * _moveSpeed * Time.deltaTime, Space.World);
    }

    private void CheckGrounded()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
