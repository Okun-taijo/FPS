using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealth : ObjectHealth
{
    [SerializeField] private Image _damageEffect;
    [SerializeField]
    private UnityEvent<float> _onHealthCnange;

    protected override void Start()
    {
        base.Start();
        _onHealthCnange.Invoke(GetCurrenHealth());
    }

    public IEnumerator DamageEffectAwake()
    {
        _damageEffect.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _damageEffect.gameObject.SetActive(false);
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        StartCoroutine(DamageEffectAwake());
        
    }
}
