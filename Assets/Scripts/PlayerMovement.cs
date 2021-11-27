using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform playerCamera;
    private float movement = 2.0f;
    private float rotationSensitivity = 200.0f;
    private float yRotation = 0.0f;
    private Rigidbody playerBody;
    private Vector3 jumpVec;
    private float jumpSpeed = 1.0f;
    private bool onGround;
    

    private void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        jumpVec = new Vector3(0.0f, 2.5f, 0.0f);
    }

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

        // If the user presses the space bar and is on the ground, jump
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            playerBody.AddForce(jumpVec * jumpSpeed, ForceMode.Impulse);
            
            // Set on ground to false so we can't jump again mid-air
            onGround = false;
        }
    }

    // Checks to make sure we are on the ground so we know if we can jump
    void OnCollisionStay()
    {
        onGround = true;
    }
}