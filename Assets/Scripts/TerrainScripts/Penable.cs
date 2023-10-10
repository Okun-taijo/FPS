using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penable : MonoBehaviour, IPenable
{
    [SerializeField] private int _obstacleNeededPen;
  
    public float GivePenInfo() 
    {
        return _obstacleNeededPen;
    }
}
