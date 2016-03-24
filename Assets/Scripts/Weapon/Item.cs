using UnityEngine;
using System.Collections;

public class Item : ScriptableObject {

	[HideInInspector] public Animator animator;

	public virtual void use (Transform caster, int toolMove) {
		
	}
	public virtual void UpdateTool() {
		
	}
}
