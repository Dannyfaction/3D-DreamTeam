using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

    float attackDamage;

    public void attack()
    {
        foreach (Collider col in Physics.OverlapSphere(transform.position + transform.forward * 2, 1)) Debug.Log(col.transform.name);

        
    }
}
