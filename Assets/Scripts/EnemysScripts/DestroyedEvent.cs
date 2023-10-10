using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedEvent : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public void Activate()
    {
        _animator.SetTrigger("Death");
    }

}