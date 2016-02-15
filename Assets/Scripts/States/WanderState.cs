using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class WanderState : State {
	
	public int sightDistance;
	
	public Collider[] enemyRange;
	public float patrolSpeed;
    private List<GameObject> waypoints;
	private int waypointInd;

    void Start()
    {
        waypoints = new List<GameObject>();
        waypoints.Add(GameObject.Find("Waypoint1"));
        waypoints.Add(GameObject.Find("Waypoint2"));
    }

	public override void Act(){
		if(Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) >= 2)
		{
			agent.SetDestination(waypoints[waypointInd].transform.position);
		}
		
		else if(Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) <= 2)
		{
			waypointInd = Random.Range(0, waypoints.Count);
		}
	}

	public override void Reason()	
	{
		float distanceToPlayer = Vector3.Distance(targetGetter().transform.position, transform.position);
		if(distanceToPlayer <  sightDistance)
			GetComponent<StateMachine>().SetState( StateID.Chase);
	}
}

