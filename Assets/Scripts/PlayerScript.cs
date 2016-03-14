using UnityEngine;
using System.Collections;

public class PlayerScript : Humanoid {

    Vector3 moveDelta = new Vector3();
    Animator characterAnimator;
    private GameObject cameraObject;
    private GameObject healthObject;
	private GameObject pauseObject;
	private GameObject pauseObject1;
	private GameObject pauseObject2;
	private GameObject pauseObject3;

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
		pauseObject = GameObject.Find ("PauseMenu").transform.Find("Menu").gameObject;
		pauseObject1 = GameObject.Find ("PauseMenu").transform.Find("Sound (Menu)").gameObject;
		pauseObject2 = GameObject.Find ("PauseMenu").transform.Find("Graphics (Menu)").gameObject;
		pauseObject3 = GameObject.Find ("PauseMenu").transform.Find("Options (Menu)").gameObject;
    }

	void Update()
    {
        healthObject.transform.localScale = new Vector3((health/100),0,1);


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

		if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 1)
		{
			Time.timeScale = 0;
			pauseObject.SetActive(true);
		}
		else if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 0)
		{
			Time.timeScale = 1;
			pauseObject.SetActive(false);
			pauseObject1.SetActive(false);
			pauseObject2.SetActive(false);
			pauseObject3.SetActive(false);
		}
    }
}
