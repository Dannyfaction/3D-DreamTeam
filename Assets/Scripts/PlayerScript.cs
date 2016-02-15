using UnityEngine;
using System.Collections;

public class PlayerScript : Humanoid {

    Vector3 moveDelta = new Vector3();
    Animator characterAnimator;
    private GameObject cameraObject;
    private GameObject healthObject;
    

    void Start()
    {
        healthObject = GameObject.Find("Health");
        Controller = transform.GetComponent<CharacterController>();
        characterAnimator = GetComponentInChildren<Animator>();
        cameraObject = GameObject.Find("Camera Object");
    }


	
	// Update is called once per frame
	void Update()
    {
        if (Input.GetKeyDown("space"))
            health -= 10;
        healthObject.transform.localScale = new Vector3((health/100),1,1);

        //Move Input detection
	    moveDelta = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //[NOTE] GetAxis method Will be replaced by a keybinding class when it's availible

        //Velocity change
        move(cameraObject.transform.right * moveDelta.x + cameraObject.transform.forward * moveDelta.z);


        //Animator Boolean
        if (isMoving)
        {
            characterAnimator.SetBool("isWalking", true);
        }
        else
        {
            characterAnimator.SetBool("isWalking", false);
        }

        //Action Input detection
        if (Input.GetButtonDown("Fire1")) //[NOTE] if statement Will be replaced by a keybinding class when it's availible
        {
            Debug.Log("Firing");

            useTool();
        }
    }
}
