using UnityEngine;
using System.Collections;

public class IdleState : State {

	private float distanceToTarget;

	private Enemy enemyScript;

	void Start()
	{
	}

	public override void Act()
	{
		Debug.Log("Idle");
	}
		
	public override void Reason()
	{
		distanceToTarget = Vector3.Distance(targetGetter().transform.position, transform.position);
		if (distanceToTarget > 5)
			//enemyScript.IsMoving = true;
			GetComponent<StateMachine>().SetState(StateID.Chase);
	}
}
