using UnityEngine;
using UnityEditor;
using System.Collections;

public class CameraEventScript : MonoBehaviour {
    //list of event objects
    [SerializeField]
    private GameObject event_1_Cam;
    [SerializeField]
    private GameObject event_2_Cam;
    [SerializeField]
    private GameObject event_3_Cam;
    [SerializeField]
    private GameObject event_4_Cam;
    [SerializeField]
    private GameObject gate;
    [SerializeField]
    private GameObject pipeLine;
   
    private GameObject event_1_position;
    private GameObject event_3_position;

    private GameObject player;

    //animations from the objects
    private Animator animatorEvent1;
    private Animator animatorEvent2;
    private Animator animatorEvent3;
    private Animator animatorEvent4;

    private Animator gate_1;

    private Animator pipeLine_animation;

    //main camera
    [SerializeField]
    private GameObject playerCam;


    private bool intersectionEvent = false;

    private float up = 0.2f;
	// Use this for initialization
	void Start () {
        event_1_position = GameObject.Find("Event_1_position");
        event_3_position = GameObject.Find("Event_3_position");

        player = GameObject.Find("N_ThirdPersonPlayer");

        gate_1 = gate.GetComponent<Animator>();

        animatorEvent1 = event_1_Cam.GetComponent<Animator>();
        animatorEvent2 = event_2_Cam.GetComponent<Animator>();
        animatorEvent3 = event_3_Cam.GetComponent<Animator>();
        animatorEvent4 = event_4_Cam.GetComponent<Animator>();

        pipeLine_animation = pipeLine.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    // Event 1 (zooming in on enemy and closing gate)
    public void Event_1() {
        playerCam.gameObject.SetActive(false);
        event_1_Cam.gameObject.SetActive(true);

        animatorEvent1.SetBool("Event_1_Go", true);
        Invoke("Event_1_Back", 6f);
    }

    private void Event_1_Back()
    {
        player.transform.position = event_1_position.transform.position;
        animatorEvent1.SetBool("Event_1_Back", true);
        gate_1.SetBool("Door_Close", true);
        animatorEvent1.SetBool("Event_1_Go", false);
        Invoke("Back_To_Player", 7f);
    }

    // Event 2 (Hallway event)
    public void Event_2()
    {
        playerCam.gameObject.SetActive(false);
        event_2_Cam.gameObject.SetActive(true);

        animatorEvent2.SetBool("Event_2", true);

        Invoke("Back_To_Player", 6f);
    }

    //Event 3 (360 animation event)
    public void Event_3()
    {
        playerCam.gameObject.SetActive(false);
        event_3_Cam.gameObject.SetActive(true);

        animatorEvent3.SetBool("Event_3", true);
        Invoke("Event_3_Back", 2f);

    }

    private void Event_3_Back()
    {
        player.transform.position = event_3_position.transform.position;
        Invoke("Back_To_Player", 6f);
    }

    //Event 4 (the lower part of the level and pipe falling)
    public void Event_4()
    {
        playerCam.gameObject.SetActive(false);
        event_4_Cam.gameObject.SetActive(true);

        animatorEvent4.SetBool("Cam_4", true);
        Invoke("Event_4_Back", 5f);

    }

    private void Event_4_Back()
    {
        pipeLine_animation.SetBool("PipeDown", true);
        Invoke("Back_To_Player", 2f);
    }

    //Closing all events and going back to player
    private void Back_To_Player() {
        event_1_Cam.gameObject.SetActive(false);
        event_2_Cam.gameObject.SetActive(false);
        event_3_Cam.gameObject.SetActive(false);
        event_4_Cam.gameObject.SetActive(false);
        playerCam.gameObject.SetActive(true);
    }
}
