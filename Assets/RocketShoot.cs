using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShoot : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Transform _start;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Instantiate(_gameObject, _start.transform.position, _start.transform.rotation);
            new WaitForSeconds(2f);
        }
    }
}
