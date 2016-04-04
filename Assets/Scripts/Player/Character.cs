using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{

    protected CharacterController controller;
    protected Animator animator;

    [SerializeField]
    Transform itemBelt;
    [SerializeField]
    Transform itemHand;

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
			//Put the old item into the item belt (if it exists, otherwise disable the item)
			if (items [selectedItem] && items [selectedItem].itemModel && itemBelt) {
				items [selectedItem].itemModel.transform.parent = itemBelt;
				items [selectedItem].itemModel.transform.localPosition = Vector3.zero;
				items [selectedItem].itemModel.transform.localRotation = new Quaternion();
			} else if (items [selectedItem])
				items [selectedItem].itemModel.SetActive (false);

			//Update the current selected item
			selectedItem = Mathf.Abs(value) % items.Length;

			if (items [selectedItem]) {
				
				items [selectedItem].animator = animator;

				//Put the new item into the item hand
				if (items [selectedItem].itemModel){
					items [selectedItem].itemModel.transform.parent = itemHand;
					items [selectedItem].itemModel.transform.localPosition = Vector3.zero;
					items [selectedItem].itemModel.transform.localRotation = new Quaternion();
					items [selectedItem].itemModel.SetActive (true);
				}
			}
		}
	}
	
	public void giveItem (Item item, int index) {
		
		items [index] = item;
		if (item.itemModel != null && itemBelt != null) {
			item.itemModel.transform.parent = itemBelt;
			item.itemModel.transform.localPosition = Vector3.zero;
		}
	}


    // Use this for initialization
    protected virtual void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        // Making a clone of the weapon to prevent you from changing the prefab when in run time
		for (int i = 0; i < items.Length; i++) {
			
			if (items [i] != null) {

				Item clone = Instantiate (items [i]);
				if (clone.itemModel != null)
					clone.itemModel = Instantiate (clone.itemModel);
				
				giveItem (Instantiate (clone), i);

			}
		}
		SelectedItem = 0;
    }

    protected virtual void FixedUpdate()
    {
		if (items [selectedItem])
			items [selectedItem].UpdateItem();
		
		// Give the Animator controller commands
        animator.SetFloat("Forward", moveDirection.z);
        animator.SetFloat("Turn", moveDirection.x);

		if (!animator.applyRootMotion) {
			controller.Move (transform.TransformDirection (Vector3.Scale(moveDirection, Vector3.forward)) * Time.deltaTime  * movementSpeed);
			transform.Rotate (new Vector3(0, moveDirection.x * 2, 0) * movementSpeed);
		}
		
		//transform.LookAt (transform.position + transform.TransformDirection (localMove));// Rotate (new Vector3(0, localMove.x, 0) * movementSpeed);
		transform.Rotate (new Vector3(0, localMove.x * 2, 0) * movementSpeed);
		
        moveDirection -= Vector3.Scale(moveDirection, new Vector3(0.1f, 0, Mathf.Abs(moveDirection.sqrMagnitude - 2f) * 0.01f));
        controller.Move(Physics.gravity * Time.deltaTime * 3f);
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
}