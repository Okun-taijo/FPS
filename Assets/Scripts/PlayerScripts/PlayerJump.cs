using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody _playerRb;
    private bool _onJump = false;
    private bool _isGrounded=false;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag=="Ground")
        {
            _isGrounded = true;
            _onJump = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag=="Ground")
        {
            _isGrounded = false;
            _onJump = true;
        }
    }
    private void Jump()
    {

        if(_isGrounded==true || _onJump==true)
         _playerRb.AddForce(Vector2.up*_jumpForce, ForceMode.Impulse);
        _onJump = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
       
    }
}
