using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	/*
	 * This script is ONLY to show off the boss animations
	 * This script will possibly be deleted after the demo
	 * So dont make your shit depend on this script, thanks!
	 */ 



	Animator bossAnimator;

	// Use this for initialization
	void Start () {
		bossAnimator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.T))
		{
			bossAnimator.SetBool("isInAttackPhase", true);
		}
		if(Input.GetKeyUp(KeyCode.T))
		{
			bossAnimator.SetBool("isInAttackPhase", false);
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			bossAnimator.SetBool("isAttacking", true);
		}
		if(Input.GetKeyUp(KeyCode.Space))
		{
			bossAnimator.SetBool("isAttacking", false);
		}

	}
}
