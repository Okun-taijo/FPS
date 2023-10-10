using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : PowerUp
{
    [SerializeField] private int _health;

    protected override void Activate(GameObject player)
    {
        if (player.TryGetComponent(out PlayerHealth health))
        {
            health.AddHealth(_health);
        }
    }
}
