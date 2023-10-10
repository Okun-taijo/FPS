using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeeleAttack : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable damageble))
        {
            Debug.Log(other);
            damageble.TakeDamage(_damage);
        }
    }
}
