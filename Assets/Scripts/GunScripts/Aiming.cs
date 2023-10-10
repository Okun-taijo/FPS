using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    [SerializeField] protected Animator _aimAnimator;
    [SerializeField] protected GameObject _aimCrosshair;   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _aimAnimator.SetBool("aim", true);
            _aimCrosshair.SetActive(false);
        }
        if (Input.GetMouseButtonUp(1))
        {

            _aimAnimator.SetBool("aim", false);
            _aimCrosshair.SetActive(true);
        }
    }
}
