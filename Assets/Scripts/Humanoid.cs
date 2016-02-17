using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Humanoid : MonoBehaviour
{
    protected CharacterController Controller;

    //The Character's Model, (not collision or holder)
    [SerializeField] GameObject CharacterModel;

    [SerializeField] protected List<WeaponScript> weaponList = new List<WeaponScript>();
    protected int selectedWeapon = 0;

    //The health of the Humanoid
    [SerializeField] protected float health = 100;
    protected bool isMoving;

    //The movement speed of the Humanoid
    [SerializeField] protected float moveSpeed = 1;

    //Boolean for making the Humanoid float
    [SerializeField] protected bool characterCanFloat = false;

    public float Health
    {
        get { return health; }
        set
        {
            health = value;
            if (health <= 0)
                Destroy(this.gameObject);
        }
    }


    protected void useTool()
    {
        if (weaponList.Count > 0)
            weaponList[selectedWeapon % weaponList.Count].attack();
    }


    protected void move(Vector3 moveDirection)
    {
        
        //Move the character
        Controller.Move((Vector3.MoveTowards(Vector3.zero, moveDirection, 1) * moveSpeed + (characterCanFloat ? Vector3.zero : Physics.gravity)) * Time.deltaTime);

        //Animator Boolean
        if (moveDirection.x != 0f || moveDirection.z != 0f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        //CharacterModel move rotation
        if (moveDirection.sqrMagnitude > 0)
            CharacterModel.transform.LookAt(CharacterModel.transform.position + moveDirection);

    }
}
