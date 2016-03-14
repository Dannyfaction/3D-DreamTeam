using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	CharacterController controller;
	Animator animator;
    private CameraScript cameraScript;
    private GameObject playerCamera;

    private int currentCheckpoint = 0;

    private float health = 100;
    public float Health
    {
        get { return health; }
        set
        {
            health = value;
            if (health == 0)
            {
                //PlayAudio();
                playerCamera = transform.Find("Camera Object").gameObject;
                cameraScript = playerCamera.GetComponent<CameraScript>();
                cameraScript.DeathCamera();
                Invoke("RespawnCharacter",8f);
            }
        }
    }

            Vector3 moveDirection = new Vector3();

	//Vector3 maxMoveSpeed = new Vector3(0.1f, 0, 0.001f);
	Vector3 drag = new Vector3(.5f, 0, 0.1f);


	// Use this for initialization
	protected virtual void Start () {
		
		controller = GetComponent<CharacterController> ();
		animator = GetComponent<Animator> ();
	}

	protected virtual void FixedUpdate() {
		animator.SetFloat ("Forward", moveDirection.z * 2f);
		animator.SetFloat ("Turn", moveDirection.x * 1.5f);

		moveDirection -= Vector3.Scale(moveDirection, new Vector3(0.1f, 0, Mathf.Abs(moveDirection.sqrMagnitude - 2f) * 0.01f));
		//Debug.Log (moveDirection.sqrMagnitude);
	}

    private void RespawnCharacter()
    {
        Vector3 checkpointPosition;
        switch (currentCheckpoint)
        {
            case 0:
                checkpointPosition = new Vector3(-377.43f, 0.48f, -182.47f);
                break;
            default:
                checkpointPosition = new Vector3(-377.43f, 0.48f, -182.47f);
                break;
        }
        transform.position = checkpointPosition;
        transform.rotation = Quaternion.identity;
        cameraScript.CameraReset();
        health = 100;
        //Fix animations
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
