using UnityEngine;
using UnityEditor;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    ControllerScript Joystick;

    [SerializeField]
    public GameObject target = null;

    public float speed;
    public float look;

    private float deathSpeed;
    private float timer;
    
    void Start()
    {
        Joystick = GameObject.Find("Player").GetComponent<ControllerScript>();
    }

    void Update()
    {
        //Focuses the Camera on the Player
        Camera.main.transform.LookAt(target.transform);

        //From the Inputmanager
        look = Joystick.RightStick_X;

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

        //For Keyboard use
        if (Input.GetKey("z"))
        {
            transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * speed);
        }
        if (Input.GetKey("x"))
        {
            transform.RotateAround(target.transform.position, Vector3.down, Time.deltaTime * speed);
        }
    }

    //camera movement for gameover
    public void DeathCamera() {
        timer = 10;
        while(timer < 10)
        {
            Camera.main.transform.LookAt(target.transform);
            transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * speed);
            timer++;
        }
    }
}
