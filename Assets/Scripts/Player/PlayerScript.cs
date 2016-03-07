using UnityEngine;
using System.Collections;

public class PlayerScript : Humanoid {

    Vector3 moveDelta = new Vector3();
    Animator characterAnimator;
    private GameObject cameraObject;
    private GameObject healthObject;
    private WeaponScript weaponScript;
    private GameObject pauseObject;
    private float dashCooldown = 100;

    ControllerScript Joystick;

    private float Move_X;
    private float Move_y;


    void Start()
    {
        //weaponScript = transform.Find("Weapon").GetComponent<WeaponScript>();
        weaponScript = GetComponentInChildren<WeaponScript>();
        Joystick = GetComponent<ControllerScript>();
        healthObject = GameObject.Find("Health");
        pauseObject = GameObject.Find("Canvas").transform.Find("Pause").gameObject;
        Controller = transform.GetComponent<CharacterController>();
        characterAnimator = GetComponentInChildren<Animator>();
        cameraObject = GameObject.Find("Camera Object");
    }

	void Update()
    {
        if (healthObject.transform.localScale.x > 0)
        {
            healthObject.transform.localScale = new Vector3((health / 100), 1, 1);
        }

        //From the Inputmanager
        Move_X = Joystick.LeftStick_X * moveSpeed;
        Move_y = Joystick.LeftStick_Y * moveSpeed;

        //Move Input detection
        //For Controller Use
        if (!weaponScript.isAttackingGetSet && Time.timeScale == 1)
        {
            moveDelta = new Vector3(Move_X, 0, -Move_y);
        }

        //For Keyboard Use
        if (!weaponScript.isAttackingGetSet && Time.timeScale == 1)
        {
            moveDelta = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //[NOTE] GetAxis method Will be replaced by a keybinding class when it's availible
        }

        //Velocity change
        if (characterAnimator.GetInteger("AttackState") == 0)
            move(cameraObject.transform.right * moveDelta.x + cameraObject.transform.forward * moveDelta.z);


        //Animator Boolean
        if (isMoving)
        {
            characterAnimator.SetBool("isWalking", true);
        }
        else
        {
            //moveDelta = new Vector3(0,0,0);
            characterAnimator.SetBool("isWalking", false);
        }

        //Action Input detection
        if (Input.GetButtonDown("Fire1")) //[NOTE] if statement Will be replaced by a keybinding class when it's availible
        {
            useTool();
        }

        if (Input.GetAxis("RightTrigger") == 1)
        {
            //Dash
        }


        //Pause the game once start button on controller has been pressed
        if (Input.GetButtonDown("Start") && Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseObject.SetActive(true);
        }
        else if (Input.GetButtonDown("Start") && Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseObject.SetActive(false);
        }
    }
}
