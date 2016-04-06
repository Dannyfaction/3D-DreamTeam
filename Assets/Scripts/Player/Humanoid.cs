using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Humanoid : MonoBehaviour
{
    protected CharacterController Controller;
    protected bool isDead = false;
    private ParticleSystem[] particleSystems;
    [SerializeField] private ParticleSystem metalImpactParticle;
    private AudioSource[] audioSources;
    [SerializeField]
    private Animator animator;
    protected float hitAnimationCooldown = 0;
    protected SkinnedMeshRenderer shader;

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
            animator = GetComponent<Animator>();
            if (health == 0)
            {
                //Play Audio
                isDead = true;
                PlayAudio(0);
                PlayAudio(1);
                Invoke("PlayParticle", 0.8f);
                Invoke("RemoveObject", 2f);
            }
            if (health > 0)
            {
                PlayAudio(0);
                metalImpactParticle.Play();
                if (hitAnimationCooldown < 0)
                {
                    animator.SetTrigger("onHit");
                    hitAnimationCooldown = 300;
                }
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
        Transform spiritSpawnLocation = transform.Find("SpiritSpawnPosition").transform;
        Vector3 spiritSpawnVector = spiritSpawnLocation.transform.position;
        Instantiate(Resources.Load<GameObject>("Spirit"), new Vector3(spiritSpawnVector.x,spiritSpawnVector.y,spiritSpawnVector.z), Quaternion.identity);
        //Instantiate(Resources.Load<GameObject>("Spirit release"), spiritSpawnLocation.position, Quaternion.EulerAngles(-90,0,0));

        particleSystems = GetComponentsInChildren<ParticleSystem>();
        particleSystems[0].Play();
        particleSystems[1].Play();
        //particleSystems[1].Play();
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
}
