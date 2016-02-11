using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Humanoid : MonoBehaviour
{
    protected CharacterController Controller;
    [SerializeField] //The Character's Model, (not collision or holder)
    GameObject CharacterModel;

    [SerializeField]
    protected List<WeaponScript> weaponList = new List<WeaponScript>();
    protected int selectedWeapon = 0;

    [SerializeField]
    protected float health = 100;

    [SerializeField]
    protected float moveSpeed = 1;

    [SerializeField]
    protected bool characterCanFloat = false;


    protected void useTool()
    {
        if (weaponList.Count > 0)
            weaponList[selectedWeapon % weaponList.Count].attack();
    }


    protected void move(Vector3 moveDirection)
    {
        
        //Move the character
        Controller.Move((Vector3.MoveTowards(Vector3.zero, moveDirection, 1) * moveSpeed + (characterCanFloat ? Vector3.zero : Physics.gravity)) * Time.deltaTime);


        //CharacterModel move rotation
        if (moveDirection.sqrMagnitude > 0)
            CharacterModel.transform.LookAt(transform.position + moveDirection);
    }
}
