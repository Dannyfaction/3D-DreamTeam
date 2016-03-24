using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	Transform camHolder;
	public Transform target;
	[SerializeField] Vector3 offset;

	// Use this for initialization
	void Start () {
		camHolder = transform.parent.transform;
        //transform.position = offset.y * Vector3.up;
    }
	
	// Update is called once per frame
	void Update () {

		if (target) {
			camHolder.position += transform.right * Input.GetAxis("Mouse ScrollWheel");
			transform.LookAt (target.position);
			camHolder.position = target.position + (transform.forward * offset.x);
			camHolder.position -= new Vector3 (0, camHolder.position.y, 0);
		}
	}
}
