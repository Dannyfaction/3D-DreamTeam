using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class WanderState : State {
	
	public int sightDistance;
    private Enemy enemyScript;
	//public Collider[] enemyRange;
	public float patrolSpeed;
    private List<GameObject> waypoints = new List<GameObject>();
	private int waypointInd = 0;

    void Start()
    {
        enemyScript = GetComponent<Enemy>();
        WeaponScript weaponScript = GetComponent<WeaponScript>();


        //Gets which Waypoints the Enemy was assigned to
        waypoints = enemyScript.waypointGetter();
    }

    //This is called every frame
	public override void Act(){
        //If the Enemy is away from the Waypoint
        if (enemyScript)
        {
            enemyScript.IsMoving = true;
        }

        //If there are waypoints set up
        if (waypoints.Count > 0)
        {
            if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) >= 2)
            {
                //Sets the next destination (Waypoint)
                NavMeshAgentDestinationSetter(waypoints[waypointInd].transform.position);
            }

            //If the Enemy reached the Waypoint
            else if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) <= 2)
            {
                //Assign a Random next Waypoint
                waypointInd = Random.Range(0, waypoints.Count);
            }
        }
        
	}

	public override void Reason()	
	{
		float distanceToPlayer = Vector3.Distance(targetGetter().transform.position, transform.position);
		if(distanceToPlayer <  sightDistance)
            //This makes the Enemy chase the Player once it is in a certain range
			GetComponent<StateMachine>().SetState( StateID.Chase);
	}
}

