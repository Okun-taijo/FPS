using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerDeath : OnEnemyDeath
{
    [SerializeField] private Camera _onEndCamera;
    public override void Activate()
    {
        _onEndCamera.gameObject.SetActive(true);
        Destroy(gameObject);
    }
}
