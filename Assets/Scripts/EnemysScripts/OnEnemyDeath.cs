using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnemyDeath : MonoBehaviour
{
    public virtual void Activate()
    {
        Destroy(gameObject, 1f);
    }
}