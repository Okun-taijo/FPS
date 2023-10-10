using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersCameraControl : MonoBehaviour
{
    [SerializeField] private float _cameraSensivity;
    private float _xAxis;
    private float _yAxis;
    [SerializeField] private Transform _orientation;
    private float _mouseX;
    private float _mouseY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    private void Update()
    {
        _mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _cameraSensivity;
        _mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _cameraSensivity;

        _yAxis += _mouseX;
        _xAxis -= _mouseY;

        _xAxis = Mathf.Clamp(_xAxis, -90, 90);

        transform.rotation = Quaternion.Euler(_xAxis, _yAxis, 0);
        _orientation.rotation = Quaternion.Euler(0, _yAxis, 0);

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
