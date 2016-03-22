using UnityEngine;
using System.Collections;

public class Character : Humanoid
{

    CharacterController controller;
    Animator animator;

    private int currentCheckpoint = 0;
    public int CurrentCheckpoint
    {
        get { return currentCheckpoint; }
        set { currentCheckpoint = value; }
    }


    Vector3 moveDirection = new Vector3();

    //Vector3 maxMoveSpeed = new Vector3(0.1f, 0, 0.001f);
    Vector3 drag = new Vector3(.5f, 0, 0.1f);


    // Use this for initialization
    protected virtual void Start()
    {

        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    protected virtual void FixedUpdate()
    {
        animator.SetFloat("Forward", moveDirection.z * 10f);
        animator.SetFloat("Turn", moveDirection.x * 3f);

        moveDirection -= Vector3.Scale(moveDirection, new Vector3(0.1f, 0, Mathf.Abs(moveDirection.sqrMagnitude - 2f) * 0.01f));
        controller.Move(Physics.gravity * Time.deltaTime);


        if (health == 0)
        {
            Invoke("RespawnCharacter", 8f);
        }
        //Debug.Log (moveDirection.sqrMagnitude);
    }

    private void RespawnCharacter()
    {
        Vector3 checkpointPosition;
        Quaternion checkpointRotation;
        switch (currentCheckpoint)
        {
            case 1:
                checkpointPosition = new Vector3(-394.39f, 0, -105f);
                checkpointRotation = Quaternion.identity;
                break;
            case 2:
                checkpointPosition = new Vector3(-280.2f, 0, 15.52f);
                checkpointRotation = Quaternion.Euler(0, 90, 0);
                break;
            case 3:
                checkpointPosition = new Vector3(-58.8f, 0, -31.9f);
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


    protected void Move(Vector3 inputDelta)
    {

        Vector3 localMove = transform.InverseTransformPoint(inputDelta);
        if (localMove.z < 0)
        {
            localMove.z = 0;
            localMove.x += localMove.z * (localMove.x > 0 ? 1f : -1f);
        }

        //moveDirection = localMove;
        moveDirection += Vector3.Scale(localMove, drag) * Mathf.Abs(moveDirection.sqrMagnitude - 1);

        //CharacterModel move rotation
        if (moveDirection.sqrMagnitude > 0)
            CharacterModel.transform.LookAt(CharacterModel.transform.position + moveDirection);
    }
}