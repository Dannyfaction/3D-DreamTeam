using UnityEngine;
using System.Collections;

public class AttackState : State {

	private float distanceToTarget;

	public int sightDistance;
	Vector3 aiPos;
	Vector3 playerPos;

	public override void Act()
	{
        useTool();
		/*	
		 * 	Dealing damgage value 5-10?
		 * 	Health system van de player koppellen aan AttackState
		 * 	Proto bevat: Attack, Chase en wander; uiteindelijk: Flee..
		 * 	De hoop word minder met de dag dat ik wacht..
		 * 
		 *
		 */

		playerPos = targetGetter().transform.position;
		aiPos =  transform.position - playerPos;
		transform.position = playerPos + Vector3.Normalize(aiPos) * 5;
	}


	
	public override void Reason(){
		distanceToTarget = Vector3.Distance(targetGetter().transform.position, transform.position);
		if(distanceToTarget > 5 )
			GetComponent<StateMachine>().SetState( StateID.Chase);
	}
}
