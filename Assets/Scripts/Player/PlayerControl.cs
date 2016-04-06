using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : Character
{

    Vector3 inputDelta = new Vector3();
    Transform camera;
    private GameObject pauseObject;

    private bool isCamEvent;
    public bool IsCamEvent
    {
        set { isCamEvent = value; }
    }

    private bool isDusted;

    [SerializeField] ParticleSystem dashParticle;
    [SerializeField] ParticleSystem dustParticle;

    private float hitCooldown;

    Image image;
    GameObject redFlashObject;

    private AudioSource[] audioSources;

    ControllerScript Joystick;

    private float Move_X;
    private float Move_y;

    private int currentCheckpoint = 0;
    public int CurrentCheckpoint
    {
        get { return currentCheckpoint; }
        set { currentCheckpoint = value; }
    }

    [SerializeField]
    protected float health;
    public float Health
    {
        get { return health; }
        set
        {
            if (hitCooldown <= 0)
            {
                health = value;
                if (health <= 0 && !animator.GetBool("isDead"))
                {
                    animator.SetBool("isDead", true);
                    animator.SetTrigger("onDead");
                    //controller.enabled = false;
                    //Destroy(this.gameObject, 4f);
                }
            }
        }
    }

    void Start()
    {
        Joystick = GetComponent<ControllerScript>();
        camera = Camera.main.transform;
        redFlashObject = GameObject.Find("PauseMenu").transform.Find("RedFlash").gameObject;
        image = redFlashObject.GetComponent<Image>();
        pauseObject = GameObject.Find("PauseMenu").transform.Find("Menu").gameObject;
        base.Start();
    }

    void FixedUpdate()
    {
        Debug.Log(isCamEvent);
        hitCooldown--;
        DustAtFeet();
        if (Health == 0)
        {
            Invoke("RespawnCharacter", 8f);
        }

        Move_X = Joystick.LeftStick_X * movementSpeed;
        Move_y = Joystick.LeftStick_Y * movementSpeed;

            inputDelta = new Vector3(Move_X, 0, -Move_y);

        // Check if the character is using a item or not
		if (items [SelectedItem] == null || !items [SelectedItem].Active) {
			
			// Read the Inputs
			inputDelta = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));

            if (!isCamEvent)
            {
                // Give the commands
                Move(transform.position - Vector3.Scale(camera.TransformDirection(inputDelta * -1), new Vector3(1, 0, 1)).normalized);
            }
                if (Input.GetButtonDown ("Fire1")) {
				SelectedItem = 0;
				useSelectedItem (0);
			} else if (inputDelta.sqrMagnitude > 1f)
				SelectedItem = 1;

            /*
			if (Input.GetKeyDown (KeyCode.C))
				SelectedItem++;
            */

            if (Input.GetKeyDown(KeyCode.LeftAlt) || Joystick.RightTrigger > 0)
            {
                //animator.SetTrigger("Dash");
                SelectedItem = 1;
                useSelectedItem(0);
            }

        } else {
			inputDelta = Vector3.zero;
			Move (transform.position);
		}

        //Pause the game once start button on controller has been pressed
        //For Controller Use
        if (Input.GetButtonDown("Start") && Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseObject.SetActive(true);
        }
        else if (Input.GetButtonDown("Start") && Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseObject.SetActive(false);
        }

        if (Input.GetKey("l"))
        {
            
        }

        //For Keyboard Use
        if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseObject.SetActive(false);
        }



        if (image.color.a > 0)
        {
            image.color = new Color(100f, 0f, 0f, image.color.a - 0.015f);
        }

        // Fire Fixed update
        base.FixedUpdate();
    }

    public virtual void Knockback(Transform input)
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

    private void DustAtFeet()
    {
        if (animator.GetFloat("Forward") >= 0.8f && isDusted == false)
        {
            isDusted = true;
            dustParticle.Play();
        }else if (animator.GetFloat("Forward") < 0.8f)
        {
            isDusted = false;
        }
    }

    private void FlashScreenRed()
    {
        GameObject redFlashObject = GameObject.Find("PauseMenu").transform.Find("RedFlash").gameObject;
        Image image = redFlashObject.GetComponent<Image>();
        image.color = new Color(100f, 0f, 0f, 1f);
    }

    //Play a Death sound once the Enemy / Player dies
    private void PlayAudio(int input)
    {
        audioSources = GetComponents<AudioSource>();
        audioSources[input].Play();
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
        Health = 100;
        //Fix animations
    }
}