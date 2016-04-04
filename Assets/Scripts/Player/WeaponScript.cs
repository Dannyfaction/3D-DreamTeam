using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

    [SerializeField]
    private GameObject Hitbox;

    [SerializeField]
    float maxAttackCooldown = 4;
    float attackCooldown = 0;

    /*
    private bool isAttacking;
    public bool isAttackingGetSet
    {
        get { return isAttacking; }
        set { isAttacking = value; }
    }
    */

    [SerializeField] float attackDamage = 20;
    private GameObject swordTrail;

    [SerializeField] int maxCombo = 3;
    [SerializeField]
    float comboTime = 0.5f;
    int currentCombo;
    public int Combo
    {
        get { return currentCombo; }
        set { currentCombo = value % (maxCombo); }
    }
    
    [SerializeField]
    private Animator animator;

    void Start()
    {
        animator = transform.GetComponentInParent<Animator>();
        attackCooldown = -comboTime;
        if (transform.tag == "Player")
        {
            //swordTrail = transform.Find("Trailrenderer_Sword").gameObject;
        }
    }

    public void attack()
    {
        if (attackCooldown <= 0)
        {
            attackCooldown = maxAttackCooldown;
            Combo++;
            //isAttacking = true;
        }
    }

	void Update()
	{
        /*
        if (transform.tag == "Player")
        {
            if (attackCooldown + comboTime > 0 && !Hitbox.activeSelf)
                Hitbox.SetActive(true);
            else if (attackCooldown + comboTime <= 0 && Hitbox.activeSelf)
            {
                Hitbox.SetActive(false);
                //isAttacking = false;
                swordTrail.SetActive(false);

            }
            attackCooldown -= Time.deltaTime;
        }
        */
        /*
        if (transform.tag == "Enemy")
        {
            if (attackCooldown + comboTime > 0 && !Hitbox.activeSelf)
                Hitbox.SetActive(true);
            else if (attackCooldown + comboTime <= 0 && Hitbox.activeSelf)
            {
                Hitbox.SetActive(false);
                //isAttacking = false;

            }
        }
        */

       
	}

    void OnTriggerEnter(Collider Col)
    {
        PlayerControl character = Col.GetComponent<PlayerControl>();
        AudioSource hitSound = Col.GetComponent<AudioSource>();
        if (Col.tag == "Player")
        {
            character.Health -= attackDamage;
            character.Knockback(transform.root);

        }
        /*
        if (hum && !Col.CompareTag(transform.tag))
        {
            hum.Health -= attackDamage;
            hum.Knockback(transform.root.Find("Model"));
            hitSound.Play();
        }
        else if(!hum && !Col.CompareTag(transform.tag))
        {
            hum = Col.GetComponentInParent<Humanoid>();
            hitSound = Col.GetComponentInParent<AudioSource>();
            hum.Health -= attackDamage;
            hum.Knockback(transform);
            hitSound.Play();
        }
        */
    }
}
