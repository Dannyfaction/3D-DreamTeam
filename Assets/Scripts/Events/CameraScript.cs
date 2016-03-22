using UnityEngine;
using UnityEditor;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    ControllerScript Joystick;

    [SerializeField] private GameObject target = null;

    //Camera speed
    [SerializeField] private float speed;
    private float look;
    private float lookUp;
    private float upDown;

    private Vector3 initialPosition;

    private bool dead = false;

    //Speed for deathCamera
    private float deathSpeed;
    private float panOut = 0.01f;

    void Start()
    {
        initialPosition = transform.localPosition;
        //UpDown = new Vector3(0, 0, 1);
        upDown = 0.5f;
        Joystick = GameObject.Find("N_ThirdPersonPlayer").GetComponent<ControllerScript>();
    }

    void Update()
    {
        //Focuses the Camera on the Player
        if (transform.Find("Main Camera").gameObject.active)
        {
            Camera.main.transform.LookAt(target.transform);
        }

        //From the Inputmanager

        look = Joystick.RightStick_X;
        lookUp = Joystick.RightStick_Y;

        //For turning the Camera around
        //For Controller use

        if (look == 1)
        {
            transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * speed);
        }
        if (look == -1)
        {
            transform.RotateAround(target.transform.position, Vector3.down, Time.deltaTime * speed);
        }
        Debug.Log(lookUp);
        //For looking up and down with the camera
        if (lookUp == -1 & transform.position.y > target.transform.position.y - 10)
        {
            transform.Translate(0, -upDown, 0);
        }
        if (lookUp == 1 & transform.position.y < target.transform.position.y + 10)
        {
            transform.Translate(0, upDown, 0);
        }

        //For Keyboard use

        if (Input.GetKey("z"))
        {
            transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * speed);
        }
        if (Input.GetKey("x"))
        {
            transform.RotateAround(target.transform.position, Vector3.down, Time.deltaTime * speed);
        }

        if (Input.GetKey("c") & transform.position.y > target.transform.position.y - 10)
        {
            transform.Translate(0, -upDown, 0);
        }
        if (Input.GetKey("v") & transform.position.y < target.transform.position.y + 10)
        {
            transform.Translate(0, upDown, 0);
        }

        if (Input.GetKeyDown("b"))
        {
            Character character = GameObject.Find("N_ThirdPersonPlayer").GetComponent<Character>();
            character.Health -= 20;
        }


        //Pans the camera around the (dead)Player
        if (dead)
        {
            int i = 0;
            transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * deathSpeed);
            while (i < 3 & this.transform.position.y < 25)
            {
                transform.Translate(panOut, panOut, 0);
                i++;
            }
        } 
    }

    void LateUpdate()
    {
        Transform cameraPositionTarget = GameObject.Find("N_ThirdPersonPlayer").transform.Find("CameraPositionTarget");
        // Calculate the current rotation angles
        float wantedRotationAngle = target.transform.eulerAngles.y;
        float wantedHeight = target.transform.position.y + 3f;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        // Damp the rotation around the y-axis
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, 0.6f * Time.deltaTime);

        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, 2f * Time.deltaTime);

        // Convert the angle into a rotation
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        //transform.position -= currentRotation * Vector3.forward * 10f;

        transform.position = Vector3.Lerp(transform.position, new Vector3(cameraPositionTarget.position.x, cameraPositionTarget.position.y, cameraPositionTarget.position.z),5f * Time.fixedDeltaTime); 
        transform.rotation = Quaternion.Euler(0, cameraPositionTarget.eulerAngles.y, 0);
    }

    //camera movement for gameover
    public void DeathCamera()
    {
        deathSpeed = 20;
        Camera.main.transform.LookAt(target.transform);
        dead = true;
    }

    public void CameraReset(Quaternion rotation)
    {
        dead = false;
        transform.localPosition = initialPosition;
        transform.rotation = rotation;
    }
}