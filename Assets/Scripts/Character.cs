using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	CharacterController controller;
	Animator animator;

	Vector3 moveDirection = new Vector3();

	//Vector3 maxMoveSpeed = new Vector3(0.1f, 0, 0.001f);
	Vector3 drag = new Vector3(.5f, 0, 0.1f);


	// Use this for initialization
	protected virtual void Start () {
		
		controller = GetComponent<CharacterController> ();
		animator = GetComponent<Animator> ();
	}

	protected virtual void FixedUpdate() {

		animator.SetFloat ("Forward", moveDirection.z * 2);
		animator.SetFloat ("Turn", moveDirection.x * 2);


		moveDirection -= Vector3.Scale(moveDirection, new Vector3(0.1f, 0, Mathf.Abs(moveDirection.sqrMagnitude - 2f) * 0.01f));
		//Debug.Log (moveDirection.sqrMagnitude);
	}


	protected void Move (Vector3 inputDelta) {

		Vector3 localMove = transform.InverseTransformPoint(inputDelta);
		if (localMove.z < 0) {
			localMove.z = 0;
			localMove.x += localMove.z * (localMove.x > 0 ? 1f : -1f);
		}

		//moveDirection = localMove;
		moveDirection += Vector3.Scale(localMove, drag) * Mathf.Abs(moveDirection.sqrMagnitude - 1);
	}
}
