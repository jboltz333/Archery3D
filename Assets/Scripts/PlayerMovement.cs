using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private Transform bow;
    private Transform arrow;
    private float forwardDist = 0.6f;
    private float rightDist = 0.5f;
    private GameObject gameOverScreen;
    private CountdownTimer countdownTimer;

    private void Start()
    {
        // Initially set our game over screen to inactive
        gameOverScreen = GameObject.Find("Panel_PlayGame_GameOver");
        gameOverScreen.SetActive(false);

        // Get a reference to the time left object so we can initiate a game over if we hit 0 seconds
        countdownTimer = GameObject.Find("CountdownTimer").GetComponent(typeof(CountdownTimer)) as CountdownTimer;

        playerBody = GetComponent<Rigidbody>();
        jumpVec = new Vector3(0.0f, 3.0f, 0.0f);
        bow = GameObject.Find("Bow").GetComponent<Transform>();
        arrow = GameObject.Find("Arrow").GetComponent<Transform>();
    }

    void Update()
    {
        // This will rotate our view from the x-axis
        transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * rotationSensitivity * Time.deltaTime);

        // This will allow us to move the mouse up and down to adjust where we are looking at in the y-axis
        yRotation += Input.GetAxis("Mouse Y") * rotationSensitivity * Time.deltaTime * -1.0f;
        yRotation = Mathf.Clamp(yRotation, -45, 45);
        playerCamera.localEulerAngles = new Vector3(yRotation, 0.0f, 0.0f);

        // This will keep the bow/arrow in the same spot in front of the camera with the same angle
        bow.position = Camera.main.transform.position + Camera.main.transform.forward * forwardDist  + Camera.main.transform.right * rightDist;
        bow.localEulerAngles = new Vector3(0.0f, -90.0f, -yRotation);
        arrow.position = Camera.main.transform.position + Camera.main.transform.forward * (forwardDist-0.1f) + Camera.main.transform.right * (rightDist-0.1f);
        arrow.localEulerAngles = new Vector3(0.0f, -90.0f, -yRotation-90);

        // This will move our player forward/backwards
        transform.Translate(0, 0, Input.GetAxis("Vertical") * movement * Time.deltaTime);

        // If the user presses the space bar and is on the ground, jump
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            playerBody.AddForce(jumpVec * jumpSpeed, ForceMode.Impulse);

            // Set on ground to false so we can't jump again mid-air
            onGround = false;
        }

        /*// If the timer hits 0, game over
        if (countdownTimer.countdownTime == 0)
        {
            gameOverScreen.SetActive(true);
            var gameOverText = GameObject.Find("Text_PlayGame_GameOver_Info").GetComponent<Text>();
            gameOverText.text = "You ran out of time";

            // Destroy this object so user can't move after game over screen appears
            Destroy(this);
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If we jumped over the edge into the water, activate game over screen with info on why its a game over
        if (collision.gameObject.tag == "Water")
        {
            gameOverScreen.SetActive(true);
            var gameOverText = GameObject.Find("Text_PlayGame_GameOver_Info").GetComponent<Text>();
            gameOverText.text = "You jumped in the water";

            // Destroy this object so user can't move after game over screen appears
            Destroy(this);
        }
        else
        {
            // Checks to make sure we are on the ground so we know if we can jump
            onGround = true;
        }
    }
}