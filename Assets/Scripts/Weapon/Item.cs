using UnityEngine;
using System.Collections;

public class Item : ScriptableObject {

	[HideInInspector] public Animator animator;
	public GameObject itemModel;

	public virtual void use (Transform caster, int toolMove) {
		
	}
	public virtual void UpdateItem() {
		
	}
	bool active;
	public bool Active {
		get { return active; }
		set { active = value; }
	}
}
