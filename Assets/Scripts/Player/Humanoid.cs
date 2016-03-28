using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Humanoid : MonoBehaviour
{
    protected CharacterController Controller;
    protected bool isDead = false;
    private ParticleSystem[] particleSystems;
    private AudioSource[] audioSources;

    /*
    protected WeaponScript weaponScript;
    public WeaponScript SetWeapon
    {
        set { weaponScript = value; }
    }
    */

    //The Character's Model, (not collision or holder)
    [SerializeField] protected GameObject CharacterModel;

    [SerializeField] protected List<WeaponScript> weaponList = new List<WeaponScript>();
    protected int selectedWeapon = 1;

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

    protected CameraScript cameraScript;
    [SerializeField] protected GameObject playerCamera;

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
                //Play Audio
                isDead = true;
                Invoke("PlayParticle",1f);
                Invoke("RemoveObject", 2f);
            }
            else if (health <= 0 && transform.tag == "Player")
            {
                //Play animation
                cameraScript = playerCamera.GetComponent<CameraScript>();
                cameraScript.DeathCamera();
                PlayAudio(1);
            }
        }
    }

    protected void useTool()
    {
        //weaponList.Add(GetComponentInChildren<WeaponScript>());
        //Debug.Log(weaponList[0]);
        if (weaponList.Count > 0)
            weaponList[selectedWeapon % weaponList.Count].attack();
    }

    //Plays particles
    private void PlayParticle()
    {
        Instantiate(Resources.Load<GameObject>("Spirit"), new Vector3(transform.position.x,transform.position.y,transform.position.z), Quaternion.identity);
        particleSystems = GetComponentsInChildren<ParticleSystem>();
        particleSystems[0].Play();
        particleSystems[1].Play();
    }

    //Play a Death sound once the Enemy / Player dies
    private void PlayAudio(int input)
    {
        audioSources = GetComponents<AudioSource>();
        audioSources[input].Play();
    }

    //Remove the object (Enemy or Player) once it dies
    private void RemoveObject()
    {
        Destroy(this.gameObject);
    }

    public void Knockback(Transform input)
    {
        //transform.localPosition -= transform.InverseTransformDirection(transform.forward) * 2f;
        if (transform.tag == "Player")
        {
            Controller.Move((Vector3.MoveTowards(Vector3.zero, input.forward, 10f)));
            int randomHitAudio = Random.Range(2,4);
            PlayAudio(randomHitAudio);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, input.up, 10f);
            //Play audio
            //Test knockback on enemy
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
