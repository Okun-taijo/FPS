using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyForward : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _bulletRigidBody;
    void Start()
    {
        Destroy(gameObject, 3f);
        _bulletRigidBody.velocity = transform.TransformDirection(Vector3.forward * _speed);
    }

    
}
