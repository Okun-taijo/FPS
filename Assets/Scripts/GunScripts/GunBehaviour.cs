using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    
    [SerializeField] private Transform _startBulletPosition;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _summaryAmmo;
    [SerializeField] private float _clipAmmo;
    [SerializeField] private float _currentAmmo;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _timeToShot;
    [SerializeField] private float _startTimeToShoot;
    [SerializeField] private Camera _aimCamera;
    [SerializeField] private float _spread;
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _muzzle;
    [SerializeField] private Transform _startMuzzlePosition;
    [SerializeField] private TextMeshProUGUI _ammoCounter;


    private bool _isReloading = false;
    private Ray _findCenter;
    private Vector3 _directionWithSpread;

    private void Start()
    {
        _currentAmmo = _clipAmmo;
        _ammoCounter.text = _currentAmmo + "/" + _summaryAmmo;
    }
    private void Update()
    {
        AmmoCounter();
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) || _currentAmmo==0)
        {
            Reload();
        }
    }
    private void RaycastToCrosshair()
    {
        _findCenter = _aimCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit _hit;
        Vector3 targetPoint;

        if (Physics.Raycast(_findCenter, out _hit))
        {
            targetPoint = _hit.point;

        }
        else
        {
            targetPoint = _findCenter.GetPoint(75);
        }

        float x = Random.Range(-_spread, _spread);
        float y = Random.Range(-_spread, _spread);

        _directionWithSpread = targetPoint - _startBulletPosition.position + new Vector3(x, y, 0);
       // return _directionWithSpread;
    }
    private void Shoot()
    {
        AmmoCounter();
        if (_isReloading == false)
        {
            if (_currentAmmo > 0)
            {
                if (_timeToShot < Time.time) 
                {
                    RaycastToCrosshair();
                    Instantiate(_bulletPrefab, _startBulletPosition.position, _startBulletPosition.rotation);
                    Instantiate(_muzzle, _startMuzzlePosition.position, _startMuzzlePosition.rotation);
                    _currentAmmo -= 1;
                    _timeToShot = Time.time + _startTimeToShoot;
                    
                }
            }
        }
    }

    private IEnumerator Reloading()
    {
        _isReloading = true;
        _animator.SetBool("reload", true);
        yield return new WaitForSeconds(_reloadTime);
        _animator.SetBool("reload", false);
        _isReloading = false;
    }
    private void Reload()
    {
        if (_summaryAmmo > 0)
        {
            StartCoroutine(Reloading());
            
            if (_summaryAmmo >= _clipAmmo && _currentAmmo != _clipAmmo)
            {
                _currentAmmo = _clipAmmo;
                _summaryAmmo -= _currentAmmo;
            }
            if (_summaryAmmo < _clipAmmo)
            {
                _currentAmmo = _summaryAmmo;
                _summaryAmmo = 0;
            }
        }
       
    }

    public void AddAmmos(int ammos)
    {
        _summaryAmmo += ammos;
       
    }
    private void AmmoCounter()
    {
        _ammoCounter.text = _currentAmmo + "/" + _summaryAmmo;
    }
}
