using UnityEngine;
using System.Collections;

public class ChaseState : State {

    //At which speed the Enemy has to chase the Player at
	private float chaseSpeed = 10;

    //Attack Range
	private float GivenDistanceToTarget = 5;

    void Start()
    {
        WeaponScript weaponScript = GetComponent<WeaponScript>();
        WeaponListSetter(weaponScript);
    }

    public override void Act(){
        //Setting the speed and Destination on the Agent Manager for the NavMash Pathfinding
        NavMeshAgentSpeedSetter(chaseSpeed);
        NavMeshAgentDestinationSetter(targetGetter().transform.position);
	}
	
	public override void Reason(){
        //Total Distance from Player to Enemy
		float distanceToTarget = Vector3.Distance(targetGetter().transform.position,transform.position);

        //If the Target is within Attack Range
		if(distanceToTarget < GivenDistanceToTarget)
			GetComponent<StateMachine>().SetState( StateID.Attack);
	}
}
