using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour
{

    PlayerScript player;

    private float leftStick_X;
    private float leftStick_Y;
    private float rightStick_X;
    private float rightStick_Y;
    private float rightTrigger;
    private float leftTrigger;
    private float A;

    void Start()
    {
        player = GetComponent<PlayerScript>();
    }


    //Getters and Setters for the Controller to use in other scripts
    public float LeftStick_Y
    {
        get { return leftStick_Y; }
        set { leftStick_Y = value; }
    }

    public float LeftStick_X
    {
        get { return leftStick_X; }
        set { leftStick_X = value; }
    }

    public float RightStick_X
    {
        get { return rightStick_X; }
        set { rightStick_X = value; }
    }

    public float RightStick_Y
    {
        get { return rightStick_Y; }
        set { rightStick_Y = value; }
    }

    public float RightTrigger
    {
        get { return rightTrigger; }
        set { rightTrigger = value; }
    }

    public float LeftTrigger
    {
        get { return leftTrigger; }
        set { leftTrigger = value; }
    }

    void Update()
    {
        //Gets LeftJoyStickX and LeftJoystickY from the Unity Inputmanager
        leftStick_X = Input.GetAxis("LeftJoystickX");
        leftStick_Y = Input.GetAxis("LeftJoystickY");

        //Gets RightJoystickX and RightJoystickY from the Unity Inputmanager
        rightStick_X = Input.GetAxis("RightJoystickX");
        rightStick_Y = Input.GetAxis("RightJoystickY");

        //rightTrigger = Input.GetAxis("RightTrigger");
        //leftTrigger = Input.GetAxis("LeftTrigger");

        //Gets A from the Unity Inputmanager (A is the green button on the Xbox Controller)
        A = Input.GetAxis("A");
    }
}