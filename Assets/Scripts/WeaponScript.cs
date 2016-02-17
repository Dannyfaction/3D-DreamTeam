using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

    [SerializeField]
    float maxAttackCooldown = 4;
    float attackCooldown = 0;

    float attackDamage;

    [SerializeField]
    int maxCombo = 3;
    [SerializeField]
    float comboTime = 0.5f;
    int currentCombo;
    public int Combo
    {
        get { return currentCombo; }
        set { currentCombo = value % (maxCombo + 1); }
    }
    
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
            animator.SetInteger("AttackState", Combo++);
        }
    }

	void Update()
	{
        
        if (attackCooldown + comboTime <= 0 && animator.GetInteger("AttackState") > 0)
            animator.SetInteger("AttackState", Combo = 0);

        attackCooldown -= Time.deltaTime;
	}

    void OnTriggerEnter(Collider Col)
    {
        Debug.Log(Col.transform.name);
    }
}
