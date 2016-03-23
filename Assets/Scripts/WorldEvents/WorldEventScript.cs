using UnityEngine;
using System.Collections;

public class WorldEventScript : MonoBehaviour {
    //main camera
    [SerializeField]
    private GameObject playerCam;

    CameraEventScript cameraEvents;

    CameraScript camera;
	// Use this for initialization
	void Start () {
        cameraEvents = GameObject.Find("WorldEventSystem").GetComponent<CameraEventScript>();
        camera = playerCam.GetComponent<CameraScript>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void Event1()
    {
        //switches camera
        cameraEvents.Event_1();

        //start event
        Destroy(GameObject.Find("Event_1"));
    }

    public void Event2()
    {
        cameraEvents.Event_2();

        Destroy(GameObject.Find("Event_2"));
    }

    public void Event3()
    {
        cameraEvents.Event_3();

        Destroy(GameObject.Find("Event_3"));
    }

    public void Event4()
    {
        cameraEvents.Event_4();

        Destroy(GameObject.Find("Event_4"));
    }
}
