using UnityEngine;
using System.Collections;

public class AttackState : State
{

    private float distanceToTarget;

    public int sightDistance;
    Vector3 aiPos;
    Vector3 playerPos;
    private Enemy enemyScript;
	private Animator enemyAnimator;

	public override void Enter ()
	{
		enemyAnimator.SetBool("isAttacking", true);
	}

    public override void Act()
    {
        useTool(GetComponentInChildren<WeaponScript>());
       

        playerPos = targetGetter().transform.position;
        aiPos = transform.position - playerPos;
        transform.position = playerPos + Vector3.Normalize(aiPos) * 5;

		Debug.Log("Attack");
    }

    void Start()
    {
        enemyScript = GetComponent<Enemy>();
		enemyAnimator = GetComponentInChildren<Animator>();
    }
		
    public override void Reason()
    {
        distanceToTarget = Vector3.Distance(targetGetter().transform.position, transform.position);
		enemyAnimator.SetBool("isAttacking", false);
        if (distanceToTarget > 5)
            //enemyScript.IsMoving = true;
            GetComponent<StateMachine>().SetState(StateID.Chase);
    }
}