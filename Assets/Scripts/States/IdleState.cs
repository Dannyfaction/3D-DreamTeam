using UnityEngine;
using System.Collections;

public class IdleState : State {
	
	/*
	 * Wait until player is in range
	 * Play animations
	 * Change to ChaseState
	 */ 

	[SerializeField] private int sightDistance;
	
	
	public override void Act()
	{
		/*
		 * Play animations in enemy.cs
		 * Wait till animations are over
		 */ 
	}
	
	public override void Reason()
	{
		// Wait till animations are over
		float distanceToPlayer = Vector3.Distance(targetGetter().transform.position, transform.position);
		if(distanceToPlayer < sightDistance){
			GetComponent<StateMachine>().SetState( StateID.Chase);
		}
	}
}
