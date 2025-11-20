using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareCamera : MonoBehaviour
{

    public Manager manager;


    void Start()
    {
        manager = FindObjectOfType<Manager>();
    }


    void Update()
    {

        if (Manager.GameIsPaused == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        else
        {
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }

            else
            {
                // Lock and Hide the Cursor
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

    }
}
