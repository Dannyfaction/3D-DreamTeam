using UnityEngine;
using System.Collections;

public class ChaseState : State {

	private int chaseSpeed = 10;
	private int GivenDistanceToTarget = 2;

	public override void Act(){
		agent.speed = chaseSpeed;
		agent.SetDestination(targetGetter().transform.position);
	}
	
	public override void Reason(){
		float distanceToTarget = Vector3.Distance(targetGetter().transform.position, transform.position);

		if(distanceToTarget < GivenDistanceToTarget)
			GetComponent<StateMachine>().SetState( StateID.Attack);
	}
}
