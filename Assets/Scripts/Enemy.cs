using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum StateID
{
	NullStateID = 0,
	Wandering = 1,
	Chase = 2,
	Attack = 3
}

public class Enemy : MonoBehaviour {
    
    //Which spawnpoints 
    private List<GameObject> waypoints;
    public List<GameObject> waypointGetter()
    {
        return waypoints;
    }

    //Which spawn point the Enemy has been spawned at
    private int whichSpawnpoint;
    public int whichSpawnpointGetter()
    {
        return whichSpawnpoint;
    }
    public void whichSpawnpointSetter(int input)
    {
        whichSpawnpoint = input;
    }

	private StateMachine stateMachine;
	void Start () {
        stateMachine = GetComponent<StateMachine>();
        waypoints = new List<GameObject>();
        //Which speccific waypoints the enemies on specific spawn points have to wander around
        switch (whichSpawnpoint)
        {
            case 0:
                waypoints.Add(GameObject.Find("Waypoint0"));
                waypoints.Add(GameObject.Find("Waypoint1"));
                waypoints.Add(GameObject.Find("Waypoint2"));
                waypoints.Add(GameObject.Find("Waypoint3"));
                break;
            case 1:
                waypoints.Add(GameObject.Find("Waypoint4"));
                waypoints.Add(GameObject.Find("Waypoint5"));
                waypoints.Add(GameObject.Find("Waypoint6"));
                waypoints.Add(GameObject.Find("Waypoint7"));
                break;
            case 2:
                waypoints.Add(GameObject.Find("Waypoint4"));
                waypoints.Add(GameObject.Find("Waypoint5"));
                waypoints.Add(GameObject.Find("Waypoint6"));
                waypoints.Add(GameObject.Find("Waypoint7"));
                break;
            case 3:
                waypoints.Add(GameObject.Find("Waypoint8"));
                waypoints.Add(GameObject.Find("Waypoint9"));
                waypoints.Add(GameObject.Find("Waypoint10"));
                waypoints.Add(GameObject.Find("Waypoint11"));
                break;
            case 4:
                waypoints.Add(GameObject.Find("Waypoint8"));
                waypoints.Add(GameObject.Find("Waypoint9"));
                waypoints.Add(GameObject.Find("Waypoint10"));
                waypoints.Add(GameObject.Find("Waypoint11"));
                break;
            case 5:
                waypoints.Add(GameObject.Find("Waypoint8"));
                waypoints.Add(GameObject.Find("Waypoint9"));
                waypoints.Add(GameObject.Find("Waypoint10"));
                waypoints.Add(GameObject.Find("Waypoint11"));
                break;



        }
		MakeStates();
		stateMachine.SetState( StateID.Wandering );
	}
	
	void MakeStates() {
        //The states in the Dictionary
		stateMachine.AddState( StateID.Chase, GetComponent<ChaseState>() );
		stateMachine.AddState( StateID.Wandering, GetComponent<WanderState>() );
		stateMachine.AddState( StateID.Attack, GetComponent<AttackState>() );
	}
	
}