using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour
{

    Transform camHolder;
    public Transform target; //This is the target the camera will attempt to follow
    [SerializeField]
    Vector2 offset; //This is the forward and up offset of the camera
    [SerializeField]
    float camDrag; //This drag amount should determine how much the LookAt should lerp
    Vector3 oldPosition;
    [SerializeField]
    ControllerScript controllerScript;

    // Use this for initialization
    void Start()
    {
        camHolder = transform.parent.transform;
        transform.position = transform.position + offset.y * Vector3.up;
        oldPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (target)
        {
            if (oldPosition == null)
            {
                oldPosition = target.position;
            }
            camHolder.position += Vector3.Scale(transform.right, Vector3.right + Vector3.forward) * Input.GetAxis("Mouse X") * -target.lossyScale.x * 0.25f;
            camHolder.position += Vector3.Scale(transform.right, Vector3.right + Vector3.forward) * controllerScript.RightStick_X * -target.lossyScale.x * 1f;
            transform.LookAt(oldPosition);
            camHolder.position += ((oldPosition + (transform.forward * offset.x) - camHolder.position) * 1);
            camHolder.position -= new Vector3(0, camHolder.position.y - oldPosition.y, 0);

            oldPosition += (target.position - oldPosition) * 0.1f;
        }
    }
}