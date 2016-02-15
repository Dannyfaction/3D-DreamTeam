using UnityEngine;
using System.Collections;

public class PlayerScript : Humanoid {

    ControllerScript Joystick;

    Vector3 moveDelta = new Vector3();

    private float Move_X;
    private float Move_y;

    Animator characterAnimator;
    

    void Start()
    {
        Joystick = GetComponent<ControllerScript>();

        Controller = transform.GetComponent<CharacterController>();
        characterAnimator = GetComponentInChildren<Animator>();
    }


	
	// Update is called once per frame
	void Update()
    {

        Move_X = Joystick.LeftStick_X * moveSpeed;
        Move_y = Joystick.LeftStick_Y * moveSpeed;

        //Move Input detection

        moveDelta = new Vector3(Move_X, 0, -Move_y);
        //Move Input detection
	    //moveDelta = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //[NOTE] GetAxis method Will be replaced by a keybinding class when it's availible


        //Velocity change
        move(moveDelta);



        //Action Input detection
        if (Input.GetButtonDown("Fire1")) //[NOTE] if statement Will be replaced by a keybinding class when it's availible
        {
            Debug.Log("Firing");

            useTool();
        }
    }
}
