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


    float horizontal;
    float vertical;
    public float speed;



    // playerholders

    Vector2 mouseLook;
    Vector2 smoothV;

    public GameObject character;
    public CharacterController characterController;
    private Camera cameraObject;

    //A boolean value that will tell you if you are within .1 Unity Unit from the ground
    private bool is_grounded;
    //The rigid body attached to the player
    private Rigidbody body;
    //how close are we to a wall on our left side
    private float distance_to_wall_left = 2f;
    //how close are we to a wall on our right side
    private float distance_to_wall_right = 2f;
    //how close are we to a wall going forward
    private float distance_to_wall_forward = 2f;
    //how close are we to a wall going backwards
    private float distance_to_wall_back = 2f;

    //Start is a function that is called once when the object is Instatiated. 
    void Start()
    {
        // set up camera
        cameraObject = character.transform.Find("Main Camera").GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        body = GetComponent<Rigidbody>();

        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
    }

    // Update is a function that is called once per frame
    void Update()
    {
        Move();
        CameraUpdate();
    }



    /// <summary>
    /// allows player to move based on the player's input
    /// </summary>
    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);
    }


    /// <summary>
    /// called whenever update is called
    /// handles the functionality of the player's camera
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
