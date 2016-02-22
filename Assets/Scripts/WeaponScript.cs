using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

    [SerializeField]
    GameObject Hitbox;

    [SerializeField]
    float maxAttackCooldown = 4;
    float attackCooldown = 0;

    [SerializeField]
    float attackDamage = 20;

    [SerializeField]
    int maxCombo = 3;
    [SerializeField]
    float comboTime = 0.5f;
    int currentCombo;
    public int Combo
    {
        get { return currentCombo; }
        set { currentCombo = value % (maxCombo); }
    }
    
    [SerializeField]
    Animator animator;

    void Start()
    {
        animator = transform.GetComponentInParent<Animator>();
        attackCooldown = -comboTime;
    }

    public void attack()
    {
        if (attackCooldown <= 0 || animator.GetInteger("AttackState") == 0)
        {
            attackCooldown = maxAttackCooldown;
            Combo++;
            animator.SetInteger("AttackState", Combo);
        }
    }

	void Update()
	{

        if (attackCooldown + comboTime <= 0 && animator.GetInteger("AttackState") > 0)
        {
            animator.SetInteger("AttackState", Combo = 0);
        }
        if (attackCooldown + comboTime > 0 && !Hitbox.activeSelf)
            Hitbox.SetActive(true);
        else if (attackCooldown + comboTime <= 0 && Hitbox.activeSelf)
            Hitbox.SetActive(false);


        attackCooldown -= Time.deltaTime;
	}

    void OnTriggerEnter(Collider Col)
    {
        Debug.Log(Col.name);

        Humanoid hum = Col.GetComponent<Humanoid>();

        if (hum && !Col.CompareTag(transform.tag))
            hum.Health -= attackDamage;
        Debug.Log(Col.name);
    }
}
