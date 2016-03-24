using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
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
	Vector3 localMove;

    //Vector3 maxMoveSpeed = new Vector3(0.1f, 0, 0.001f);
    Vector3 drag = new Vector3(.5f, 0, 0.1f);
	
	[SerializeField] protected float movementSpeed = 2;
	
	// Inventory
	[SerializeField]
	public Item[] items;
	[SerializeField] int selectedItem;
	protected int SelectedItem {
		get { return selectedItem; }
		set {
			selectedItem = Mathf.Abs(value) % items.Length;
			if (items [selectedItem])
				items [selectedItem].animator = animator;
		}
	}
	
	public void giveItem (Item item, int index) {
		
		items [index] = item;
	}


    // Use this for initialization
    protected virtual void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
		
		// Making a clone of the weapon to prevent you from changing the prefab when in run time
		for (int i = 0; i < items.Length; i++) {
			if (items [i] != null)
				giveItem (Instantiate (items [i]), i);
		}

		SelectedItem = 0;
    }

    protected virtual void FixedUpdate()
    {
		if (items [selectedItem])
			items [selectedItem].UpdateTool();
		
        animator.SetFloat("Forward", moveDirection.z);
        animator.SetFloat("Turn", moveDirection.x);

		if (!animator.applyRootMotion) {
			controller.Move (transform.TransformDirection (Vector3.Scale(moveDirection, Vector3.forward)) * Time.deltaTime  * movementSpeed);
			transform.Rotate (new Vector3(0, moveDirection.x * 2, 0) * movementSpeed);
		}
		
		//transform.LookAt (transform.position + transform.TransformDirection (localMove));// Rotate (new Vector3(0, localMove.x, 0) * movementSpeed);
		transform.Rotate (new Vector3(0, localMove.x * 2, 0) * movementSpeed);
		
        moveDirection -= Vector3.Scale(moveDirection, new Vector3(0.1f, 0, Mathf.Abs(moveDirection.sqrMagnitude - 2f) * 0.01f));
        controller.Move(Physics.gravity * Time.deltaTime);


		/*
        if (health == 0)
        {
            Invoke("RespawnCharacter", 8f);
        }
        //Debug.Log (moveDirection.sqrMagnitude);
		*/
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

        ///////////////////////////////////////////////
        //cameraScript.CameraReset(checkpointRotation);
        //health = 100;
        //Fix animations
    }
	
	// Move the character towards a world position or waypoint
	protected void Move (Vector3 worldPos) {

		localMove = Vector3.Scale (transform.InverseTransformPoint(worldPos), transform.localScale);
		if (localMove.z < 0) {
			localMove.z = 0;
			localMove.x += localMove.z * (localMove.x > 0 ? 1f : -1f);
		}
		moveDirection += Vector3.Scale(localMove, drag) * Mathf.Abs(moveDirection.sqrMagnitude - 1);
	}

	// Tell the character you want it to attack and what move of his weapon he should use
	protected void useSelectedItem(int toolMove) {

		//Debug.Log ("firing tool");
		if (items [selectedItem])
			items [selectedItem].use (transform, toolMove);
	}

	/*
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
	*/
}