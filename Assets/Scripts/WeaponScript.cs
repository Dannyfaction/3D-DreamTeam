using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

    [SerializeField]
    float maxAttackCooldown = 4;
    float attackCooldown = 0;

    float attackDamage;
    bool attacking = false;
    Animator animator;
    

    void Start()
    {
        animator = transform.GetComponent<Animator>();
    }

    public void attack()
    {
        if (attackCooldown <= 0)
        {
            animator.SetBool("Attacking", true);
            attackCooldown = maxAttackCooldown;
        }
    }

	void Update()
	{
        
        if (attackCooldown <= 0 && animator.GetBool("Attacking"))
            animator.SetBool("Attacking", false);

        attackCooldown -= Time.deltaTime;
	}

    void OnTriggerEnter(Collider Col)
    {
        Debug.Log(Col.transform.name);
    }
}
