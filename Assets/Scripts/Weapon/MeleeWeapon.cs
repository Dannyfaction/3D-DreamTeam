using UnityEngine;
using System.Collections;
using UnityEditor;

[CreateAssetMenu()]
public class MeleeWeapon : Item {

	public GameObject WeaponModel;

	int currentMoveIndex = 0;
	int currentHitboxIndex = 0;
	Moves activeMove;
	Hitbox activeHitbox;
	Hitbox ActiveHitbox {
		get { return activeHitbox; }
		set {
			activeHitbox = value;
			if (value != null)
				activeHitbox.duration = Time.time + activeHitbox.comboTime;

			if (activeMove != null)
				activeMove.cooldown = Time.time + activeMove.maxCooldown;
		}
	}

	// The hitbox object with values
	[System.Serializable]
	public class Hitbox {
		[SerializeField] float damage; // Damage of the sphere collider
		[SerializeField] Vector3 offset; // Offset of the sphere collider
		[SerializeField] Vector3 rotation; // Rotation of the hitbox in XYZ angles
		[SerializeField] Vector3 size = new Vector3(1, 1, 1); // Radius of the sphere collider
		public float maxDuration = 1; // the duration for the active hitbox
		[HideInInspector] public float duration; // the duration for the active hitbox
		public bool combo; // If it should continue on the next hitbox instead of starting at 0 hitbox again
		public float comboTime; // the duration to trigger the net combo attack
		public bool chainNextHitbox; // If the next hitbox in the array should be fired at the same time
		public int attackAnimation; // the ID of the animation for the animator controller


		public GameObject model;

		public void UpdateHitbox (Transform caster, Animator animator) {

			//Debug.Log ("Doing combo: " + size);

			RaycastHit[] hits = Physics.BoxCastAll (caster.position + caster.TransformDirection(offset), size/2, Vector3.forward, Quaternion.LookRotation(caster.forward));

			animator.SetInteger ("AttackState", attackAnimation);
			animator.SetTrigger ("Attack");

			foreach (RaycastHit hit in hits) {
				if (hit.transform != caster.transform && hit.transform.gameObject.GetComponent <Humanoid> ())
					hit.transform.gameObject.GetComponent <Humanoid> ().Health -= damage;
			}

			//if (hits.Length > 0)
			//	Debug.Log (hits [0].transform.name);
			//else
			//	Debug.Log ("No hits");
		}
	}

	// The hixboxes from the attack move to check what/where to damage
	[System.Serializable]
	public class Moves {
		
		public float maxCooldown; // In seconds
		[HideInInspector] public float cooldown = 0;

		[SerializeField]
		public Hitbox[] hitboxes;
		[HideInInspector] public int currentHitbox;
	}




	// The attack moves (Edited in the Unity editor)
	[SerializeField]
	public Moves[] moves;



	public override void UpdateTool() {

		//if (ActiveHitbox == null)
		//	animator.SetInteger ("AttackState", 0);
	}




	// Tell the character you want it to use this tool and what move of his weapon he should use
	public override void use (Transform caster, int toolMove) {


		// Check if there is a move within moves's index and if there isn't a move already being used
		if (toolMove < moves.Length && (toolMove == currentMoveIndex || (ActiveHitbox == null || Time.time > ActiveHitbox.duration + ActiveHitbox.comboTime))) {
			//Debug.Log ("Firing Move");

			// Check if the move is ready to use, If so, make it the current attack
			if (moves [toolMove].cooldown < Time.time && (ActiveHitbox == null || Time.time > ActiveHitbox.duration + ActiveHitbox.comboTime)) {
				//Debug.Log ("Resetting move");

				// Reset the combo
				currentHitboxIndex = 0;


				// (Re)set the active hitbox and move
				activeMove = moves [toolMove];
				ActiveHitbox = activeMove.hitboxes [currentHitboxIndex];
				ActiveHitbox.UpdateHitbox (caster, animator);

				currentHitboxIndex++;

				// Set the cooldown of the move
				activeMove.cooldown = activeMove.maxCooldown + Time.time;
			} //else Debug.Log ("On cooldown");


			if (activeHitbox != null && Time.time > activeHitbox.duration && Time.time < activeHitbox.duration + activeHitbox.comboTime) {

				ActiveHitbox = activeMove.hitboxes [currentHitboxIndex % activeMove.hitboxes.Length];
				ActiveHitbox.UpdateHitbox (caster, animator);

				currentHitboxIndex++;

				while (ActiveHitbox.chainNextHitbox) {
					ActiveHitbox.UpdateHitbox (caster, animator);
					ActiveHitbox = activeMove.hitboxes [currentHitboxIndex++ % activeMove.hitboxes.Length];
				}


				activeMove.cooldown = activeMove.maxCooldown + Time.time + activeHitbox.duration + activeHitbox.comboTime;

				if (!ActiveHitbox.combo)
					ActiveHitbox = null;
				
			} else {
				//Debug.Log ("No combos left");
				if (ActiveHitbox != null) Debug.Log (Time.time + " ~ " + ActiveHitbox.duration + " + " + ActiveHitbox.comboTime  + " = " + (ActiveHitbox.duration + activeHitbox.comboTime));
			}
		}
	}
}