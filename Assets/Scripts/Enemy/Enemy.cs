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

public class Enemy : Humanoid {
    
    //Which spawnpoints 
    private List<GameObject> waypoints;
    private Animator enemyAnimator;
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

    void Update()
    {
		HealthUpdate();
    }

	void HealthUpdate(){
		if(health == 0){
			enemyAnimator.SetBool("onDead", true);
			Destroy(this.gameObject, 4f);
		}
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			health--;
			Debug.Log(health);
		}
	}

	private StateMachine stateMachine;
	void Start () {
        enemyAnimator = GetComponentInChildren<Animator>();
        stateMachine = GetComponent<StateMachine>();
        waypoints = new List<GameObject>();

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