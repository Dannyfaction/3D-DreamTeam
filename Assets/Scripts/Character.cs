using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	CharacterController controller;
	Animator animator;
    private CameraScript cameraScript;
    private GameObject playerCamera;

    [SerializeField]
    GameObject CharacterModel;

    //The movement speed of the Humanoid
    [SerializeField]
    protected float moveSpeed = 1;

    private int currentCheckpoint = 0;
    public int CurrentCheckpoint
    {
        get { return currentCheckpoint; }
        set { currentCheckpoint = value; }
    }

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
        Quaternion checkpointRotation;
        switch (currentCheckpoint)
        {
            case 1:
                checkpointPosition = new Vector3(-394.39f,0,-125.7f);
                checkpointRotation = Quaternion.identity;
                break;
            case 2:
                checkpointPosition = new Vector3(-280.2f,0,15.52f);
                checkpointRotation = Quaternion.Euler(0, 90, 0);
                break;
            case 3:
                checkpointPosition = new Vector3(-58.8f,0,-31.9f);
                checkpointRotation = Quaternion.Euler(0, 90, 0);
                break;
            default:
                checkpointPosition = new Vector3(-605.14f, 0f, -272f);
                checkpointRotation = Quaternion.Euler(0, 90, 0);
                break;
        }
        transform.position = checkpointPosition;
        transform.rotation = checkpointRotation;
        cameraScript.CameraReset(checkpointRotation);
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

        /*
        //CharacterModel move rotation
        if (moveDirection.sqrMagnitude > 0)
            CharacterModel.transform.LookAt(CharacterModel.transform.position + moveDirection);
        */
    }
}
