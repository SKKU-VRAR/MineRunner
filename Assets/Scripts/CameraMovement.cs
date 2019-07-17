using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private bool __mouseMode;
    public float sensitivity;

    private bool mouseMode
    {
        get
        {
            return __mouseMode;
        }

        set
        {
            __mouseMode = value;
            Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }

    void Start()
    {
        mouseMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (__mouseMode)
        {
            Vector3 euler = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
            this.gameObject.transform.Rotate(euler * Time.deltaTime * sensitivity);
        }

        if (Input.GetKeyUp("escape"))
            mouseMode = !mouseMode;
    }
}
