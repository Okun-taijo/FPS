using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _movementSpeed = 10f;
    [SerializeField] private Rigidbody _rigidbody;
    private float _directionX;
    private float _directionY;
    private Vector3 _direction;
    [SerializeField] private Transform _orientation;
    [SerializeField] private LayerMask _ground;
    private bool _isGrounded;
    [SerializeField] private float _playerHeight;
    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
    }
    private void Update()
    {
        GroundCheck();
        SpeedControl();
        Inputs();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Inputs()
    {
        _directionX = Input.GetAxisRaw("Horizontal");
        _directionY = Input.GetAxisRaw("Vertical");
    }

    private void Move()
    {
        _direction = _orientation.forward * _directionY + _orientation.right * _directionX;
        if (_isGrounded == true)
        {
            _rigidbody.AddForce(_direction.normalized * _movementSpeed * 100f, ForceMode.Force);
        }
        else
            _rigidbody.AddForce(_direction.normalized * _movementSpeed * 50f, ForceMode.Force);
    }
    private void GroundCheck()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight * 0.5f + 0.3f, _ground);
    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);

        
        if (flatVel.magnitude > _movementSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * _movementSpeed;
            _rigidbody.velocity = new Vector3(limitedVel.x, _rigidbody.velocity.y, limitedVel.z);
        }
    }

}
