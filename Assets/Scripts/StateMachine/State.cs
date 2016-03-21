using UnityEngine;
using System.Collections;

public abstract class State : Humanoid {

    //This is in the Unity Inspector for setting the NavMeshAgent
	[SerializeField] private NavMeshAgent agent;

    //The target for the Enemies (The Player in this case)
	private GameObject target;

    public GameObject targetGetter()
    {
        target = GameObject.Find("N_ThirdPersonPlayer");
        return target;
    }

    //Setting the Speed in the NavMeshAgent
    public void NavMeshAgentSpeedSetter(float input)
    {
        agent.speed = input;
    }

    //Sets the Distance for the NavMeshAgent
    public void NavMeshAgentDestinationSetter(Vector3 input)
    {
        agent.destination = input;
    }


	public virtual void Enter ()
	{

	}
	
	public virtual void Leave ()
	{

	} 
	
	public abstract void Act ();
	
	public abstract void Reason ();
	
}

