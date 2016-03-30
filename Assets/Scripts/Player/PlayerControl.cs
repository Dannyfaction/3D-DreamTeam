using UnityEngine;
using System.Collections;

public class PlayerControl : Character
{

    Vector3 inputDelta = new Vector3();
    Transform camera;
    private GameObject pauseObject;

    ControllerScript Joystick;

    private float Move_X;
    private float Move_y;

    private int currentCheckpoint = 0;
    public int CurrentCheckpoint
    {
        get { return currentCheckpoint; }
        set { currentCheckpoint = value; }
    }

    void Start()
    {
        Joystick = GetComponent<ControllerScript>();
        camera = Camera.main.transform;
        pauseObject = GameObject.Find("PauseMenu").transform.Find("Menu").gameObject;
        base.Start();
    }

    void FixedUpdate()
    {
        if (Health == 0)
        {
            Invoke("RespawnCharacter", 8f);
        }

        Move_X = Joystick.LeftStick_X * movementSpeed;
        Move_y = Joystick.LeftStick_Y * movementSpeed;

        inputDelta = new Vector3(Move_X, 0, -Move_y);

        // Read the Inputs
        inputDelta = new Vector3(Input.GetAxisRaw( "Horizontal" ), 0, Input.GetAxisRaw( "Vertical" ));

        // Give the commands
        //Move(transform.position - transform.TransformDirection(inputDelta * -1));
		
		Move (transform.position - Vector3.Scale(camera.TransformDirection(inputDelta * -1), new Vector3(1, 0, 1)).normalized);

        if (Input.GetButtonDown("Fire1")){
            //useTool(transform.Find("Weapon").GetComponent<WeaponScript>());
			useSelectedItem (0);
		}

        /*
		if (Input.GetKeyDown(KeyCode.C)){
			SelectedItem += 1;
		}
        */

        //Pause the game once start button on controller has been pressed
        //For Controller Use
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

        if (Input.GetKey("l"))
        {
            
        }

        //For Keyboard Use
        if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseObject.SetActive(false);
        }

        // Fire Fixed update
        base.FixedUpdate();
    }

    private void RespawnCharacter()
    {
        Vector3 checkpointPosition;
        Quaternion checkpointRotation;
        switch (currentCheckpoint)
        {
            case 1:
                checkpointPosition = new Vector3(-394.39f, 0, -105f);
                checkpointRotation = Quaternion.identity;
                break;
            case 2:
                checkpointPosition = new Vector3(-280.2f, 0, 15.52f);
                checkpointRotation = Quaternion.Euler(0, 90, 0);
                break;
            case 3:
                checkpointPosition = new Vector3(-58.8f, 0, -31.9f);
                checkpointRotation = Quaternion.Euler(0, 90, 0);
                break;
            default:
                checkpointPosition = new Vector3(-605.14f, 0f, -272f);
                checkpointRotation = Quaternion.Euler(0, 90, 0);
                break;
        }
        transform.position = checkpointPosition;
        transform.rotation = checkpointRotation;

        ///////////////////////////////////////////////
        //cameraScript.CameraReset(checkpointRotation);
        Health = 100;
        //Fix animations
    }
}