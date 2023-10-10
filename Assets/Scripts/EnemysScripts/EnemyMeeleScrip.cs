using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMeeleScrip : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _enemyAgent;
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private float _distance;
    [SerializeField] private float _actionDistance;
    [SerializeField] private float _attackDistance;
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _attackTrigger;
    

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
            if (_distance < _actionDistance && _distance > _attackDistance)
            {
                Catching();
                
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
            _enemyAnimator.SetTrigger("Runing");
        }
    }

    private void Attack()
    {
        _enemyAgent.enabled = false;
        _enemyAnimator.SetTrigger("Attack");
      //  _attackTrigger.SetActive(true);
      

    }
}
