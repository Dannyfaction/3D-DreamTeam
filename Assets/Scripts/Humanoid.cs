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


    //Function to use the selected weapon
    protected void useTool()
    {
        if (weaponList.Count > 0 && weaponList[selectedWeapon % weaponList.Count])
            weaponList[selectedWeapon % weaponList.Count].attack();
    }


    //Function to move the character around in a direction (the speed will be calculated depending on the Vector3 'moveDirection'). moveDirection's range goes from -1 to +1 and will be multiplied by the moveSpeed value.
    protected void move(Vector3 moveDirection)
    {
        
        //Move the character
        Controller.Move((Vector3.MoveTowards(Vector3.zero, moveDirection, 1) * moveSpeed + (characterCanFloat ? Vector3.zero : Physics.gravity)) * Time.deltaTime);


        //CharacterModel move rotation
        if (moveDirection.sqrMagnitude > 0)
            CharacterModel.transform.LookAt(CharacterModel.transform.position + moveDirection);
    }
}
