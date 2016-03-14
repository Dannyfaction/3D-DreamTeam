using UnityEngine;
using System.Collections;

public class AttackState : State {

	public int sightDistance;

	public override void Act()
	{
        useTool();
		/*	
		 * 	Dealing damgage value 5-10?
		 * 	Health system van de player koppellen aan AttackState
		 * 	Proto bevat: Attack, Chase en wander; uiteindelijk: Flee..
		 * 	De hoop word minder met de dag dat ik wacht..
		 */
	}
	
	public override void Reason(){
		float distanceToTarget = Vector3.Distance(targetGetter().transform.position, transform.position);
		if(distanceToTarget > sightDistance)
			GetComponent<StateMachine>().SetState( StateID.Wandering);
	}
}
