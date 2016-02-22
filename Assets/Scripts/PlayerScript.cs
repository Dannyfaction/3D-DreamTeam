using UnityEngine;
using System.Collections;

public class PlayerScript : Humanoid {

    Vector3 moveDelta = new Vector3();
    Animator characterAnimator;
    private GameObject cameraObject;
    private GameObject healthObject;

    ControllerScript Joystick;

    private float Move_X;
    private float Move_y;


    void Start()
    {
        Joystick = GetComponent<ControllerScript>();
        healthObject = GameObject.Find("Health");
        Controller = transform.GetComponent<CharacterController>();
        characterAnimator = GetComponentInChildren<Animator>();
        cameraObject = GameObject.Find("Camera Object");
    }

	void Update()
    {
        healthObject.transform.localScale = new Vector3((health/100),1,1);

        //From the Inputmanager
        Move_X = Joystick.LeftStick_X * moveSpeed;
        Move_y = Joystick.LeftStick_Y * moveSpeed;

        //Move Input detection
        //For Controller Use
        //moveDelta = new Vector3(Move_X, 0, -Move_y);

        //For Keyboard Use
        moveDelta = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //[NOTE] GetAxis method Will be replaced by a keybinding class when it's availible

        //Velocity change
        move(cameraObject.transform.right * moveDelta.x + cameraObject.transform.forward * moveDelta.z);


        //Animator Boolean
        if (isMoving)
        {
            characterAnimator.SetBool("isWalking", true);
        }
        else
        {
            characterAnimator.SetBool("isWalking", false);
        }

        //Action Input detection
        if (Input.GetButtonDown("Fire1")) //[NOTE] if statement Will be replaced by a keybinding class when it's availible
        {
            Debug.Log("Firing");

            useTool();
        }
    }
}
