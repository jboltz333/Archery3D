using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movement = 2.0f;
    private float rotationSensitivity = 200.0f;
    private float yRotation = 0.0f;
    public Transform playerCamera;

    void Update()
    {
        // This will rotate our view from the x-axis
        transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * rotationSensitivity * Time.deltaTime);

        // This will allow us to move the mouse up and down to adjust where we are looking at in the y-axis
        yRotation += Input.GetAxis("Mouse Y") * rotationSensitivity * Time.deltaTime * -1.0f;
        yRotation = Mathf.Clamp(yRotation, -45, 45);
        playerCamera.localEulerAngles = new Vector3(yRotation, 0.0f, 0.0f);

        // This will move our player forward/backwards
        transform.Translate(0, 0, Input.GetAxis("Vertical") * movement * Time.deltaTime);
    }
}