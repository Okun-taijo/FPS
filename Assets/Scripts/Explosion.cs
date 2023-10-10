using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;
  
    [SerializeField] private float _damage;
    [SerializeField] private ParticleSystem _particles;
    public void Explode()
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, _radius);

        for (int i = 0; i < overlappedColliders.Length; i++)
        {
            Rigidbody rigidbody = overlappedColliders[i].attachedRigidbody;
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(_force, transform.position, _radius);
                if(rigidbody.transform.gameObject.TryGetComponent(out IDamageable damageable))
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
        Instantiate(_particles);
        Destroy(gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            {
            Explode();
        }
    }
}
