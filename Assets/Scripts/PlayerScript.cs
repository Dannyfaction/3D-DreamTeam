using UnityEngine;
using System.Collections;

public class PlayerScript : Humanoid {

    Vector3 moveDelta = new Vector3();
    

    void Start()
    {
        Controller = transform.GetComponent<CharacterController>();
    }


	
	// Update is called once per frame
	void Update()
    {
        //Move Input detection
	    moveDelta = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //[NOTE] GetAxis method Will be replaced by a keybinding class when it's availible



        //Velocity change
        move(moveDelta);



        //Action Input detection
        if (Input.GetButtonDown("Fire1")) //[NOTE] if statement Will be replaced by a keybinding class when it's availible
        {
            Debug.Log("Firing");

            useTool();
        }
    }
}
