using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMove : BulletMove
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;
    [SerializeField] private float _damage;
   // [SerializeField] private float _startSpeed;
   // [SerializeField] private Rigidbody _rigidbody;
   // [SerializeField] private ParticleSystem _particles;

    private void Start()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, _radius);

        for (int i = 0; i < overlappedColliders.Length; i++)
        {
            Rigidbody rigidbody = overlappedColliders[i].attachedRigidbody;
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(_force, transform.position, _radius);
                if (rigidbody.transform.gameObject.TryGetComponent(out IDamageable damageable))
                {
                    damageable.TakeDamage(_damage);
                }
                Explosion explosion = rigidbody.GetComponent<Explosion>();
                if (explosion)
                {
                    new WaitForSeconds(2f);
                    explosion.Explode();
                }
            }

        }
       // Instantiate(_particles);
        //Destroy(gameObject);
    }
}
