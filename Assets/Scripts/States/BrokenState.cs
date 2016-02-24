using UnityEngine;
using System.Collections;

public class BrokenState : State {

	/*
	 * Wait until event (Spirit release)
	 * Play animation
	 * Change to ChaseState
	 */ 

	[SerializeField] private int sightDistance;


	public override void Act()
	{
		/*
		 * Play animation when event happend
		 * Wait till animation is over
		 */ 
	}

	public override void Reason()
	{
		/*
		 * Check if animation is over
		 * "Build" the enemy - Animation!
		 * Change to ChaseState
		 */

		float distanceToPlayer = Vector3.Distance(targetGetter().transform.position, transform.position);
		if(distanceToPlayer < sightDistance){
			//GetComponent<StateMachine>().SetState( StateID.Chase);
		}
	}
}
