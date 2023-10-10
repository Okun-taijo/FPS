using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToEnd : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
    public void Pause()
    {
        
        Time.timeScale = 0f;

    }
}
