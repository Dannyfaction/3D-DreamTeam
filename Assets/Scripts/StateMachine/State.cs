using UnityEngine;
using System.Collections;

public abstract class State : MonoBehaviour {

	public NavMeshAgent agent;
	private GameObject target;

    public GameObject targetGetter()
    {
        target = GameObject.Find("Player");
        return target;
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

