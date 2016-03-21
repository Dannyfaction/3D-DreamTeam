using UnityEngine;
using System.Collections;

public class PlayerControl : Character
{

    Vector3 inputDelta = new Vector3();
    Transform camera;

    ControllerScript Joystick;

    private float Move_X;
    private float Move_y;


    // Use this for initialization
    void Start()
    {
        Joystick = GetComponent<ControllerScript>();
        camera = Camera.main.transform.parent.transform;
        base.Start();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Move_X = Joystick.LeftStick_X * moveSpeed;
        Move_y = Joystick.LeftStick_Y * moveSpeed;

        inputDelta = new Vector3(Move_X, 0, -Move_y);

        // Read the Inputs
        inputDelta = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        // Give the commands
        Move(transform.position - camera.TransformDirection(inputDelta * -1));

        if (Input.GetButtonDown("Fire1"))
            useTool(transform.Find("Weapon").GetComponent<WeaponScript>());

        // Fire Fixed update
        base.FixedUpdate();
    }
}