using UnityEngine;
using System.Collections;

public class AttackState : State
{

    private float distanceToTarget;

    public int sightDistance;
    Vector3 aiPos;
    Vector3 playerPos;
    private Enemy enemyScript;

    public override void Act()
    {
<<<<<<< HEAD
		useTool();
=======
        useTool(transform.Find("Weapon").GetComponent<WeaponScript>());
        /*	
		 * 	Dealing damgage value 5-10?
		 * 	Health system van de player koppellen aan AttackState
		 * 	Proto bevat: Attack, Chase en wander; uiteindelijk: Flee..
		 * 	De hoop word minder met de dag dat ik wacht..
		 * 
		 *
		 */
>>>>>>> master

        playerPos = targetGetter().transform.position;
        aiPos = transform.position - playerPos;
        transform.position = playerPos + Vector3.Normalize(aiPos) * 5;
    }

    void Start()
    {
        enemyScript = GetComponent<Enemy>();
    }

    public override void Reason()
    {
        distanceToTarget = Vector3.Distance(targetGetter().transform.position, transform.position);
        if (distanceToTarget > 5)
            //enemyScript.IsMoving = true;
            GetComponent<StateMachine>().SetState(StateID.Chase);
    }
}