using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Humanoid : MonoBehaviour
{
    protected CharacterController Controller;
    protected bool isDead = false;
    private ParticleSystem[] particleSystems;
    private AudioSource[] audioSources;


    //The Character's Model, (not collision or holder)
    [SerializeField] GameObject CharacterModel;

    [SerializeField] protected List<WeaponScript> weaponList = new List<WeaponScript>();
    protected int selectedWeapon = 0;

    //The health of the Humanoid
    [SerializeField] protected float health = 100;

    public bool IsMoving
    {
        get { return isMoving; }
        set { isMoving = value; }
    }
    protected bool isMoving;

    //The movement speed of the Humanoid
    [SerializeField] protected float moveSpeed = 1;

    private CameraScript cameraScript;
    [SerializeField] private GameObject playerCamera;

    //Boolean for making the Humanoid float
    [SerializeField] protected bool characterCanFloat = false;

    public float Health
    {
        get { return health; }
        set
        {
            health = value;
            if (health == 0 && transform.tag == "Enemy")
            {
                isDead = true;
                PlayAudio();
                Invoke("PlayParticle",1f);
                Invoke("RemoveObject", 2f);
            }
            else if (health <= 0 && transform.tag == "Player")
            {
                cameraScript = playerCamera.GetComponent<CameraScript>();
                cameraScript.DeathCamera();
            }
        }
    }

    protected void useTool(WeaponScript input)
    {
        weaponList.Add(input);
        if (weaponList.Count > 0)
            weaponList[selectedWeapon % weaponList.Count].attack();
    }

    private void PlayParticle()
    {
        Instantiate(Resources.Load<GameObject>("Spirit"), new Vector3(transform.position.x,transform.position.y,transform.position.z), Quaternion.identity);
        particleSystems = GetComponentsInChildren<ParticleSystem>();
        particleSystems[0].Play();
        particleSystems[1].Play();
    }

    //Play a Death sound once the Enemy / Player dies
    private void PlayAudio()
    {
        audioSources = GetComponents<AudioSource>();
        audioSources[1].Play();
    }

    //Remove the object (Enemy or Player) once it dies
    private void RemoveObject()
    {
        Destroy(this.gameObject);
    }

    public void Knockback(Transform input)
    {
        //transform.localPosition -= transform.InverseTransformDirection(transform.forward) * 2f;
        if (transform.name == ("Player"))
        {
            Controller.Move((Vector3.MoveTowards(Vector3.zero, input.forward, 10f)));
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, input.up, 10f);
        }
    }

    protected void move(Vector3 moveDirection)
    {
        
        //Move the character
        Controller.Move((Vector3.MoveTowards(Vector3.zero, moveDirection, 1) * moveSpeed + (characterCanFloat ? Vector3.zero : Physics.gravity)) * Time.deltaTime);

        //Animator Boolean
        if (transform.tag == "Player")
        {
            if (moveDirection.x != 0f || moveDirection.z != 0f)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }

        //CharacterModel move rotation
        if (moveDirection.sqrMagnitude > 0)
            CharacterModel.transform.LookAt(CharacterModel.transform.position + moveDirection);

    }
}
