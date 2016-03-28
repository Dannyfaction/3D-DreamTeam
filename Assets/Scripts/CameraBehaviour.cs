using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour
{

    Transform camHolder;
    public Transform target;
    [SerializeField]
    Vector2 offset;

    // Use this for initialization
    void Start()
    {
        camHolder = transform.parent.transform;
        transform.position = transform.position + offset.y * Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            camHolder.position += transform.right * Input.GetAxis("Mouse ScrollWheel") * target.lossyScale.x * 20f;
            transform.LookAt(target.position);
            camHolder.position = target.position + (transform.forward * offset.x) + (-transform.up * offset.y);
            camHolder.position -= new Vector3(0, camHolder.position.y, 0);
        }
    }
}