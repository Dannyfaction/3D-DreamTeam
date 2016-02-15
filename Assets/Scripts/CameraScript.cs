using UnityEngine;
using UnityEditor;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    ControllerScript Joystick;

    [SerializeField]
    public GameObject target = null;

    public float speed;
    //float that makes sure wich way it goes
    public float look;
    // Use this for initialization
    void Start()
    {
        Joystick = GameObject.Find("Player").GetComponent<ControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);

        look = Joystick.RightStick_X;

        if (look == 1)
        {
            transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * speed);
        }
        if (look == -1)
        {
            transform.RotateAround(target.transform.position, Vector3.down, Time.deltaTime * speed);
        }


    }




    /* void Update()
     {

   */
}
