using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] private int weaponNumber = 0;

    private void Start()
    {
        SelectWeapon();
    }
    private void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            UpNumber();
            SelectWeapon();
        }
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapons in transform)
        {
            if (i == weaponNumber)
            {
                weapons.gameObject.SetActive(true);
            }
            else
            {
                weapons.gameObject.SetActive(false);
            }
            i++;
        }
    }

    private void UpNumber()
    {
        if (weaponNumber >= transform.childCount - 1)
        {
            weaponNumber = 0;
            SelectWeapon();
        }
        else
        {
            weaponNumber++;
        }
    }
}
