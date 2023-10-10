using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarretAiming : Aiming
{
    [SerializeField] private Camera _sniperCamera;
    [SerializeField] private Camera _mainCamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // _mainCamera.gameObject.SetActive(false);
            _aimAnimator.SetBool("aim", true);
            _aimCrosshair.SetActive(false);
            _sniperCamera.gameObject.SetActive(true);
        }
      if (Input.GetMouseButtonUp(1))
        {
            _aimAnimator.SetBool("aim", false);
            _aimCrosshair.SetActive(true);
            _mainCamera.gameObject.SetActive(true);
            _sniperCamera.gameObject.SetActive(false);
           
        }
    }
    
}
