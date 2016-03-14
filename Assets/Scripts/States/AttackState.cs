using UnityEngine;
using System.Collections;

public class AttackState : State
{
    private float distanceToTarget;


    public int sightDistance;
    Vector3 aiPos;
    Vector3 playerPos;
    private Enemy enemyScript;

    public override void Act()
    {
        useTool();


		playerPos = targetGetter().transform.position;
		aiPos =  transform.position - playerPos;
		transform.position = playerPos + Vector3.Normalize(aiPos) * 5;
	}

	public override void Reason(){
		distanceToTarget = Vector3.Distance(targetGetter().transform.position, transform.position);
		if(distanceToTarget > 5 )
			GetComponent<StateMachine>().SetState( StateID.Chase);
	}

    void Start()
    {
        enemyScript = GetComponent<Enemy>();
    }



    public override void Reason()
    {
        distanceToTarget = Vector3.Distance(targetGetter().transform.position, transform.position);
        if (distanceToTarget > 5)
            //enemyScript.IsMoving = true;
            GetComponent<StateMachine>().SetState(StateID.Chase);
    }
}