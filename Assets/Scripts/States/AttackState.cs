using UnityEngine;
using System.Collections;

public class AttackState : State {

	public int sightDistance;

   void Start()
    {
        Invoke("addScripts", 0.5f);
    }

	public override void Act()
	{
		Debug.Log("Attacking");

        useTool();
		/*	
		 * 	Dealing damgage value 5-10?
		 * 	Health system van de player koppellen aan AttackState
		 * 	Proto bevat: Attack, Chase en wander; uiteindelijk: Flee..
		 * 	De hoop word minder met de dag dat ik wacht..
		 */
	}

    private void addScripts()
    {
        WeaponScript weaponScript = GetComponentInChildren<WeaponScript>();
        weaponList.Add(weaponScript);
        Humanoid humanoid = GetComponent<Humanoid>();
        //humanoid.WeaponListSetter(weaponScript);
    }
	
	public override void Reason(){
		float distanceToTarget = Vector3.Distance(targetGetter().transform.position, transform.position);
		if(distanceToTarget > sightDistance)
			GetComponent<StateMachine>().SetState( StateID.Wandering);
	}
}
