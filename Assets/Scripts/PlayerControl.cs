using UnityEngine;
using System.Collections;

public class PlayerControl : Character {

	Vector3 inputDelta = new Vector3();
	Transform camera;

	// Use this for initialization
	void Start () {
		camera = Camera.main.transform.parent.transform;
		base.Start ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// Read the Inputs
		inputDelta = new Vector3(Input.GetAxis( "Horizontal" ), 0, Input.GetAxisRaw( "Vertical" ));


		// Give the commands
		Move (transform.position - camera.TransformDirection(inputDelta * -1));


		// Fire Fixed update
		base.FixedUpdate ();
	}
}
