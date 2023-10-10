using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoUp : PowerUp
{
    [SerializeField] private int _ammos;



    protected override void Activate(GameObject player)
    {
        var gun = player.GetComponentInChildren<GunBehaviour>();
        if (gun.TryGetComponent(out GunBehaviour guns))
        {
            guns.AddAmmos(_ammos);
        }
        else
            Debug.Log("Error");
    }
}
