using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

/*
 * Author: [Nguyen, Kanyon & Vrablick, Calihan]
 * Last Updated: [11/16/2023]
 * [Handles the camera movement and physical movement of the player]
 */
public class PlayerMovement : MonoBehaviour
{
    // configurables

    public float sensitivity = 3.0f;
    public float smoothing = 2.0f;


    private float jumpHeight = 1.0f;
    private float gravityValue = -5f;


    public float speed;


    // playerholders

    Vector2 mouseLook;
    Vector2 smoothV;

    public GameObject character;
    public CharacterController characterController;
    private Camera cameraObject;

    //A boolean value that will tell you if you are within .1 Unity Unit from the ground
    private bool isGrounded;
    //The rigid body attached to the player
    private Rigidbody body;

    private Vector3 playerVelocity;


    //Start is a function that is called once when the object is Instatiated. 
    void Start()
    {
        // set up camera
        cameraObject = character.transform.Find("Main Camera").GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        body = GetComponent<Rigidbody>();
    }

    // Update is a function that is called once per frame
    void Update()
    {
        Move();
        Jump();
        CameraUpdate();
    }



    /// <summary>
    /// allows player to move based on the player's input
    /// </summary>
    private void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xInput + transform.forward * zInput;

        characterController.Move(move * speed * Time.deltaTime);


        
        characterController.Move(playerVelocity * Time.deltaTime);
    }





    /// <summary>
    /// handles the jump input as well as the gravitational movement of the player.
    /// </summary>
    private void Jump()
    {
        isGrounded = characterController.isGrounded;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // changes the height position of the player for gravity
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
    }





    /// <summary>
    /// called whenever update is called
    /// handles the functionality of the player's camera
    /// taken from scripts provided by the CADG 180 course.
    /// </summary>
    private void CameraUpdate()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;

        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);
        //s mouseLook.x = Mathf.Clamp(mouseLook.x, -90f, 90f);

        cameraObject.transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
