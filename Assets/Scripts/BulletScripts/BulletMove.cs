using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float _timeToDestruction;
    [SerializeField] private float _baseDamage;
    [SerializeField] private float _pointOfReduction;
    [SerializeField] private float _finalDamagePercentage;
    [SerializeField] private float _armorPeneteration;
    [SerializeField] private float _startSpeed;
    [SerializeField] private GameObject _particleHit;
    [SerializeField] private Rigidbody _bulletRigidBody;
    [SerializeField] private AnimationCurve _damageReduction;
    

    private Vector3 _previousStep;
    private float _startTime;
    private float _currentDamage;
    private float _distance;
    private float _currentTime;

    

    private void Awake()
    {
        Destroy(gameObject, _timeToDestruction);
        _bulletRigidBody.velocity = transform.TransformDirection(Vector3.forward * _startSpeed);
        _previousStep = gameObject.transform.position;
        _startTime = Time.time;
        _currentDamage = _baseDamage;
    }

    private void FixedUpdate()
    {
        
        Quaternion currentStep = gameObject.transform.rotation;
        transform.LookAt(_previousStep, transform.up);
        RaycastHit hit = new RaycastHit();
        _distance = Vector3.Distance(_previousStep, transform.position);
        if (_distance == 0f)
        {
            _distance=1e-05f;
        }
       
        if(Physics.Raycast(_previousStep, transform.TransformDirection(Vector3.back), out hit, _distance * 0.9999f) 
            && (hit.transform.gameObject != gameObject))
        {
            Instantiate(_particleHit, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            
            SendDamage(hit.transform.gameObject);
            
        }
        gameObject.transform.rotation = currentStep;
        _previousStep = gameObject.transform.position;
    }
    private float DamageCoefficient()
    {
        float Value = 1;
        _currentTime = Time.time - _startTime;
        Value = _damageReduction.Evaluate(_currentTime / _timeToDestruction);
        //print(Value);
        return (Value);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IPenable penable))
        {
           
            penable.GivePenInfo();
            if (_armorPeneteration >= penable.GivePenInfo())
            {
                _currentDamage -= penable.GivePenInfo();
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void SendDamage(GameObject Hit)
    {
        
        if (Hit.transform.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(_currentDamage * DamageCoefficient());
            
            Destroy(gameObject);
        }
    }
}
