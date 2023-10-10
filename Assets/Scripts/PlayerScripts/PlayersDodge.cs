using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersDodge : MonoBehaviour
{
    [SerializeField] private float _dodgeForce;
    [SerializeField] private Rigidbody _playersRb;
    [SerializeField] private float _dodgeCoolDown;
    private bool _onDodge=false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RightDodge();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            LefttDodge();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ForwardDodge();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            BackDodge();
        }
    }
    private void RightDodge()
    {
        if (_onDodge == false)
        {
            _playersRb.AddForce(Vector3.right*_dodgeForce, ForceMode.Impulse);
            StartCoroutine(Dodgeing());
        }
    }
    private void LefttDodge()
    {
        if (_onDodge == false)
        {
            _playersRb.AddForce(-Vector3.right * _dodgeForce, ForceMode.Impulse);
            StartCoroutine(Dodgeing());
        }
    }
    private void ForwardDodge()
    {
        if (_onDodge == false)
        {
            _playersRb.AddForce(Vector3.forward * _dodgeForce, ForceMode.Impulse);
            StartCoroutine(Dodgeing());
        }
    }
    private void BackDodge()
    {
        if (_onDodge == false)
        {
            _playersRb.AddForce(-Vector3.forward * _dodgeForce, ForceMode.Impulse);
            StartCoroutine(Dodgeing());
        }
    }
    private IEnumerator Dodgeing()
    {
        _onDodge = true;
        yield return new WaitForSeconds(_dodgeCoolDown);
        _onDodge = false;
    }
   
}
