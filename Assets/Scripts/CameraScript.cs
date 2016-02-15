using UnityEngine;
using UnityEditor;
using System.Collections;

public class CameraScript : MonoBehaviour
{

    [SerializeField]
    public GameObject target = null;

    public float speed;
    void Start()
    {

    }

    void Update()
    {
        Camera.main.transform.LookAt(target.transform);

        if (Input.GetKey("z"))
        {
            transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * speed);
        }
        if (Input.GetKey("x"))
        {
            transform.RotateAround(target.transform.position, Vector3.down, Time.deltaTime * speed);
        }


    }
}
