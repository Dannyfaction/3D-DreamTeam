using UnityEngine;
using System.Collections;

public class PlayerScript : Humanoid {

    ControllerScript Joystick;

    Vector3 moveDelta = new Vector3();

    private float Move_X;
    private float Move_y;
    

    void Start()
    {
        Joystick = GetComponent<ControllerScript>();

        Controller = transform.GetComponent<CharacterController>();
    }


	
	// Update is called once per frame
	void Update()
    {
        Move_X = Joystick.LeftStick_X * moveSpeed;
        Move_y = Joystick.LeftStick_Y * moveSpeed;

        //Move Input detection

        moveDelta = new Vector3(Move_X, 0, -Move_y);
        //[NOTE] GetAxis method Will be replaced by a keybinding class when it's availible



        //Velocity change
        move(moveDelta);
    }
}
