using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShooter : MonoBehaviour
{
    private int _shootCount=0;
    [SerializeField] private NavMeshAgent _enemyAgent;
    [SerializeField] private Animator _enemyAnimator;
    private float _distance;
    [SerializeField] private float _actionDistance;
    [SerializeField] private float _attackDistance;
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _attackTrigger;
    [SerializeField] private float _shootDistance;
    [SerializeField] private GameObject _shootTrigger;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private float _timeToShoot;
    [SerializeField] private float _startTimeToShoot;


    // Update is called once per frame
    void Update()
    {
        if (_target != null)
        {

            _distance = Vector3.Distance(_target.position, transform.position);
            if (_distance > _actionDistance)
            {
                Idle();

            }
            if (_distance < _actionDistance && _distance > _shootDistance)
            {
                Catching();

            }
            if (_distance <= _shootDistance+1 && _distance>_attackDistance)
            {
                Shoot();

            }
            if (_distance <= _attackDistance)
            {
                Attack();
            }
        }
        else
        {
            Idle();

        }


    }
    private void Idle()
    {
        _enemyAgent.enabled = false;
        // _attackTrigger.SetActive(false);
        _enemyAnimator.SetTrigger("Idle");
    }

    private void Catching()
    {
        if (_target != null)
        {
            _enemyAgent.enabled = true;
            //  _attackTrigger.SetActive(false);
            _enemyAgent.SetDestination(_target.position);
            _enemyAnimator.SetTrigger("Running");
        }
    }

    private void Attack()
    {
        _enemyAgent.enabled = false;
        _enemyAnimator.SetTrigger("Attack");
        //  _attackTrigger.SetActive(true);
    }
    private void Shoot()
    {
        _enemyAgent.enabled = true;
        _enemyAgent.SetDestination(_target.position);
       
        _enemyAnimator.SetTrigger("Shoot");
        forFirstShot();
        if (_timeToShoot < Time.time) 
        {

            if (_shootCount == 0)
            {
                
               
                Instantiate(_shootTrigger, _shootPosition.position, _shootPosition.rotation);
                _timeToShoot = Time.time + _startTimeToShoot;
                _shootCount++;
            }
            else
            {
                
                Instantiate(_shootTrigger, _shootPosition.position, _shootPosition.rotation);
                _timeToShoot = Time.time + _startTimeToShoot;
            }
        }
       


    }
    private IEnumerator forFirstShot()
    {
        
        yield return new WaitForSeconds(3.8f);
       
    }
}
