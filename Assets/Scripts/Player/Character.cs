using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character : MonoBehaviour
{

    CharacterController controller;
    Animator animator;

    private float hitCooldown;
    /*
    public float HitCooldown
    {
        get { return hitCooldown; }
    }
    */

    GameObject redFlashObject;
    Image image;

    private AudioSource[] audioSources;

    [SerializeField] private float health;
    public float Health
    {
        get { return health; }
        set
        {
            if (hitCooldown <= 0)
            {
                health = value;
                if (health == 0 && transform.tag == "Enemy")
                {
                    //Play Audio
                    //isDead = true;
                    //Invoke("PlayParticle", 1f);
                    //Invoke("RemoveObject", 2f);
                }
                else if (health <= 0 && transform.tag == "Player")
                {
                    //Play animation
                    //cameraScript = playerCamera.GetComponent<CameraScript>();
                    //cameraScript.DeathCamera();
                    //PlayAudio(1);
                }
            }
        }
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

        redFlashObject = GameObject.Find("PauseMenu").transform.Find("RedFlash").gameObject;
        image = redFlashObject.GetComponent<Image>();

        // Making a clone of the weapon to prevent you from changing the prefab when in run time
        for (int i = 0; i < items.Length; i++) {
			if (items [i] != null)
				giveItem (Instantiate (items [i]), i);
		}

		SelectedItem = 0;
    }

    protected virtual void FixedUpdate()
    {
        hitCooldown--;
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

        if (image.color.a > 0)
        {
            image.color = new Color(255,0,0,image.color.a-0.005f);
        }
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

    public void Knockback(Transform input)
    {
        //transform.localPosition -= transform.InverseTransformDirection(transform.forward) * 2f;
        if (hitCooldown <= 0)
        {
            if (transform.tag == "Player")
            {
                controller.Move((Vector3.MoveTowards(Vector3.zero, input.forward, 10f)));
                int randomHitAudio = Random.Range(1, 3);
                FlashScreenRed();
                PlayAudio(randomHitAudio);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, input.up, 10f);
                //Play audio
                //Test knockback on enemy
            }
        }
        hitCooldown = 50;
    }

    private void FlashScreenRed()
    {
        GameObject redFlashObject = GameObject.Find("PauseMenu").transform.Find("RedFlash").gameObject;
        Image image = redFlashObject.GetComponent<Image>();
        image.color = new Color(255f,0f,0f,0.25f);
    }

    //Play a Death sound once the Enemy / Player dies
    private void PlayAudio(int input)
    {
        audioSources = GetComponents<AudioSource>();
        audioSources[input].Play();
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